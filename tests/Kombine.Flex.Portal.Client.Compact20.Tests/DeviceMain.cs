using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

// Runs only synthetic fixtures. No login, API mutations or production data.
internal sealed class DeviceMain : Form
{
    private readonly TextBox _result = new TextBox();
    private delegate void ShowResult(string text);
    private DeviceMain()
    {
        Text = "Flex Portal CF 2.0 tests";
        _result.Multiline = true; _result.ReadOnly = true; _result.Dock = DockStyle.Fill;
        _result.Text = "Running synthetic client checks..."; Controls.Add(_result);
        Load += delegate(object sender, EventArgs args)
        {
            Thread thread = new Thread(delegate()
            {
                string result;
                try
                {
                    string directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
                    result = Program.Run(directory);
                }
                catch (Exception error) { result = "FAIL: " + error; }
                Invoke(new ShowResult(Display), new object[] { result });
            });
            thread.Start();
        };
    }
    private void Display(string text) { _result.Text = text; }
    private static void Main() { Application.Run(new DeviceMain()); }
}
