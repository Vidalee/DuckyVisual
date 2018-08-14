using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DuckyVisual
{
    class HTTPServer
    {

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

            if (path.StartsWith("key"))
                ColorKey(context);

        }

        private void ColorKey(HttpListenerContext context)
        {
            HttpListenerRequest request = context.Request;
            if (request.RawUrl.Contains("&") && request.RawUrl.Contains("?") && request.RawUrl.Contains("="))
            {

                Dictionary<string, string> args = GetParams(request.RawUrl);
                if(args.ContainsKey("key") && args.ContainsKey("r") && args.ContainsKey("g") && args.ContainsKey("b"))
                {
                    Console.WriteLine("zgc");

                    try
                    {
                        Console.WriteLine("zgd");
                        foreach (KeyValuePair<string, string> entry in args)
                        {
                            Console.WriteLine(entry.Key + " | " + entry.Value);
                        }
                        Color color = new Color(Int32.Parse(args["r"]), Int32.Parse(args["g"]), Int32.Parse(args["b"]));
                        Program.di.ColorKey(args["key"], color);
                        Program.di.UpdateColors();
                    }
                    catch(Exception e)
                    {
                        
                    }
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