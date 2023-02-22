using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using CoolLibrary.BLL.Exceptions;

namespace CoolLibrary.WebAPI.Middleware
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class ApiKeyAttribute : Attribute, IAuthorizationFilter
    {
        private const string API_KEY_QUERY_NAME = "secret";

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var submittedApiKey = GetSubmittedApiKey(context.HttpContext);

            var apiKey = GetApiKey(context.HttpContext);

            if (!IsApiKeyValid(apiKey, submittedApiKey))
            {
                throw new UnauthorizedException();
            }
        }

        private static string GetSubmittedApiKey(HttpContext context)
        {
            return context.Request.Query[API_KEY_QUERY_NAME];
        }

        private static string GetApiKey(HttpContext context)
        {
            var configuration = context.RequestServices.GetRequiredService<IConfiguration>();

            return configuration.GetValue<string>($"Secret:Key");
        }

        private static bool IsApiKeyValid(string apiKey, string submittedApiKey)
        {
            if (string.IsNullOrEmpty(submittedApiKey)) return false;

            var apiKeySpan = MemoryMarshal.Cast<char, byte>(apiKey.AsSpan());

            var submittedApiKeySpan = MemoryMarshal.Cast<char, byte>(submittedApiKey.AsSpan());

            return CryptographicOperations.FixedTimeEquals(apiKeySpan, submittedApiKeySpan);
        }
    }
}