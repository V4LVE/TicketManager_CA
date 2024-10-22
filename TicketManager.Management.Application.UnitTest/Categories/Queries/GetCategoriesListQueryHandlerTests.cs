using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManager.Management.Application.Contracts.Persistence;
using TicketManager.Management.Application.Features.Categories.Queries.GetCategoriesList;
using TicketManager.Management.Application.Profiles;
using TicketManager.Management.Application.UnitTest.Mocks;
using TicketManager.Management.Domain.Entities;

namespace TicketManager.Management.Application.UnitTest.Categories.Queries
{
    public class GetCategoriesListQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncBaseRepository<Category>> _mockCategoryRepository;

        public GetCategoriesListQueryHandlerTests()
        {
            _mockCategoryRepository = RepositoryMocks.GetCategoryRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]

        public async Task GetCategoriesListTest()
        {
            //Arrange
            var handler = new GetCategoriesListQueryHandler(_mapper, _mockCategoryRepository.Object);

            //Act
            var result = await handler.Handle(new GetCategoriesListQuery(), CancellationToken.None);


            //Assert
            result.ShouldBeOfType<List<CategoryListVm>>();

            result.Count.ShouldBe(4);
        }
    }
}
