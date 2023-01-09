using Maquisistema.Fondos.Application.Interface;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Maquisistema.Fondos.Application.Test
{
    public class Tests
    {
        private static WebApplicationFactory<Program> _factory = null;
        private static IServiceScopeFactory _scopeFactory = null;

        [SetUp]
        public void Setup()
        {
            _factory = new ProductWebApplicationFactory();
            _scopeFactory = _factory.Services.GetRequiredService<IServiceScopeFactory>();
        }

        [Test]
        public void get_CuandoSeEnvianParametros_RetornarMensajeCorrecto()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IProductApplication>();

            // Arrange
            var id = "1";
            var expected = "Consulta Exitosa";

            // Act            
            var result = context.get(id);
            var actual = result.Message;

            //Assert.Pass();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async Task getAsync_CuandoSeEnvianParametros_RetornarMensajeCorrectoAsync()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IProductApplication>();

            // Arrange
            var id = "1";
            var expected = "Consulta Exitosa";

            // Act            
            var result = await context.getAsync(id);
            var actual = result.Message;

            //Assert.Pass();
            Assert.AreEqual(expected, actual);
        }
    }
}