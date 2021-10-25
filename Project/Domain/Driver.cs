using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Domain
{
    public class Driver
    {
        [StringLength(5)]public string FirstName { get; set; }
        [StringLength(5)][Required] public string LastName { get; set ; }
        [Key] public int SocialNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<Car> Cars { get; set; }

        public Driver()
        {
            Cars = new List<Car>();
        }

        public Driver(string firstName, string lastName,DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Cars = new List<Car>();
        }

        public override string ToString()
        {
            return String.Format("{0} {1} (born on {2})", LastName, FirstName, DateOfBirth.ToShortDateString());
        }
    }
}