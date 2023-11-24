
using System;
public class Patient : Person
{
    public string BloodType { get; set; }
    public string PhoneNumber { get; set; }

    public Patient() : base() { }

    public Patient(string csvLine) : base(csvLine)
    {
        var values = csvLine.Split(',');
        BloodType = values[6];
    }

    public override string ToCSV()
    {
        return $"{base.ToCSV()},{BloodType}";
    }
}
