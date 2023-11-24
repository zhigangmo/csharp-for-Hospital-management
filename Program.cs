
using System;
using HospitalManagementSystem.Menus;

namespace HospitalManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hospital Management System");

            // Directly call the login menu without checking its return
            LoginMenu.Show();
            MainMenu();
        }

        static void MainMenu()
        {
            while (true)
            {
                Console.WriteLine("Main Menu:");
                Console.WriteLine("1. Patient Menu");
                Console.WriteLine("2. Doctor Menu");
                Console.WriteLine("3. Admin Menu");
                Console.WriteLine("4. Exit");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        PatientMenu.Show();
                        break;
                    case "2":
                        DoctorMenu.Show();
                        break;
                    case "3":
                        AdminMenu.Show();
                        break;
                    case "4":
                        Console.WriteLine("Thank you for using the Hospital Management System.");
                        return;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }
    }
}
