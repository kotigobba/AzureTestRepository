using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

namespace NorthwindTradersWebApp.Infrastructure
{
    public static class ConvertData
    {
        public static string ObjectToJsonString<T>(T input)
        {
            string output = JsonSerializer.Serialize<T>(input);
            return output;
        }
        public static T JsonStringToObject<T>(string input)
        {
            T obj = JsonSerializer.Deserialize<T>(input)!;
            return obj!;
        }
    }
}
