using CalculadorImpostoRenda.infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CalculadorImpostoRenda.Tests
{
    class TestHelper
    {
        public static Context CriarContexto()
        {
            return new Context(CreateNewContextOptions());
        }

        private static DbContextOptions<Context> CreateNewContextOptions()
        {
            // Create a fresh service provider, and therefore a fresh 
            // InMemory database instance.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create a new options instance telling the context to use an
            // InMemory database and the new service provider.
            var builder = new DbContextOptionsBuilder<Context>();
            builder.UseInMemoryDatabase("DB")
                   .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }
    }
}
