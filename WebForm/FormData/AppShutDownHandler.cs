using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormData
{
    // https://www.c-sharpcorner.com/blogs/implement-custom-httphandler-and-custom-httpmodule
    public class AppShutDownHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Write("<h1 style='Color:blue; font-size:15px;'>Our website is under maintainace. Please try after some time</h1>");
        }
    }
}