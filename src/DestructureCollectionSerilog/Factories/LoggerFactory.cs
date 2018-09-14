using DestructureCollectionSerilog.Models;
using Serilog;
using Serilog.Core;

namespace DestructureCollectionSerilog.Factories
{
    public static class LoggerFactory
    {
        public static Logger Create()
        {
            return new LoggerConfiguration()
                .WriteTo.Console()
                .Destructure.With<CollectionDestructuringPolicy<City>>()
                .CreateLogger();
        }
    }
}



