using System;
using Microsoft.Owin;

namespace Owin03_Middleware {

    public class LogRequestsMiddleware : OwinMiddleware  {

        public LogRequestsMiddleware(RequestDelegate next, string label) : base()
    }
}

