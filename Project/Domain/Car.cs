using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Domain
{
    public class Car : IValidatableObject
    {
        [Required] public string Brand { get; set; }
        [Key] public int NumberPlate { get; set; }
        public Fuel Fuel { get; set ; }
        [Range(1, 7)] public short Seats { get; set; }
        public double Mileage { get; set; }
        public Garage Garage { get; set; }
        public long? PurchasePrice = null;

        public ICollection<Driver> Drivers;

        public Car()
        {
            Drivers = new List<Driver>();
        }

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
        
        //public INumerableValidationresult Validate(context context)
        //if (Enum.getvalues.Fuel().contains(this.Fuel());
        //Enum.isdefined
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            if (Enum.IsDefined(Fuel))
            {
                errors.Add(new ValidationResult("Fuel not supported"));
            }
            return errors;
        }
    }
}