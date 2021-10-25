using System;
using System.Collections.Generic;
using System.Linq;
using Project.Domain;

namespace Project.DAL.EF
{
    public class Repository : IRepository
    {
        private ProjectDbContext _context;

        public Repository()
        {
            _context = new ProjectDbContext();
        }

        public Car ReadCar(int numberplate)
        {
            return _context.Cars.Find(numberplate);
        }

        public IEnumerable<Car> ReadAllCars()
        {
            return _context.Cars.ToList();
        }

        public IEnumerable<Car> ReadCarsOf(Fuel fuel)
        {
            return _context.Cars.Where(car => car.Fuel.Equals(fuel));
        }

        public void CreateCar(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
        }

        public Driver ReadDriver(int socialnumber)
        {
            return _context.Drivers.Find(socialnumber);
        }

        public IEnumerable<Driver> ReadAllDrivers()
        {
            return _context.Drivers.ToList();
        }

        public IEnumerable<Driver> ReadDriversBy(string? name, DateTime? dateofbirth)
        {
            return _context.Drivers.Where(d =>
                ((name == "") || (d.FirstName + " " + d.LastName).ToLower().Contains(name.ToLower()))
                && (dateofbirth.Equals(default(DateTime)) || dateofbirth.Equals(d.DateOfBirth.Date)));
        }

        public void CreateDriver(Driver driver)
        {
            _context.Drivers.Add(driver);
            _context.SaveChanges();
        }
    }
}