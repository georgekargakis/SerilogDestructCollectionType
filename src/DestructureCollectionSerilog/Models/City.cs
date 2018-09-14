namespace DestructureCollectionSerilog.Models
{
    public class City
    {
        public City(string name, double longitude, double latitude)
        {
            Name = name;
            Longitude = longitude;
            Latitude = latitude;
        }

        public string Name { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}