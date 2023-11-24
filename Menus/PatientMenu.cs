
using System;
using HospitalManagementSystem.Utils;
using System.Collections.Generic;
using System.Linq;

namespace HospitalManagementSystem.Menus
{
    public static class PatientMenu
    {
        public static void Show()
        {
            while (true)
            {
                Console.WriteLine("DOTNET Hospital Management System");
                Console.WriteLine("Patient Menu:");
                Console.WriteLine("Please choose an option:");
                Console.WriteLine("1. List patient details");
                Console.WriteLine("2. List my doctor details");
                Console.WriteLine("3. List all appointments");
                Console.WriteLine("4. Book appointment");
                Console.WriteLine("5. Exit to login");
                Console.WriteLine("6. Exit System");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ListPatientDetails();
                        break;
                    case "2":
                        ListMyDoctorDetails();
                        break;
                    case "3":
                        ListAllAppointments();
                        break;
                    case "4":
                        BookAppointment();
                        break;
                    case "5":
                        return;
                    case "6":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }

        private static void ListPatientDetails()
        {
            var patientDetails = FileManager.ReadFromFile("patients.txt");
            Console.WriteLine("Patient Details:");
            DisplayHeader();
            foreach (var detail in patientDetails)
            {
                DisplayFormattedDetail(detail);
            }
        }

        private static void ListMyDoctorDetails()
        {
            // Assuming there is some mechanism to identify the patient's doctor.
            // For now, this function lists all doctors, which needs refinement.
            var doctorDetails = FileManager.ReadFromFile("doctors.txt");
            Console.WriteLine("Your Doctor's Details:");
            foreach (var detail in doctorDetails)
            {
                Console.WriteLine(detail);
            }
        }

        private static void ListAllAppointments()
        {
            var appointmentDetails = FileManager.ReadFromFile("appointments.txt");
            Console.WriteLine("All Appointments:");
            foreach (var detail in appointmentDetails)
            {
                Console.WriteLine(detail);
            }
        }

        private static void BookAppointment()
        {
            Console.WriteLine("Enter desired date for appointment (format: yyyy-MM-dd):");
            DateTime date;
            while (!DateTime.TryParse(Console.ReadLine(), out date))
            {
                Console.WriteLine("Invalid format. Please enter the date in the format yyyy-MM-dd:");
            }

            Console.WriteLine("Enter Description for the appointment:");
            string description = Console.ReadLine();

            // Creating the newAppointment object here
            Appointment newAppointment = new Appointment
            {
                AppointmentDate = date,
                Description = description
                // ... assign other fields
            };

            // Now, use the newAppointment variable 
            string appointmentData = newAppointment.ToCSV();
            FileManager.AppendToFile("appointments.txt", appointmentData); 
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
