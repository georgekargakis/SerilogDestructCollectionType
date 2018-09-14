using System.Collections.Generic;
using DestructureCollectionSerilog.Models;

namespace DestructureCollectionSerilog.Factories
{
    public static class StubDataFactory
    {
        public static IReadOnlyCollection<City> CreateDummyCitiesData()
        {
            var cities = new City[4];
            cities[0] = new City("Heraklion", 35.3387D, 25.1442);
            cities[1] = new City("Athens", 37.9838D, 23.7275D);
            cities[2] = new City("Thessaloniki",40.6401D, 22.9444D);
            cities[3] = new City("Patras",38.2466D, 21.7346D);
            cities[3] = new City("Larisa",39.6390D, 22.4191D);
            cities[3] = new City("Volos",39.3622D, 22.9422D);
            cities[3] = new City("Chania",35.5138D, 24.0180D);
            return cities;
        }
    }
}