using System;
using System.Collections.Generic;
using System.Linq;
using Insurance.Domain;

namespace Insurance.DAL
{
    public class InMemoryRepository : IRepository
    {
        private List<Driver> _drivers;
        private List<Car> _cars;

        public InMemoryRepository()
        {
            //init lists
            _drivers = new List<Driver>();
            _cars = new List<Car>();
            Seed();
        }

        public Car ReadCar(int numberplate)
        {
            return _cars.Single(car => car.NumberPlate.Equals(numberplate));
        }

        public IEnumerable<Car> ReadAllCars()
        {
            return _cars;
        }

        public IEnumerable<Car> ReadCarsOf(Fuel fuel)
        {
            return _cars.FindAll(car => car.Fuel.Equals(fuel)).AsEnumerable();
        }

        public void CreateCar(Car car)
        {
            if (_cars.Contains(car)) return;
            car.NumberPlate = _cars.Count + 1;
            _cars.Add(car);
        }

        public Driver ReadDriver(int socialnumber)
        {
            return _drivers.Single(driver => driver.SocialNumber.Equals(socialnumber));
        }

        public IEnumerable<Driver> ReadAllDrivers()
        {
            return _drivers;
        }

        public IEnumerable<Driver> ReadDriversBy(string? name, DateTime? dob)
        {
            IQueryable<Driver> filteredList = new EnumerableQuery<Driver>(_drivers);

            if (!String.IsNullOrWhiteSpace(name))
            {
                filteredList = filteredList.Where(d => (d.FirstName + " " + d.LastName).ToLower().Contains(name.ToLower()));
            }
            if (dob.HasValue)
            {
                filteredList = filteredList.Where(d => dob.Equals(d.DateOfBirth.Date));
            }

            return filteredList;
        }

        public void CreateDriver(Driver driver)
        {
            if (_drivers.Contains(driver)) return;
            driver.SocialNumber = _drivers.Count + 1;
            _drivers.Add(driver);
        }

        private void Seed()
        {
            CreateDriver(new Driver("Andy", "Kost", new DateTime(1994, 1, 5)));
            CreateDriver(new Driver("Jilles", "Frieling", new DateTime(1983, 5, 17)));
            CreateDriver(new Driver("Luite", "Poel", new DateTime(1958, 10, 12)));
            CreateDriver(new Driver("Caroliene", "Karremans", new DateTime(1945, 8, 7)));

            var g1 = new Garage("PSA retail", "Boomsesteenweg 894", "+3238719811");
            var g2 = new Garage("Van Dessel", "Mortsel", "+3234403236");
            
            CreateCar(new Car(null, "Citroen", Fuel.Gas, 4, 0, g1));
            CreateCar(new Car(10000, "Opel", Fuel.Gas, 6, 0, g1));
            CreateCar(new Car(null, "Audi", Fuel.Oil, 5, 5000, g2));
            CreateCar(new Car(35540, "BMW", Fuel.Lpg, 5, 6000, g2));
            

            //autoos toevoegen aan drivers
            _drivers[0].Cars.Add(_cars[1]);
            _drivers[0].Cars.Add(_cars[2]);
            
            _drivers[1].Cars.Add(_cars[1]);
            _drivers[1].Cars.Add(_cars[3]);
            
            _drivers[2].Cars.Add(_cars[2]);
            _drivers[2].Cars.Add(_cars[3]);
            
            _drivers[3].Cars.Add(_cars[0]);
            //Drivers toevoegen aan autoos
            _cars[0].Drivers.Add(_drivers[3]);

            _cars[1].Drivers.Add(_drivers[0]);
            _cars[1].Drivers.Add(_drivers[1]);
            
            _cars[2].Drivers.Add(_drivers[0]);
            _cars[2].Drivers.Add(_drivers[2]);
            
            _cars[3].Drivers.Add(_drivers[0]);

            //cars toevoegen aan garage voor onderhoud.
            g1.Cars.Add(_cars[0]);
            g1.Cars.Add(_cars[1]);
            
            g2.Cars.Add(_cars[2]);
            g2.Cars.Add(_cars[3]);
            
        }
    }
}