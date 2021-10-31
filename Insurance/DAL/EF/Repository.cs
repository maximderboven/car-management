using System;
using System.Collections.Generic;
using System.Linq;
using Insurance.Domain;

namespace Insurance.DAL.EF
{
    public class Repository : IRepository
    {
        private InsuranceDbContext _context;

        public Repository()
        {
            _context = new InsuranceDbContext();
        }

        public Car ReadCar(int numberplate)
        {
            //return _context.Cars.Find(numberplate);
            return _context.Cars.Single(c => c.NumberPlate.Equals(numberplate));
        }

        public IEnumerable<Car> ReadAllCars()
        {
            return _context.Cars.AsEnumerable();
        }

        public IEnumerable<Car> ReadCarsOf(Fuel fuel)
        {
            return _context.Cars.Where(car => car.Fuel.Equals(fuel)).AsEnumerable();
        }

        public void CreateCar(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
        }

        public Driver ReadDriver(int socialnumber)
        {
            return _context.Drivers.Single(d=>d.SocialNumber.Equals(socialnumber));
        }

        public IEnumerable<Driver> ReadAllDrivers()
        {
            return _context.Drivers.AsEnumerable();
        }

        public IEnumerable<Driver> ReadDriversBy(string? name, DateTime? dateofbirth)
        {
            IQueryable<Driver> filteredList = _context.Drivers;
            if (!String.IsNullOrEmpty(name))
            {
                filteredList = filteredList.Where(d => (d.FirstName + " " + d.LastName).ToLower().Contains(name.ToLower()));
            }

            if (!dateofbirth.Equals(DateTime.MinValue))
            {
                filteredList = filteredList.Where(d => dateofbirth.Equals(d.DateOfBirth.Date));
            }

            return filteredList;

            /*/return _context.Drivers.Where(d =>
                ((name == "") || (d.FirstName + " " + d.LastName).ToLower().Contains(name.ToLower()))
                && (dateofbirth.Equals(default(DateTime)) || dateofbirth.Equals(d.DateOfBirth.Date))); */
        }

        public void CreateDriver(Driver driver)
        {
            _context.Drivers.Add(driver);
            _context.SaveChanges();
        }
    }
}