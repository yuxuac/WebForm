using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FormData
{
    // https://www.c-sharpcorner.com/blogs/implement-custom-httphandler-and-custom-httpmodule
    public class CustomLoggerHttpModule : IHttpModule
    {
        private StreamWriter sw;
        private static string logdir = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "log");
        private string filePath = Path.Combine(logdir, @"log.txt");

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += Context_BeginRequest;
            context.EndRequest += Context_EndRequest;
        }

        private void Context_EndRequest(object sender, EventArgs e)
        {
            if (!Directory.Exists(logdir))
                Directory.CreateDirectory(logdir);

            if (!File.Exists(filePath))
            {
                sw = new StreamWriter(filePath);
            }
            else
            {
                sw = File.AppendText(filePath);
            }
            sw.WriteLine("User request completed at {0}", DateTime.UtcNow);
            sw.Close();
        }

        private void Context_BeginRequest(object sender, EventArgs e)
        {
            if (!Directory.Exists(logdir))
                Directory.CreateDirectory(logdir);

            if (!File.Exists(filePath))
            {
                sw = new StreamWriter(filePath);
            }
            else
            {
                sw = File.AppendText(filePath);
            }
            sw.WriteLine("User sent request at {0}", DateTime.UtcNow);
            sw.Close();
        }
    }
}