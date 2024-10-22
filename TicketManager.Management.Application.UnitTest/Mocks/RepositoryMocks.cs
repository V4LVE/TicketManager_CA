using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TicketManager.Management.Application.Contracts.Persistence;
using TicketManager.Management.Domain.Entities;

namespace TicketManager.Management.Application.UnitTest.Mocks
{
    public static class RepositoryMocks
    {
        public static Mock<IAsyncBaseRepository<Category>> GetCategoryRepository()
        {
            int concert = 1;
            int musical = 2;
            int sports = 3;
            int conference = 4;

            List<Category> categories = new() {
                new Domain.Entities.Category { CategoryId = concert, Name = "Concert" },
                new Domain.Entities.Category { CategoryId = musical, Name = "Musical" },
                new Domain.Entities.Category { CategoryId = sports, Name = "Sports" },
                new Domain.Entities.Category { CategoryId = conference, Name = "Conference" }};

            var mockCategoryRepository = new Mock<IAsyncBaseRepository<Category>>();
            mockCategoryRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(categories);

            mockCategoryRepository.Setup(repo => repo.AddAsync(It.IsAny<Category>())).ReturnsAsync(
                (Category category) =>
                {
                    categories.Add(category);
                    return category;
                });


            return mockCategoryRepository;
        }
    }
}
