using DatingApp2._0.Helpers;
using System.Text.Json;

namespace DatingApp2._0.Extensions
{
    public static class HttpExtensions
    {
        public static void AddPagenationHeader(this HttpResponse response, PaginationHeader header)
        {
            var jsonOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            response.Headers.Add("Pagination", JsonSerializer.Serialize(header, jsonOptions));
            response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
        }
    }
}
