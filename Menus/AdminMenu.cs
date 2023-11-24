
using System;
using System.Collections.Generic;
using System.Linq;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Utils;

namespace HospitalManagementSystem.Menus
{
    public static class AdminMenu
    {
        public static void Show()
        {
            Console.WriteLine("DOTNET Hospital Management System-----------------------");

            while (true)
            {
                Console.WriteLine("Admin Menu:");
                Console.WriteLine("1. List All Doctors");
                Console.WriteLine("2. Check Doctor Details");
                Console.WriteLine("3. List All Patients");
                Console.WriteLine("4. Check Patient Details");
                Console.WriteLine("5. Add Doctor");
                Console.WriteLine("6. Add Patient");
                Console.WriteLine("7. Exit");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ListAllDoctors();
                        break;
                    case "2":
                        CheckDoctorDetails();
                        break;
                    case "3":
                        ListAllPatients();
                        break;
                    case "4":
                        CheckPatientDetails();
                        break;
                    case "5":
                        AddDoctor();
                        break;
                    case "6":
                        AddPatient();
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }

        private static void AddDoctor()
        {
            Console.WriteLine("First Name:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Last Name:");
            string lastName = Console.ReadLine();

            Console.WriteLine("Email:");
            string email = Console.ReadLine();

            Console.WriteLine("Phone:");
            string phone = Console.ReadLine();

            Console.WriteLine("street Number:");
            string streetNumber = Console.ReadLine();

            Console.WriteLine("Street:");
            string street = Console.ReadLine();

            Console.WriteLine("city:");
            string city = Console.ReadLine();

            Console.WriteLine("State:");
            string state = Console.ReadLine();

            Doctor newDoctor = new Doctor
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phone
                // You'll need to add the rest of the fields here
            };

            // Only appending to the file
            FileManager.AppendToFile("doctors.txt", newDoctor.ToCSV());
            Console.WriteLine($"Dr {firstName} {lastName} added to the system!");
        }

        private static void AddPatient()
        {
            Console.WriteLine("First Name:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Last Name:");
            string lastName = Console.ReadLine();

            Console.WriteLine("Email:");
            string email = Console.ReadLine();

            Console.WriteLine("Phone:");
            string phone = Console.ReadLine();

            Console.WriteLine("street Number:");
            string streetNumber = Console.ReadLine();

            Console.WriteLine("Street:");
            string street = Console.ReadLine();

            Console.WriteLine("city:");
            string city = Console.ReadLine();

            Console.WriteLine("State:");
            string state = Console.ReadLine();

            Patient newPatient = new Patient
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phone
                // You'll need to add the rest of the fields here
            };

            // Only appending to the file
            FileManager.AppendToFile("patients.txt", newPatient.ToCSV());
        }

        private static void CheckDoctorDetails()
        {
            Console.WriteLine("Enter Doctor's ID or Name to check details:");
            var searchTerm = Console.ReadLine().ToLower();

            var doctorDetails = FileManager.ReadFromFile("doctors.txt");
            foreach (var detail in doctorDetails)
            {
                if (detail.ToLower().Contains(searchTerm))
                {
                    DisplayFormattedDetail(detail);
                    return;
                }
            }

            Console.WriteLine($"No doctor found with ID or Name: {searchTerm}");
        }

        private static void CheckPatientDetails()
        {
            Console.WriteLine("Enter Patient's ID or Name to check details:");
            var searchTerm = Console.ReadLine().ToLower();

            var patientDetails = FileManager.ReadFromFile("patients.txt");
            foreach (var detail in patientDetails)
            {
                if (detail.ToLower().Contains(searchTerm))
                {
                    DisplayFormattedDetail(detail);
                    return;
                }
            }

            Console.WriteLine($"No patient found with ID or Name: {searchTerm}");
        }

        private static void ListAllDoctors()
        {
            var doctorDetails = FileManager.ReadFromFile("doctors.txt");
            Console.WriteLine("Doctors List:");
            DisplayHeader();
            foreach (var detail in doctorDetails)
            {
                DisplayFormattedDetail(detail);
            }
        }

        private static void ListAllPatients()
        {
            var patientDetails = FileManager.ReadFromFile("patients.txt");
            Console.WriteLine("Patients List:");
            DisplayHeader();
            foreach (var detail in patientDetails)
            {
                DisplayFormattedDetail(detail);
            }
        }

        private static void DisplayHeader()
        {
            var columns = new string[] { "ID", "First Name", "Last Name", "Email", "Phone", "Address", "Blood Type" };
            Console.WriteLine(string.Join(" | ", columns.Select(col => col.PadRight(20))));
            Console.WriteLine(new string('-', columns.Length * 21));
        }

        private static void DisplayFormattedDetail(string detail)
        {
            var parts = detail.Split(',');
            Console.WriteLine(string.Join(" | ", parts.Select(part => part.PadRight(20))));
            Console.WriteLine(new string('-', parts.Length * 21));
        }
    }
}
