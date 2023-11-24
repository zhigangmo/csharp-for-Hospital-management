
using System;
public class Administrator : Person
{
    public string Role { get; set; }

    public Administrator() : base() { }

    public Administrator(string csvLine) : base(csvLine)
    {
        var values = csvLine.Split(',');
        Role = values[6];
    }

    public override string ToCSV()
    {
        return $"{base.ToCSV()},{Role}";
    }
}
