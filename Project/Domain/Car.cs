using System;
using System.Collections.Generic;

namespace Project.Domain
{
    public class Car
    {
        public string Brand { get; set; }
        public string NumberPlate { get; set; }
        public Fuel Fuel { get; set ; }
        public short Seats { get; set; }
        public double Mileage { get; set; }
        public Garage Garage { get; set; }
        public long? PurchasePrice = null;

        public ICollection<Driver> Drivers;

        public Car(long? purchasePrice, string brand, string numberPlate, Fuel fuel, short seats, double mileage,
            Garage garage)
        {
            PurchasePrice = purchasePrice;
            Brand = brand ?? throw new ArgumentNullException(nameof(brand));
            NumberPlate = numberPlate ?? throw new ArgumentNullException(nameof(numberPlate));
            Fuel = fuel;
            Seats = seats;
            Mileage = mileage;
            Garage = garage ?? throw new ArgumentNullException(nameof(garage));

            Drivers = new List<Driver>();
        }

        public Car(string brand, string numberPlate, Fuel fuel, short seats, double mileage, Garage garage)
        {
            Brand = brand ?? throw new ArgumentNullException(nameof(brand));
            NumberPlate = numberPlate ?? throw new ArgumentNullException(nameof(numberPlate));
            Fuel = fuel;
            Seats = seats;
            Mileage = mileage;
            Garage = garage ?? throw new ArgumentNullException(nameof(garage));
            
            Drivers = new List<Driver>();
        }

        public override string ToString()
        {
            //or with $""
            return String.Format("Car: {0} from {1} maintained by: {2}",NumberPlate,Brand,Garage);
        }
        
        
    }
}