using System;
using System.Collections.Generic;

namespace Project.Domain
{
    public class Driver
    {
        public string FirstName { get; set; }
        public string LastName { get; set ; }
        public int SocialNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<Car> Cars { get; set; }

        public Driver(string firstName, string lastName, int socialNumber, DateTime dateOfBirth)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            SocialNumber = socialNumber;
            DateOfBirth = dateOfBirth;
            
            Cars = new List<Car>();
        }

        public override string ToString()
        {
            return String.Format("{0} {1} (born on {2})", LastName, FirstName, DateOfBirth.ToShortDateString());
        }
    }
}