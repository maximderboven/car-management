﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;

namespace CA
{
    class Program
    {
        private List<Driver> _drivers;
        private List<Car> _cars;

        static void Main(string[] args)
        {
            var program = new Program();
            program.Run();
        }

        void Run()
        {
            Seed();
            byte n;
            do
            {
                Console.WriteLine("- Maxim's Car Insurancy -\nWhat would you like to do?\n==========================");
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
                                Console.Write(i + "=" + Enum.GetNames(typeof(Fuel))[i] + ",");
                            }

                            Console.Write("\b): ");
                            valid = Int32.TryParse(Console.ReadLine(), out int f);
                            foreach (Car c in _cars)
                            {
                                if (c.Fuel.Equals((Fuel) f))
                                {
                                    Console.Write(c);
                                }
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
                        foreach (Driver d in _drivers.Where(d => (name == null || (d.FirstName + d.LastName).ToLower().Contains(name)) || (
                            (dob == null) || ((dob != null) ? d.DateOfBirth == Convert.ToDateTime(dob).Date : false))))
                        {
                            Console.WriteLine(d);
                        }

                        break;

                    default:
                        Console.WriteLine("");
                        break;
                }

                Console.WriteLine("\n\n");
            } while (n != 0);
            //Environment.Exit(0);
        }

        void Seed()
        {
            //init lists
            _drivers = new List<Driver>();
            _cars = new List<Car>();

            _drivers.Add(new Driver("Andy", "Kost", 86528736, new DateTime(1994, 1, 5)));
            _drivers.Add(new Driver("Jilles", "Frieling", 31121614, new DateTime(1983, 5, 17)));
            _drivers.Add(new Driver("Luite", "Poel", 42585915, new DateTime(1958, 10, 12)));
            _drivers.Add(new Driver("Caroliene", "Karremans", 39606540, new DateTime(1945, 8, 7)));

            Garage g1 = new Garage("PSA retail", "Boomsesteenweg 894", "+3238719811");
            Garage g2 = new Garage("Van Dessel", "Mortsel", "+3234403236");

            _cars.Add(new Car("Citroen", "1YKB221", Fuel.GAS, 4, 0, g1));
            _cars.Add(new Car(10000, "Opel", "1DHZ264", Fuel.GAS, 6, 0, g1));
            _cars.Add(new Car("Audi", "2YGZ291", Fuel.OIL, 5, 5000, g2));
            _cars.Add(new Car(35540, "BMW", "2PDZ468", Fuel.LPG, 5, 6000, g2));

            Random r = new Random();
            foreach (Car c in _cars)
            {
                for (int i = 0; i < r.Next(_drivers.Count) + 1; i++)
                {
                    c.Drivers.Add(_drivers[r.Next(_drivers.Count)]);
                }
            }
        }
    }
}