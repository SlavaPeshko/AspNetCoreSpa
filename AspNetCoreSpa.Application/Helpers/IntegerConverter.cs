using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AspNetCoreSpa.Application.Helpers
{
    public class IntegerConverter : JsonConverter<int>
    {
        public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (int.TryParse(reader.GetString(), out int result))
            {
                return result;
            }
            
            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
        {

        }
    }
}