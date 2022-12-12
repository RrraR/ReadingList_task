using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ReadingList_task.Services.ViewModels;

public class BookOfUserViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public int Length { get; set; }
    public string Language { get; set; }
    public string Genre { get; set; }
    public string Series { get; set; }
    public bool IsFinished { get; set; }
    public DateOnly StartDate { get; set; }// = DateOnly.FromDateTime(DateTime.Today);
    public DateOnly? FinishDate { get; set; }
    public int ReadingPriority { get; set; }
    public ICollection<string> Collections { get; set; }
    public ICollection<string> Tags { get; set; } = null;
}

public class DateOnlyJsonConverter : JsonConverter<DateOnly>
{
    public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return DateOnly.Parse(reader.GetString()!);
    }

    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
    {
        var isoDate = value.ToString("O");
        writer.WriteStringValue(isoDate);
    }
}