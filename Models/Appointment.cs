
using System;

public class Appointment
{
    public string Id { get; set; }
    public string PatientId { get; set; }
    public string DoctorId { get; set; }
    public DateTime AppointmentDate { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }  // e.g., "Scheduled", "Cancelled", "Completed"
    public TimeSpan Duration { get; set; }

    public Appointment() { }

    public Appointment(string csvLine)
    {
        var values = csvLine.Split(',');
        Id = values[0];
        PatientId = values[1];
        DoctorId = values[2];
        AppointmentDate = DateTime.Parse(values[3]);
        Description = values[4];
        Status = values[5];
        Duration = TimeSpan.FromMinutes(double.Parse(values[6]));
    }

    public string ToCSV()
    {
        return $"{Id},{PatientId},{DoctorId},{AppointmentDate},{Description},{Status},{Duration.TotalMinutes}";
    }
}
