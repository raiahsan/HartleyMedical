using HartleyMedical.Application.Common.Settings;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace HartleyMedical.WebAPI.Configurations.CustomAuthentication
{
    public class ApiKeyAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        IHttpContextAccessor _httpContextAccessor;
        AppSettings _appSettings;
        public ApiKeyAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock,
        IHttpContextAccessor httpContextAccessor,
        IOptions<AppSettings> appSettings)
        : base(options, logger, encoder, clock)
        {
            _httpContextAccessor = httpContextAccessor;
            _appSettings = appSettings.Value;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            string apiToken = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];

            // If no authorization header found, nothing to process further
            if (!string.IsNullOrEmpty(apiToken))
            {
                if (apiToken.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                {
                    apiToken = apiToken.Substring("Bearer ".Length).Trim();
                }
                if (apiToken == _appSettings.APIKey)
                {
                    _httpContextAccessor.HttpContext.Items.Add("Name", "ApiUser");
                    var claims = new[] { new Claim(ClaimTypes.Name, "ApiUser") };
                    var identity = new ClaimsIdentity(claims, Scheme.Name);
                    var principal = new ClaimsPrincipal(identity);
                    var ticket = new AuthenticationTicket(principal, Scheme.Name);
                    return AuthenticateResult.Success(ticket);
                }
                else
                {
                    return AuthenticateResult.Fail("Api Key is incorrect");
                }
            }
            else
            {
                return AuthenticateResult.Fail("Api Key is incorrect");
            }
        }
    }
}
