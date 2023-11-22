using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace webApi
{
    public class BasicAuthenticationAttributeAdmin : AuthorizationFilterAttribute


    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if(actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
                string decodeAuthenticationToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));
                string[] usernamePassArray = decodeAuthenticationToken.Split(':');
                string userName = usernamePassArray[0];
                string password = usernamePassArray[1];

                if(TmSecurityClass.AdminLogIn(userName,password))
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(userName, password), null);
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
        }
    }
}