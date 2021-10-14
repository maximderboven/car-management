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
            var program = new Program();
            program.Run();
        }

        private void Run()
        {
            byte n;
            do
            {
                Console.WriteLine("- Car Insurance -\nWhat would you like to do?\n==========================");
                Console.WriteLine(
                    "0) Quit\n1) Show all cars\n2) Show cars by Fuel \n3) Show all drivers \n4) All drivers with name and/or date of birth");
                Console.Write("Choice (0-5): ");
                n = Convert.ToByte(Console.ReadLine());
                switch (n)
                {
                    case 0:
                        break;
                    case 1:
                        Console.WriteLine("\nAll cars\n=========");
                        foreach (Car c in Manager.GetAllCars())
                        {
                            Console.WriteLine(c);
                        }
                        break;
                    case 2:
                        bool valid;
                        do
                        {
                            Console.Write("Fuel (");
                            Fuel[] enums = (Fuel[])Enum.GetValues (typeof(Fuel));
                            for (byte i = 0; i < enums.Length; i++) {
                                Console.Write(i+1 + "=" + enums[i] + ",");
                            }
                            Console.Write("\b): ");
                            valid = Int32.TryParse(Console.ReadLine() ?? string.Empty, out int fuelType);
                            if (!valid)
                                continue;
                            foreach (Car c in Manager.GetCarsBy((Fuel)fuelType)) {
                                Console.WriteLine(c);
                            }
                        } while (!valid);
                        break;

                    case 3:
                        Console.WriteLine("\nAll drivers\n=========");
                        foreach (Driver d in Manager.GetAllDrivers())
                        {
                            Console.WriteLine(d);
                        }
                        break;

                    case 4:
                        Console.WriteLine("\nAll drivers with name and/or date of birth\n=========");
                        Console.Write("Enter (part of) a name or leave blank:");
                        string name = Console.ReadLine();
                        Console.Write("Enter a full date (yyyy/mm/dd) or leave blank: ");
                        DateTime dob = DateTime.Parse(Console.ReadLine());
                        foreach (Driver d in Manager.GetAllDriversBy(name,dob))
                        {
                            Console.WriteLine(d);
                        }
                        break;

                    default:
                        Console.WriteLine($"{n} is not a valid option.");
                        break;
                }

                Console.WriteLine("\n\n");
            } while (n != 0);
            //Environment.Exit(0);
            //Auto exit cuz of end program
        }

        
    }
}