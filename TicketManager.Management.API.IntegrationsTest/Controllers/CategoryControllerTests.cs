using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TicketManager.Management.API.IntegrationsTest.Base;
using TicketManager.Management.Application.Features.Categories.Queries.GetCategoriesList;

namespace TicketManager.Management.API.IntegrationsTest.Controllers
{
    public class CategoryControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _factory;
        public CategoryControllerTests(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnsSuccessResult()
        {
            //Arrange
            var client = _factory.GetAnonClient();

            var response = await client.GetAsync("/api/category/all");

            response.EnsureSuccessStatusCode();

            //Act
            var result = JsonSerializer.Deserialize<List<CategoryListVm>>(await response.Content.ReadAsStringAsync());

            //Assert
            Assert.IsType<List<CategoryListVm>>(result);
            Assert.NotEmpty(result);
        }
    }
}
