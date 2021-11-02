using System;
using System.Linq;
using Insurance.BL;
using Insurance.DAL.EF;
using Insurance.Domain;
using Insurance.UI.CA.Extensions;

namespace Insurance.UI.CA
{
    internal class Program
    {
        private readonly IManager _manager;

        private Program()
        {
            //_manager = new Manager(new InMemoryRepository());
            _manager = new Manager(new Repository());
        }

        public static void Main(string[] args)
        {
            new Program().Run();
        }

        private void Run()
        {
            byte n;
            do
            {
                Console.WriteLine("\n- Car Insurance -\nWhat would you like to do?\n==========================");
                PrintMenu();
                n = byte.Parse(Console.ReadLine() ?? "7");
                Console.ResetColor();
                switch (n)
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Goodbye.");
                        break;
                    case 1:
                        PrintAllCars();
                        break;
                    case 2:
                        PrintEnumWithIndex();
                        PrintCarsByFuel(int.Parse(Console.ReadLine() ?? string.Empty));
                        break;

                    case 3:
                        PrintAllDrivers();
                        break;

                    case 4:
                        PrintDriversByDateOrName();
                        break;

                    case 5:
                        AddDriver();
                        break;

                    case 6:
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
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Choice (0-6): ");
            Console.ResetColor();
        }

        private void PrintAllCars()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nAll cars\n=========");
            foreach (var c in _manager.GetAllCars())
            {
                Console.WriteLine(c.GetInfo());
            }

            Console.ResetColor();
        }

        private void PrintEnumWithIndex()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Fuel (");
            var enums = (Fuel[]) Enum.GetValues(typeof(Fuel));
            for (byte i = 0; i < enums.Length; i++)
            {
                Console.Write(i + 1 + "=" + enums[i] + ",");
            }

            Console.Write("\b): ");
        }

        private void PrintGaragesWithIndex()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            var garages = _manager.GetAllGarages().ToList();
            for (var i = 0; i < garages.Count; i++)
            {
                Console.Write(i+1 + " -> " + garages[i].GetInfo() + "\n");
            }
        }

        private void PrintCarsByFuel(int fuelType)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var c in _manager.GetCarsBy((Fuel) fuelType - 1))
            {
                Console.WriteLine(c.GetInfo());
            }

            Console.ResetColor();
        }

        private void PrintAllDrivers()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nAll drivers\n=========");
            foreach (var d in _manager.GetAllDrivers())
            {
                Console.WriteLine(d.GetInfo());
            }

            Console.ResetColor();
        }

        private void PrintDriversByDateOrName()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nAll drivers with name and/or date of birth\n=========");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Enter (part of) a name or leave blank:");
            Console.ResetColor();
            string? name = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Enter a full date (yyyy/mm/dd) or leave blank: ");
            Console.ResetColor();
            DateTime.TryParse(Console.ReadLine(), out DateTime date);

            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var d in _manager.GetAllDriversBy(name, date))
            {
                Console.WriteLine(d.GetInfo());
            }

            Console.ResetColor();
        }

        private void AddDriver()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nAdd a driver\n=========\n");
            bool pass = false;
            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("firstname: ");
                Console.ResetColor();
                var firstname = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("lastname: ");
                Console.ResetColor();
                var lastname = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Date of birth (mm/dd/yyyy): ");
                Console.ResetColor();
                DateTime.TryParse(Console.ReadLine(), out DateTime dob);
                try
                {
                    _manager.AddDriver(firstname, lastname, dob);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Added new driver succesfully.");
                    pass = true;
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Unable to add new driver:");
                    Console.WriteLine(e.Message);
                }
            } while (!pass);

            Console.ResetColor();
        }

        private void AddCar()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nAdd a car\n=========\n");
            var pass = false;
            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Purchase Price (optional): ");
                Console.ResetColor();

                int.TryParse(Console.ReadLine(), out int pprice);

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Brand:");
                Console.ResetColor();
                string brand = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Fuel:");
                PrintEnumWithIndex();
                Console.ResetColor();
                int.TryParse(Console.ReadLine(), out int fuel);
                Fuel f = (Fuel) fuel - 1;

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Amount of seats:");
                Console.ResetColor();
                short.TryParse(Console.ReadLine(), out short amount);

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Amount of miles on count:");
                Console.ResetColor();
                int.TryParse(Console.ReadLine(), out int miles);

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Choose garage:");
                PrintGaragesWithIndex();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Garage: ");
                Console.ResetColor();
                int.TryParse(Console.ReadLine(), out int garage);
                var g = _manager.GetAllGarages().ToList()[garage-1];
                try
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    _manager.AddCar(pprice, brand, f, amount, miles, g);
                    Console.WriteLine("Added new car succesfully.");
                    pass = true;
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Unable to add new car:");
                    Console.WriteLine(e.Message);
                }
            } while (!pass);

            Console.ResetColor();
        }
    }
}