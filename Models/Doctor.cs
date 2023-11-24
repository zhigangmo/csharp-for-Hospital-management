
using System;
namespace HospitalManagementSystem.Models
{
public class Doctor : Person
{
    public string Specialization { get; set; }
    public int YearsOfExperience { get; set; }
    public string PhoneNumber { get; set; }

    public Doctor() : base() { }

    public Doctor(string csvLine) : base(csvLine)
    {
        var values = csvLine.Split(',');
        Specialization = values[6];
        YearsOfExperience = int.Parse(values[7]);
    }

    public override string ToCSV()
    {
        return $"{base.ToCSV()},{Specialization},{YearsOfExperience}";
    }
}
}
