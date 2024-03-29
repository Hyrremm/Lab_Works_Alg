﻿namespace Lab2;

internal class Program
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
        (List<LabData> readLabDatas, bool success)  = ReadFromCsv(filePath);
        if(!success) Console.WriteLine("The attempt to read data lead to errors");
        Console.WriteLine("Data read from CSV:");
        foreach (var data in readLabDatas)
        {
            Console.WriteLine($"{data.Text}, {data.Value}, {data.GenderValue}");
        }
        // Modify
        Console.WriteLine($"Press any key to modify the file.");
        PressKeyToContinue();   
        (readLabDatas,  success)  = ReadFromCsv(filePath);
        if(!success) Console.WriteLine("The attempt to read data lead to errors");      
        readLabDatas[1] = readLabDatas[1] with { Text = "NEW COOL TEXT" };
        readLabDatas.Add(new LabData{ Text = "Sample4", Value = 45454, GenderValue = LabData.Gender.Male });
        WriteToCsv(filePath,readLabDatas);
        // Read again
        (readLabDatas,  success)  = ReadFromCsv(filePath);
        if(!success) Console.WriteLine("The attempt to read data lead to errors");      
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

    static (List<LabData> list,bool success) ReadFromCsv(string filePath)
    {
        List<LabData> labDatas = new List<LabData>();
        bool successToReturn = true;

        using (StreamReader reader = new StreamReader(filePath))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine()!;
                var (result, success) = LabData.FromCsv(line);
                if(success) labDatas.Add(result);
                else
                {
                    successToReturn = false;
                    Console.WriteLine($"Reading from CSV line \"{line}\" wasn't successful.");
                }
            }
        }

        return (labDatas,successToReturn);
    }
}