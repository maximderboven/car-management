using System;

namespace CA
{
    public class Garage
    {
        private string Name { get; set; }
        private string Adress { get; set; }
        private string Telnr { get; set; }

        public Garage(string name, string adress, string telnr)
        {
            Name = name;
            Adress = adress;
            Telnr = telnr;
        }

        public override string ToString()
        {
            return $"Garage {Name}";
        }
    }
}