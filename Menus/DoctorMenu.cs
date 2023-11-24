
using System;
using System.Collections.Generic;
using HospitalManagementSystem.Utils;

namespace HospitalManagementSystem.Menus
{
    public static class DoctorMenu
    {
        public static void Show()
        {
            while (true) 
            {
                Console.WriteLine("DOTNET Hospital Management System");
                Console.WriteLine("Doctor Menu:");
                Console.WriteLine("1. List doctor details");
                Console.WriteLine("2. List patients");
                Console.WriteLine("3. List appointments");
                Console.WriteLine("4. Check particular patient");
                Console.WriteLine("5. List appointments with patient");
                Console.WriteLine("6. Exit");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ListDoctorDetails();
                        break;
                    case "2":
                        ListPatients();
                        break;
                    case "3":
                        ListAppointments();
                        break;
                    case "4":
                        CheckParticularPatient();
                        break;
                    case "5":
                        ListAppointmentsWithPatient();
                        break;
                    case "6":
                        return; 
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }

        private static void ListDoctorDetails()
        {
            var doctorDetails = FileManager.ReadFromFile("doctors.txt");
            Console.WriteLine("Your Details:");
            DisplayHeader();
            foreach (var detail in doctorDetails)
            {
                DisplayFormattedDetail(detail);
            }
        }

        private static void ListPatients()
        {
            var patientDetails = FileManager.ReadFromFile("patients.txt");
            Console.WriteLine("List of all Patients:");
            DisplayHeader();
            foreach (var detail in patientDetails)
            {
                DisplayFormattedDetail(detail);
            }
        }

        private static void ListAppointments()
        {
            var appointmentDetails = FileManager.ReadFromFile("appointments.txt");
            Console.WriteLine("Your Appointments:");
            foreach (var detail in appointmentDetails)
            {
                Console.WriteLine(detail);
            }
        }

        private static void CheckParticularPatient()
        {
            Console.WriteLine("Enter patient ID or name to view details:");
            string input = Console.ReadLine();

            var patientDetails = FileManager.ReadFromFile("patients.txt");
            foreach (var detail in patientDetails)
            {
                if (detail.Contains(input))
                {
                    DisplayFormattedDetail(detail);
                }
            }
        }

        private static void ListAppointmentsWithPatient()
        {
            Console.WriteLine("Enter patient ID or name to view appointments:");
            string input = Console.ReadLine();

            var appointmentDetails = FileManager.ReadFromFile("appointments.txt");
            foreach (var detail in appointmentDetails)
            {
                if (detail.Contains(input))
                {
                    Console.WriteLine(detail);
                }
            }
        }

        private static void DisplayHeader()
        {
            var columns = new string[] { "ID", "First Name", "Last Name", "Email", "Phone", "Address" };
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
