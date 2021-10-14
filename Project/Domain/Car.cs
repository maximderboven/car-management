using System;
using System.Collections.Generic;

namespace Project.Domain
{
    public class Car
    {
        public string Brand { get; set; }
        public int NumberPlate { get; set; }
        public Fuel Fuel { get; set ; }
        public short Seats { get; set; }
        public double Mileage { get; set; }
        public Garage Garage { get; set; }
        public long? PurchasePrice = null;

        public ICollection<Driver> Drivers;
        
        //public INumerableValidationresult Validate(context context)
        //if (Enum.getvalues.Fuel().contains(this.Fuel());
        //Enum.isdefined

        public Car(long? purchasePrice, string brand, Fuel fuel, short seats, double mileage, Garage garage)
        {
            PurchasePrice = purchasePrice;
            Brand = brand;
            Fuel = fuel;
            Seats = seats;
            Mileage = mileage;
            Garage = garage;
            Drivers = new List<Driver>();
        }

        public override string ToString()
        {
            //or with $""
            return String.Format("Car: {0} from {1} maintained by: {2}",NumberPlate,Brand,Garage);
        }
    }
}