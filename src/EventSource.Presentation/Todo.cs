using System.Text.Json.Serialization;

namespace EventSource.Application.Account
{
    public record Order(int Id);

    [JsonSerializable(typeof(Order[]))]
    public partial class AppJsonSerializerContext : JsonSerializerContext
    {

    }

}
