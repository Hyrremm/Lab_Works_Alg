using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        List<LabData> labDatas = new List<LabData>
        {
            new LabData { Text = "Sample1", Value = 42, GenderValue = LabData.Gender.Male },
            new LabData { Text = "Sample2", Value = 55, GenderValue = LabData.Gender.Female },
            new LabData { Text = "Sample3", Value = 37, GenderValue = LabData.Gender.Unknown }
        };

        string filePath = "output.csv";
        WriteToCsv(filePath, labDatas);
        Console.WriteLine($"Data written to {filePath}");

        List<LabData> readLabDatas = ReadFromCsv(filePath);
        Console.WriteLine("Data read from CSV:");
        foreach (var data in readLabDatas)
        {
            Console.WriteLine($"{data.Text}, {data.Value}, {data.GenderValue}");
        }
    }

    static void WriteToCsv(string filePath, List<LabData> labDatas)
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
                LabData labData = LabData.FromCsv(line);
                labDatas.Add(labData);
            }
        }

        return labDatas;
    }
}

struct LabData
{
    public string Text { get; init; }
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

    public static LabData FromCsv(string csvLine)
    {
        string[] values = csvLine.Split(',');
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
        return labData;
    }

    public enum Gender
    {
        Male,
        Female,
        Unknown
    }
}
