using GroceryMart.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace GroceryMart.WebAPI.Filter
{
    public class CustomAuthorizeFilter : AuthorizeAttribute
    {
        const string BasicAuthResponseHeader = "WWW-Authenticate";
        const string BasicAuthResponseHeaderValue = "Basic";

        IUnitOfWork uof = new UnitOfWork();

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            AuthenticationHeaderValue authValue = actionContext.Request.Headers.Authorization;

            if (authValue != null && !String.IsNullOrWhiteSpace(authValue.Parameter) && authValue.Scheme == BasicAuthResponseHeaderValue)
            {
                Credentials parsedCredentials = ParseAuthorizationHeader(authValue.Parameter);

                if (parsedCredentials != null)
                {
                    var user = uof.AuthenticateRepo.ValidateUser(parsedCredentials.Username, parsedCredentials.Password);
                    if (user != null)
                    {
                        if (!user.Roles.Any(r => Roles.Contains(r)))
                        {
                            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                            actionContext.Response.Headers.Add(BasicAuthResponseHeader, BasicAuthResponseHeaderValue);
                            return;
                        }
                    }
                    else
                    {
                        actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                        actionContext.Response.Headers.Add(BasicAuthResponseHeader, BasicAuthResponseHeaderValue);
                        return;
                    }
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                    actionContext.Response.Headers.Add(BasicAuthResponseHeader, BasicAuthResponseHeaderValue);
                    return;
                }
            }
            else
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                actionContext.Response.Headers.Add(BasicAuthResponseHeader, BasicAuthResponseHeaderValue);
                return;
            }
        }

        private Credentials ParseAuthorizationHeader(string authHeader)
        {
            string[] credentials = Encoding.Default
                                            .GetString(Convert.FromBase64String(authHeader))
                                            .Split(':');

            if (credentials.Length != 2 || string.IsNullOrEmpty(credentials[0]) || string.IsNullOrEmpty(credentials[1]))
                return null;

            return new Credentials() { Username = credentials[0], Password = credentials[1], };
        }
    }
   
}