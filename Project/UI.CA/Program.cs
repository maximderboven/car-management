using System;
using System.Collections.Generic;
using System.Linq;
using Project.Domain;

namespace Project.UI.CA
{
    internal class Program
    {

        public static void Main(string[] args)
        {
            var program = new Program();
            program.Run();
        }

        private void Run()
        {
            Seed();
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
                        foreach (Car c in _cars)
                        {
                            Console.WriteLine(c);
                        }

                        break;

                    case 2:
                        bool valid;
                        do
                        {
                            Console.Write("Fuel (");
                            for (byte i = 0; i < Enum.GetNames(typeof(Fuel)).Length; i++)
                            {
                                Console.Write(i+1 + "=" + Enum.GetNames(typeof(Fuel))[i] + ",");
                            }

                            Console.Write("\b): ");
                            valid = Int32.TryParse(Console.ReadLine(), out int f);
                            foreach (var c in _cars.Where(c => c.Fuel.Equals((Fuel) f-1)))
                            {
                                Console.Write(c+ "\n");
                            }
                        } while (!valid);

                        break;

                    case 3:
                        Console.WriteLine("\nAll drivers\n=========");
                        foreach (Driver d in _drivers)
                        {
                            Console.WriteLine(d);
                        }

                        break;

                    case 4:
                        Console.WriteLine("\nAll drivers with name and/or date of birth\n=========");
                        Console.Write("Enter (part of) a name or leave blank:");
                        string name = Console.ReadLine();
                        Console.Write("Enter a full date (yyyy/mm/dd) or leave blank: ");
                        string dob = Console.ReadLine();
                        foreach (Driver d in
                            _drivers.Where(d =>
                                ((name == null) ||
                                 (d.FirstName + " " + d.LastName).ToLower().Contains(name.ToLower())) && (
                                    dob is null or "" || (d.DateOfBirth.Date == Convert.ToDateTime(dob).Date))))
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