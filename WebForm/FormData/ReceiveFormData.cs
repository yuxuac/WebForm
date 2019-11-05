using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace FormData
{
    public class ReceiveFormData : HttpSyncHandler
    {
        protected override void Post(HttpContext context)
        {
            //var content = GetReceivedContent(context);
            //OK(context.Response, content);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<h2>HttpMethod=POST</h2>");
            sb.AppendLine("<ul>");
            for (int i = 0; i < context.Request.Params.AllKeys.Length; i++)
            {
                sb.AppendLine("<li>" + context.Request.Params.AllKeys[i] + ":" + context.Request.Params[i] + "</li>");
            }
            sb.AppendLine("</ul>");
            OK(context.Response, sb.ToString());
        }

        protected override void Get(HttpContext context)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<h2>HttpMethod=GET</h2>");
            sb.AppendLine("<ul>");
            for (int i = 0; i < context.Request.Params.AllKeys.Length; i++)
            {
                sb.AppendLine("<li>" + context.Request.Params.AllKeys[i] + ":" + context.Request.Params[i] + "</li>");
            }
            sb.AppendLine("</ul>");
            OK(context.Response, sb.ToString());
            //base.Get(context);
        }
    }
}