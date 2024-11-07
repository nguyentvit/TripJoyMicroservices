using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UserAccess.Application.Extensions
{
    public class UserConverter : JsonConverter<User>
    {
        public override User? ReadJson(JsonReader reader, Type objectType, User? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            //if (reader.TokenType == JsonToken.Null)
            //    return null;

            //var user = serializer.Deserialize<JObject>(reader)!;

            //var userId = user["Id"]?["Value"]?.ToString();
            //var userName = user["UserName"]?["Value"]?.ToString();
            //var email = user["EmailAddress"]?["Value"]?.ToString();
            //var phone = user["Phone"]?["Value"]?.ToString();
            //var avatarUrl = user["Avatar"]?["Url"]?.ToString();
            //var avatarFormat = user["Avatar"]?["Format"]?.Value<int>();
            //var gender = user["Gender"]?.Value<int>();
            //var status = user["Status"]?.Value<int>();

            return serializer.Deserialize<User>(reader);
        }

        public override void WriteJson(JsonWriter writer, User? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
