using System.Text.Json;
using System.Text.Json.Serialization;
using System.Globalization;

namespace DogShow.Modules.JsonConverters
{
    public class TimeOnlyJsonConverter : JsonConverter<TimeOnly>
    {
        public override TimeOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            if (string.IsNullOrWhiteSpace(value))
            {
                return default;
            }

            // Try standard formats including HH:mm
            if (TimeOnly.TryParse(value, CultureInfo.InvariantCulture, DateTimeStyles.None, out var result))
            {
                return result;
            }

            throw new JsonException($"Unable to convert \"{value}\" to {nameof(TimeOnly)}.");
        }

        public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions options)
        {
            // Write as HH:mm to be safe and consistent with input
            writer.WriteStringValue(value.ToString("HH:mm"));
        }
    }
}
