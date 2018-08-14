using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DuckyVisual
{

    //Not really satisfied with this class :v

    class HTTPServer
    {
        private bool autoUpdate = true;
        
        private DuckyInterface DI;
        public HTTPServer(DuckyInterface di)
        {
            DI = di;
            Listener();
        }
        public void Listener()
        {
            if (!HttpListener.IsSupported)
            {
                Console.WriteLine("Windows XP SP2 or Server 2003 is required to use the HttpListener class.");
                return;
            }
            string[] prefixes = { "http://localhost:17742/" };
            // Create a listener.
            HttpListener listener = new HttpListener();
            // Add the prefixes.
            foreach (string s in prefixes)
            {
                listener.Prefixes.Add(s);
            }
            listener.Start();
            Console.WriteLine("Listening...");
            // Note: The GetContext method blocks while waiting for a request. 
            while (true)
            {
                HttpListenerContext context = listener.GetContext();
                Parse(context);
            }
        }

        private void Parse(HttpListenerContext context)
        {
            string path = context.Request.RawUrl.Substring(1);

            if (path.StartsWith("colorKey"))
                ColorKey(context);
            if (path.StartsWith("colorAllKeyboard"))
                ColorAllKeyboard(context);
            if (path.StartsWith("options"))
                Options(context);
            if (path.StartsWith("update"))
                Options(context);

            HttpListenerRequest request = context.Request;
            // Obtain a response object.
            HttpListenerResponse response = context.Response;
            // Construct a response.
            string responseString = "Request received.";
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            // Get a response stream and write the response to it.
            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            // Close the output stream.
            output.Close();
        }

        private void Update(HttpListenerContext context)
        {
            Program.di.UpdateColors();
        }

        private void ColorKey(HttpListenerContext context)
        {
            HttpListenerRequest request = context.Request;
            if (request.RawUrl.Contains("&") && request.RawUrl.Contains("?") && request.RawUrl.Contains("="))
            {

                Dictionary<string, string> args = GetParams(request.RawUrl);
                if(args.ContainsKey("key") && args.ContainsKey("r") && args.ContainsKey("g") && args.ContainsKey("b"))
                {
                    try
                    {
                        Color color = new Color(Int32.Parse(args["r"]), Int32.Parse(args["g"]), Int32.Parse(args["b"]));
                        Program.di.ColorKey(args["key"], color);

                        if (autoUpdate)
                            Program.di.UpdateColors();
                    }
                    catch(Exception e)
                    {
                        
                    }
                }
            }
        }

        private void ColorAllKeyboard(HttpListenerContext context)
        {
            HttpListenerRequest request = context.Request;
            if (request.RawUrl.Contains("&") && request.RawUrl.Contains("?") && request.RawUrl.Contains("="))
            {

                Dictionary<string, string> args = GetParams(request.RawUrl);
                if (args.ContainsKey("r") && args.ContainsKey("g") && args.ContainsKey("b"))
                {
                    try
                    {
                        Color color = new Color(Int32.Parse(args["r"]), Int32.Parse(args["g"]), Int32.Parse(args["b"]));
                        Program.di.ColorAllKeys(color);

                        if (autoUpdate)
                            Program.di.UpdateColors();
                    }
                    catch (Exception e)
                    {

                    }
                }
            }
        }

        private void Options(HttpListenerContext context)
        {
            HttpListenerRequest request = context.Request;
            if (request.RawUrl.Contains("?") && request.RawUrl.Contains("="))
            {

                Dictionary<string, string> args = GetParams(request.RawUrl);
                if (args.ContainsKey("autoUpdate"))
                {
                    if (Boolean.Parse(args["autoUpdate"]))
                        autoUpdate = true;
                    else
                        autoUpdate = false;
                }
            }
        }
        private Dictionary<string, string> GetParams(string uri)
        {
            var matches = Regex.Matches(uri, @"[\?&](([^&=]+)=([^&=#]*))", RegexOptions.Compiled);
            var keyValues = new Dictionary<string, string>(matches.Count);
            foreach (Match m in matches)
                keyValues.Add(Uri.UnescapeDataString(m.Groups[2].Value), Uri.UnescapeDataString(m.Groups[3].Value));

            return keyValues;
        }
    }
}