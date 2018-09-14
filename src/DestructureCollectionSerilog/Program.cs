using System;
using DestructureCollectionSerilog.Factories;

namespace DestructureCollectionSerilog
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = StubDataFactory.CreateDummyCitiesData();
            var logger = LoggerFactory.Create();
            logger.Information("These are the major greek cities: {@cities}", data);
        }
    }
}
