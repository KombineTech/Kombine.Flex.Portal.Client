using System;
internal static class DesktopMain
{
    private static int Main()
    {
        try { Console.WriteLine(Program.Run(AppDomain.CurrentDomain.BaseDirectory)); return 0; }
        catch (Exception error) { Console.Error.WriteLine(error); return 1; }
    }
}
