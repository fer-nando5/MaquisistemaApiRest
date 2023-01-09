using Maquisistema.Fondos.Application.Interface;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Maquisistema.Fondos.Aplicacion.Test
{
    [TestClass]
    public class ProductApplicationTest
    {
        private static WebApplicationFactory<Program>? _factory = null;
        private static IServiceScopeFactory? _scopeFactory = null;

        [TestInitialize]
        public static void Initialize()
        {
            _factory = new ProductWebApplicationFactory();
            _scopeFactory = _factory.Services.GetRequiredService<IServiceScopeFactory>();
        }


        [TestMethod]
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

            // Assert
            //Assert.AreEqual(expected, actual);
        }
    

        [TestMethod]  
        public async void getAsync_CuandoNoSeEnvianParametros_RetornarMensajeErrorValidacion()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IProductApplication>();

            // Arrange
            var id = "1";
            var expected = "Consulta Exitosa";

            // Act            
            var result = await context.getAsync(id);
            var actual = result.Message;

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expected, actual);
        }
    }
}