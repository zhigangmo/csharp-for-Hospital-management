
using System;
using System.IO;

namespace HospitalManagementSystem.Menus
{
public static class LoginMenu
{
    public enum UserTypes
    {
        None,
        Admin,
        Patient,
        Doctor
    }

    public static UserTypes UserType { get; private set; } = UserTypes.None;


public static void Show()
{
    int maxAttempts = 3;
    int currentAttempt = 0;

    Console.WriteLine("Welcome to the Login Page");

    while (currentAttempt < maxAttempts)
    {
        Console.Write("Enter your username: ");
        string username = Console.ReadLine();

        Console.Write("Enter your password: ");
        string password = MaskInputString();

        if (IsValidCredentials(username, password, "./Data/admins.txt"))
        {
            UserType = UserTypes.Admin;
            AdminMenu.Show(); // Assuming you have a static `Show` method in `AdminMenu`
            return;
        }
        else if (IsValidCredentials(username, password, "./Data/patients.txt"))
        {
            UserType = UserTypes.Patient;
            PatientMenu.Show(); // Same assumption
            return;
        }
        else if (IsValidCredentials(username, password, "./Data/doctors.txt"))
        {
            UserType = UserTypes.Doctor;
            DoctorMenu.Show(); // Same assumption
            return;
        }
        else
        {
            currentAttempt++;
            if (currentAttempt < maxAttempts)
            {
                Console.WriteLine($"Invalid credentials. You have {maxAttempts - currentAttempt} attempts left.");
            }
            else
            {
                Console.WriteLine("Too many failed attempts. Exiting...");
                Environment.Exit(0); // or however you want to handle this situation.
            }
        }
    }
}

private static bool IsValidCredentials(string username, string password, string filePath)
{
    string[] lines = File.ReadAllLines(filePath);
    foreach (string line in lines)
    {
        string[] parts = line.Split(',');
        
        if (filePath.EndsWith("patients.txt") && parts.Length >= 9 && parts[4] == username && parts[8] == password)
        {
            return true;
        }
        else if (filePath.EndsWith("doctors.txt") && parts.Length >= 5 && parts[3] == username && parts[4] == password)
        {
            return true;
        }
        else if (filePath.EndsWith("admins.txt") && parts.Length >= 2 && parts[0] == username && parts[1] == password)
        {
            return true;
        }
    }
    return false;
}

    public static string MaskInputString()
    {
        string input = string.Empty;
        ConsoleKeyInfo keyInfo;

        while (true)
        {
            keyInfo = Console.ReadKey(intercept: true);
            if (keyInfo.Key == ConsoleKey.Enter)
            {
                break;
            }
            else if (keyInfo.Key == ConsoleKey.Backspace && input.Length > 0)
            {
                Console.Write("\b \b");
                input = input.Remove(input.Length - 1);
            }
            else if (!char.IsControl(keyInfo.KeyChar))
            {
                Console.Write('*');  // Masking the input with an asterisk '*'
                input += keyInfo.KeyChar;
            }
        }

        Console.WriteLine();
        return input;
    }
}
}
