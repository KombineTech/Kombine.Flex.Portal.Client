using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
#if PORTAL_NET45
using Kombine.Flex.Portal.Client.Net45;
#elif PORTAL_COMPACT20
using Kombine.Flex.Portal.Client.Compact20;
#else
using Kombine.Flex.Portal.Client.Net20;
#endif

internal static class SessionChecks
{
    private static readonly Uri Endpoint = new Uri("https://fixture.test/");
    private const string SessionJson = "{\"accessToken\":\"session-token\",\"tokenType\":\"Bearer\",\"expiresIn\":3600}";
    private delegate PortalResponse Response(PortalRequest request);
    private sealed class Transport : IPortalTransport
    {
        internal Response Reply;
        public PortalResponse Send(PortalRequest request) { return Reply(request); }
    }
    private static PortalResponse Json(int status, string body)
    {
        PortalResponse response = new PortalResponse(); response.Status = status;
        response.Headers = new Dictionary<string, string>(); response.Stream = new MemoryStream(Encoding.UTF8.GetBytes(body));
        return response;
    }
    private static PortalSession Create(Transport transport, bool configured)
    {
        PortalCredentialsProvider provider = null;
        if (configured) provider = delegate { return new PortalCredentials("fixture@example.invalid", "fixture-password"); };
        return new PortalSession(Endpoint, provider, delegate { return new PortalApiClient(Endpoint, transport); });
    }
    private static void Check(bool value) { if (!value) throw new Exception("Shared session regression failed."); }
    internal static int Run()
    {
        int auth = 0, reads = 0;
        Transport transport = new Transport();
        transport.Reply = delegate(PortalRequest request)
        {
            if (request.Uri.AbsolutePath.EndsWith("/login") || request.Uri.AbsolutePath.EndsWith("/renew")) { auth++; return Json(200, SessionJson); }
            reads++; return Json(200, "{}");
        };
        PortalSession session = Create(transport, true);
        PortalSessionToken token = session.GetToken();
        Check(Object.ReferenceEquals(token, session.GetToken()) && auth == 1);
        using (PortalApiClient api = session.CreateClient()) { api.GetPortalStatus(); }
        Check(auth == 1 && reads == 1 && session.Current != null);
        session.Restore("old-token", DateTime.UtcNow.AddSeconds(30));
        session.GetToken(); Check(auth == 2);
        session.ClearSession();
        bool required = false;
        try { session.GetToken(); } catch (InvalidOperationException) { required = true; }
        Check(required && auth == 2 && session.Current == null);
        session.Login("fixture@example.invalid", "fixture-password"); Check(auth == 3);

        auth = 0; reads = 0;
        transport.Reply = delegate(PortalRequest request)
        {
            if (request.Uri.AbsolutePath.EndsWith("/login")) { auth++; return Json(200, SessionJson); }
            reads++; return Json(401, "{}");
        };
        session = Create(transport, true);
        try { session.ExecuteRead<ApiStatusResponse>(delegate(PortalApiClient api) { return api.GetPortalStatus(); }); }
        catch (PortalApiException error) { Check(error.StatusCode == 401); }
        Check(auth == 2 && reads == 2);

        transport.Reply = delegate(PortalRequest request) { return Json(503, "{}"); };
        session.Restore("existing", DateTime.UtcNow.AddSeconds(30));
        try { session.GetToken(); } catch (PortalApiException error) { Check(error.StatusCode == 503); }
        Check(session.Current.AccessToken == "existing");

        // Clearing the session while authentication is executing must return immediately and prevent resurrection.
        PortalSession pending = Create(transport, true);
        transport.Reply = delegate(PortalRequest request) { pending.ClearSession(); return Json(200, SessionJson); };
        bool changed = false;
        try { pending.GetToken(); } catch (InvalidOperationException) { changed = true; }
        Check(changed && pending.Current == null);

        // Real contention exercises the separate authentication lock on each supported CLR.
        ManualResetEvent entered = new ManualResetEvent(false), release = new ManualResetEvent(false);
        auth = 0;
        transport.Reply = delegate(PortalRequest request) { Interlocked.Increment(ref auth); entered.Set(); release.WaitOne(); return Json(200, SessionJson); };
        PortalSession concurrent = Create(transport, true);
        Exception failure = null;
        Thread first = new Thread(new ThreadStart(delegate { try { concurrent.GetToken(); } catch (Exception ex) { failure = ex; } }));
        Thread second = new Thread(new ThreadStart(delegate { try { concurrent.GetToken(); } catch (Exception ex) { failure = ex; } }));
        first.Start();
        Check(entered.WaitOne(5000, false));
        second.Start(); release.Set();
        Check(first.Join(5000) && second.Join(5000) && failure == null && auth == 1);
        entered.Close(); release.Close();
        return 14;
    }
}
