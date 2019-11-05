using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormData
{
    public class ReceiveFormData : HttpSyncHandler
    {
        protected override void Post(HttpContext context)
        {
            var content = GetReceivedContent(context);
            OK(context.Response, content);
        }
    }
}