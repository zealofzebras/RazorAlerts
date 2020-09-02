using System;
using System.Text.Json;

namespace RazorAlerts.Extensions.Json
{
    public static class JsonExtensions
    {
        public static bool TryParseJson<T>(this string @this, out T result)
        {
            var options = new JsonSerializerOptions
            {
                AllowTrailingCommas = true
            };
            try
            {
                result = JsonSerializer.Deserialize<T>(@this, options);
                return true;
            } catch (Exception ex)
            {
                result = default(T);
                return false;
            }
        }
    }
}
