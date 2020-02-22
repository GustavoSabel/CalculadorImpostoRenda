using CalculadorImpostoRenda.infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CalculadorImpostoRenda.Tests
{
    class TestHelper
    {
        public static ApplicationDbContext CriarContexto()
        {
            return new ApplicationDbContext(CreateNewContextOptions());
        }

        private static DbContextOptions<ApplicationDbContext> CreateNewContextOptions()
        {
            // Create a fresh service provider, and therefore a fresh 
            // InMemory database instance.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create a new options instance telling the context to use an
            // InMemory database and the new service provider.
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseInMemoryDatabase("DB")
                   .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }
    }
}
