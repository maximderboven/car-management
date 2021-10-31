using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Insurance.Domain
{
    public class Driver
    {
        [Required(ErrorMessage = "Error: Firstname is required")]
        [StringLength(40,ErrorMessage = "Error: MIN. 5 CHAR",MinimumLength = 5)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Error: Lastname is required")]
        [StringLength(40, ErrorMessage = "Error: MIN. 5 CHAR",MinimumLength = 5)]
        public string LastName { get; set; }

        [Key] public int SocialNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<Car> Cars { get; set; }

        public Driver()
        {
            Cars = new List<Car>();
        }

        public Driver(string firstName, string lastName, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Cars = new List<Car>();
        }
        
        //need to add custom DateTime validation.
    }
}