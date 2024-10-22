using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManager.Management.Application.Contracts.Persistence;
using TicketManager.Management.Application.Features.Categories.Commands.CreateCategory;
using TicketManager.Management.Application.Profiles;
using TicketManager.Management.Application.UnitTest.Mocks;
using TicketManager.Management.Domain.Entities;

namespace TicketManager.Management.Application.UnitTest.Categories.Commands
{
    public class CreateCategoryTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncBaseRepository<Category>> _mockCategoryRepository;

        public CreateCategoryTest()
        {
            _mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
            var confProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = confProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidCategory_AddedToCategoriesRepo()
        {
            //Arrange
            var handler = new CreateCategoryCommandHandler(_mapper, _mockCategoryRepository.Object);

            //Act
            await handler.Handle(new CreateCategoryCommand() { Name = "Underground Dog Fights" }, CancellationToken.None);

            var allCategories = await _mockCategoryRepository.Object.ListAllAsync();

            //Assert
            allCategories.Count.ShouldBe(5);
        }

    }
}
