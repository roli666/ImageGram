using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ImageGram.Core.Helpers
{
    public class Base64FileJsonConverter : JsonConverter<byte[]>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert == typeof(byte[]);
        }

        public override byte[] Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.GetBytesFromBase64();
        }

        public override void Write(Utf8JsonWriter writer, byte[] value, JsonSerializerOptions options) => writer.WriteStringValue(value.ToString());
    }
}