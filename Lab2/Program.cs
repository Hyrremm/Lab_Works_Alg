
using System.Collections;
using System.Text;

class Program
{
    static void Main()
    {
        string filePath = "output.csv";
        // Write to file init values
        List<LabData> labDatas = new List<LabData>
        {
            new LabData { Text = "Sample1", Value = 42, GenderValue = LabData.Gender.Male },
            new LabData { Text = "Sample2", Value = 55, GenderValue = LabData.Gender.Female },
            new LabData { Text = "Sample3", Value = 54, GenderValue = LabData.Gender.Unknown }
        };
        WriteToCsv(filePath, labDatas);
        Console.WriteLine($"Data written to {filePath}");
        // Read from file
        Console.WriteLine("Press any key read from the file.");
        PressKeyToContinue();
        List<LabData> readLabDatas = ReadFromCsv(filePath);
        Console.WriteLine("Data read from CSV:");
        foreach (var data in readLabDatas)
        {
            Console.WriteLine($"{data.Text}, {data.Value}, {data.GenderValue}");
        }
        // Modify
        Console.WriteLine($"Press any key to modify the file.");
        PressKeyToContinue();   
        readLabDatas = ReadFromCsv(filePath);
        readLabDatas[1] = readLabDatas[1] with { Text = "NEW COOL TEXT" };
        readLabDatas.Add(new LabData{ Text = "Sample4", Value = 45454, GenderValue = LabData.Gender.Male });
        WriteToCsv(filePath,readLabDatas);
        // Read again
        readLabDatas = ReadFromCsv(filePath);
        Console.WriteLine("Data read from CSV:");
        foreach (var data in readLabDatas)
        {
            Console.WriteLine($"{data.Text}, {data.Value}, {data.GenderValue}");
        }
    }

    static void PressKeyToContinue()
    {
        _ = Console.ReadKey();
        Console.WriteLine();
    }
    static void WriteToCsv(string filePath, IEnumerable<LabData> labDatas)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var data in labDatas)
            {
                writer.WriteLine(data.ToCsv());
            }
        }
    }

    static List<LabData> ReadFromCsv(string filePath)
    {
        List<LabData> labDatas = new List<LabData>();

        using (StreamReader reader = new StreamReader(filePath))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                (LabData result, bool success) = LabData.FromCsv(line);
                if(success) labDatas.Add(result);
                else Console.WriteLine($"Reading from CSV line \"{line}\" wasn't successful.");
            }
        }

        return labDatas;
    }
}


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
    
    public static (LabData,bool) FromCsv(string csvLine)
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
