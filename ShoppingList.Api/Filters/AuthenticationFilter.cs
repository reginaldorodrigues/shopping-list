using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading;
using System.Web;
using System.Web.Http.Filters;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace ShoppingList.Api.Filters
{
    public class AuthenticationFilter : Attribute, IAuthenticationFilter
    {
        public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            var request = context.Request;

            if (request.Headers.Authorization != null)
            {
                var authKey = request.Headers.Authorization.Parameter;
                var origKey = ConfigurationManager.AppSettings["ShoppingListApi.Key"];

                if (!string.IsNullOrEmpty(authKey) && authKey.Equals(origKey))
                    return Task.FromResult(0);
                
                throw new UnauthorizedAccessException("Request not authorized");
            }
            
            throw new UnauthorizedAccessException("Request not authorized");
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }

        public bool AllowMultiple
        {
            get { return false; }
        }
    }
}