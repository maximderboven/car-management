namespace Project.CA
{
    public class Garage
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Telnr { get; set; }

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