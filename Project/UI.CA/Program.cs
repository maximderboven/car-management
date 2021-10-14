using System;
using System.Collections.Generic;
using System.Linq;
using Project.BL;
using Project.Domain;

namespace Project.UI.CA
{
    internal class Program
    {
        private static readonly IManager Manager = new Manager();

        public static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            byte n;
            do
            {
                Console.WriteLine("- Car Insurance -\nWhat would you like to do?\n==========================");
                PrintMenu();
                n = Convert.ToByte(Console.ReadLine());
                switch (n)
                {
                    case 0:
                        break;
                    case 1:
                        Console.WriteLine("\nAll cars\n=========");
                        PrintAllCars();
                        break;
                    case 2:
                        PrintEnumWithIndex();
                        PrintCarsByFuel(int.Parse(Console.ReadLine() ?? string.Empty));
                        break;

                    case 3:
                        Console.WriteLine("\nAll drivers\n=========");
                        PrintAllDrivers();
                        break;

                    case 4:
                        Console.WriteLine("\nAll drivers with name and/or date of birth\n=========");
                        PrintDriversByDateOrName();
                        break;

                    case 5:
                        Console.WriteLine("\nAdd a driver\n=========\n");
                        AddDriver();
                        break;
                    
                    case 6:
                        Console.WriteLine("\nAdd a car\n=========\n");
                        AddCar();
                        break;
                    
                    default:
                        Console.WriteLine($"{n} is not a valid option.");
                        break;
                }
            } while (n != 0);
            //Environment.Exit(0);
            //Auto exit cuz of end program
        }

        private static void PrintMenu()
        {
            Console.WriteLine(
                "0) Quit\n1) Show all cars\n2) Show cars by Fuel \n3) Show all drivers \n4) All drivers with name and/or date of birth\n5) Add a driver\n6) Add a car");
            Console.Write("Choice (0-6): ");
        }

        private static void PrintAllCars()
        {
            foreach (var c in Manager.GetAllCars())
            {
                Console.WriteLine(c);
            }
        }

        private static void PrintEnumWithIndex()
        {
            Console.Write("Fuel (");
            var enums = (Fuel[]) Enum.GetValues(typeof(Fuel));
            for (byte i = 0; i < enums.Length; i++)
            {
                Console.Write(i + 1 + "=" + enums[i] + ",");
            }
            Console.Write("\b): ");
        }

        private static void PrintCarsByFuel(int fuelType)
        {
            foreach (var c in Manager.GetCarsBy((Fuel) fuelType - 1))
            {
                Console.WriteLine(c);
            }
        }

        private static void PrintAllDrivers()
        {
            foreach (var d in Manager.GetAllDrivers())
            {
                Console.WriteLine(d);
            }
        }

        private static void PrintDriversByDateOrName()
        {
            Console.Write("Enter (part of) a name or leave blank:");
            var name = Console.ReadLine();
            Console.Write("Enter a full date (yyyy/mm/dd) or leave blank: ");
            var dob = DateTime.TryParse(Console.ReadLine() ?? "", out var tempdate)
                ? tempdate
                : default;
            foreach (var d in Manager.GetAllDriversBy(name, dob))
            {
                Console.WriteLine(d);
            }
        }

        private static void AddDriver()
        {
            try
            {
                Manager.AddDriver(ChooseFirstname(), ChooseLastName(), ChooseDateOfBirth());
                Console.WriteLine("Added new driver succesfully.");
            }
            catch (Exception e)
            {
                Console.Write("Unable to add new driver:");
                Console.WriteLine(e.Message);
            }
        }
        
        private static void AddCar()
        {
            try
            {
                Manager.AddCar(ChoosePurchasePrice(),ChooseBrand(),ChooseFuel(),ChooseSeats(),ChooseMileage(),ChooseGarage());
                Console.WriteLine("Added new car succesfully.");
            }
            catch (Exception e)
            {
                Console.Write("Unable to add new driver:");
                Console.WriteLine(e.Message);
            }
        }

        private static string ChooseLastName()
        {
            Console.Write("lastname: ");
            return Console.ReadLine();
        }
        private static string ChooseFirstname()
        {
            Console.Write("firstname: ");
            return Console.ReadLine();
        }
        private static DateTime ChooseDateOfBirth()
        {
            Console.Write("Date of birth (mm/dd/yyyy): ");
            return Convert.ToDateTime(Console.ReadLine());
        }
        private static int? ChoosePurchasePrice()
        {
            Console.Write("Purchase Price (optional): ");
            if(int.TryParse(Console.ReadLine(), out var n));
                return n;
            return null;
        }
        private static string ChooseBrand()
        {
            Console.Write("Brand:");
            return Console.ReadLine();
        }
        private static Fuel ChooseFuel()
        {
            Console.Write("Fuel:");
            PrintEnumWithIndex();
            return (Fuel) int.Parse(Console.ReadLine());
        }
        private static short ChooseSeats()
        {
            Console.WriteLine("Amount of seats:");
            return short.Parse(Console.ReadLine());
        }
        private static int ChooseMileage()
        {
            Console.WriteLine("Amount of seats:");
            return int.Parse(Console.ReadLine());
        }
        private static Garage ChooseGarage()
        {
            return null;
        }
    }
}