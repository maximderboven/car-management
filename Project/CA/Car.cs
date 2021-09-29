using System;
using System.Collections;
using System.Collections.Generic;

namespace CA
{
    public class Car
    {
        private string Brand { get; set; }
        private string NumberPlate { get; set; }
        public Fuel Fuel { get; set ; }
        private short Seats { get; set; }
        private double Mileage { get; set; }
        private Garage Garage { get; set; }
        private long? PurchasePrice = null;

        public ICollection<Driver> Drivers { get;}

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
            return String.Format("Car: {0} from {1} maintained by: {2}",NumberPlate,Brand,Garage);
        }
        
        
    }
}