using System.Text.Json;
using System.Text.Json.Serialization;

namespace Probearbeit_Logistikbude.JsonHelpers;

class CustomNullableDateTimeConverter : JsonConverter<DateTime?>
{
    public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        if (string.IsNullOrEmpty(value))
        {
            return null;
        }

        return DateTime.Parse(value);
    }

    public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
    {
        if (value == null)
        {
            writer.WriteStringValue(string.Empty);
            return;
        }
        writer.WriteStringValue(value.Value.ToString("dd.MM.YYYY"));
    }
}