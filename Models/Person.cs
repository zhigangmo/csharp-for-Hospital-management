using System;
public abstract class Person
{
    public int ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }

    public Person() { }

    public Person(string csvLine)
    {
        var values = csvLine.Split(',');
        ID = int.Parse(values[0]);
        FirstName = values[1];
        LastName = values[2];
        Email = values[3];
        Phone = values[4];
        Address = values[5];
    }

    public virtual string ToCSV()
    {
        return $"{ID},{FirstName},{LastName},{Email},{Phone},{Address}";
    }
}
