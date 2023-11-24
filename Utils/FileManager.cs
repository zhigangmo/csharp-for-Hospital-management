
using System;
using System.Collections.Generic;
using System.IO;

public static class FileManager
{
    private const string DataPath = "./Data/";

    public static List<string> ReadFromFile(string fileName)
    {
        string path = DataPath + fileName;
        try
        {
            if (!File.Exists(path))
                return new List<string>();
            return new List<string>(File.ReadAllLines(path));
        }
        catch (IOException ex)
        {
            // Log the exception
            Console.WriteLine($"Error reading from file: {ex.Message}");
            return null;  // or handle this more gracefully
        }
    }

    public static void WriteToFile(string fileName, List<string> data)
    {
        string path = DataPath + fileName;
        try
        {
            File.WriteAllLines(path, data);
        }
        catch (IOException ex)
        {
            // Log the exception
            Console.WriteLine($"Error writing to file: {ex.Message}");
        }
    }

    public static void AppendToFile(string fileName, string content)
    {
        string path = DataPath + fileName;
        try
        {
            using (StreamWriter writer = File.AppendText(path))
            {
                writer.WriteLine(content);
            }
        }
        catch (IOException ex)
        {
            // Log the exception
            Console.WriteLine($"Error appending to file: {ex.Message}");
        }
    }
}
