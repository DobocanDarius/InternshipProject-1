using System.Text.Json;
using System.Text.Json.Serialization;

namespace UI.Helpers;

public static class HttpClientExtensions
{
    public static async Task<T> ReadContentAsync<T>(this HttpResponseMessage response)
    {
        if (response.IsSuccessStatusCode == false)
            throw new ApplicationException($"Something went wrong calling the API: {response.ReasonPhrase}");

        var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

        var result = JsonSerializer.Deserialize<T>(
            dataAsString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString
            });

        return result;
    }
}
