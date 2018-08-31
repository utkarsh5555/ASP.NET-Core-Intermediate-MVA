using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace ASP.NET_Core___Intermediate__MVA_
{
    internal class CanadianRequirement : AuthorizationHandler<CanadianRequirement>,IAuthorizationRequirement
    {
        public CanadianRequirement() { }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CanadianRequirement requirement)
        {
            if (context.User.IsInRole("Admin"))
            {
                context.Succeed(requirement);
            }
            if(context.User.HasClaim(claim=>claim.ValueType==ClaimTypes.Country && claim.Value == "Canada"))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}