using System.Text;

namespace Lab2;

struct LabData
{
    private string _text;
    public string Text
    {
        get => _text;
        init
        {
            _text = value;

            if (_text is null)
            {
                throw new ArgumentException("Text cannot be null.");
            }

            if (_text.Contains(","))
            {
                throw new ArgumentException("Text cannot contain a comma.");
            }
        }
    }

    public int Value { get; init; } 
    public Gender GenderValue { get; init; }

    public string TextToCsv() => Text;

    public string ValueToCsv() => Value.ToString();

    public string GenderToCsv()
    {
        return GenderValue switch
        {
            Gender.Male => "M",
            Gender.Female => "F",
            _ => "U"
        };
    }

    public string ToCsv() => $"{TextToCsv()},{ValueToCsv()},{GenderToCsv()}";

    public static string ToCsvSpan(IEnumerable<LabData> arr)
    {
        StringBuilder stringBuilder = new("");
        foreach (var labData in arr)
        {
            stringBuilder.AppendLine(labData.ToCsv());
        }

        return stringBuilder.ToString();
    }

    public static string TextFromCsv(string csvLine)
    {
        string[] values = csvLine.Split(',');
        return values[0];
    }
    public static int ValueFromCsv(string csvLine)
    {
        string[] values = csvLine.Split(',');
        return int.Parse(values[1]);
    }

    public static Gender GenderFromCsv(string csvLine)
    {
        string[] values = csvLine.Split(',');
        return values[2] switch
        {
            "M" => Gender.Male,
            "F" => Gender.Female,
            _ => Gender.Unknown
        };
    }
    
    public static (LabData value, bool success) FromCsv(string csvLine)
    {
        string[] values = csvLine.Split(',');
        LabData result = new LabData();
        bool success = false;
        try
        {
            if (values.Length != typeof(LabData).GetProperties().Length)
            {
                throw new ArgumentException("There are exceeding number of ','");
            }
            LabData labData = new LabData
            {
                Text = values[0],
                Value = int.Parse(values[1]),
                GenderValue = values[2] switch
                {
                    "M" => Gender.Male,
                    "F" => Gender.Female,
                    _ => Gender.Unknown
                }
            };
            
            result = labData;
            success = true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error parsing csv to LabData. {ex.Message}");
        }

        return (result, success);
    }

    public enum Gender
    {
        Male,
        Female,
        Unknown
    }
}