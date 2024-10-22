using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManager.Management.Application.Contracts;
using TicketManager.Management.Domain.Entities;

namespace TicketManager.Management.Persistence.IntegrationTest
{
    public class TicketManagerDbContextTests
    {
        private readonly TicketManagerDbContext _ticketManagerDbContext;
        private readonly Mock<ILoggedInUserService> _loggedInUserServiceMock;
        private readonly string _loggedInUserId;

        public TicketManagerDbContextTests()
        {
            var dbContextOptions = new DbContextOptionsBuilder<TicketManagerDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _loggedInUserId = "00000000-0000-0000-0000-000000000000";
            _loggedInUserServiceMock = new Mock<ILoggedInUserService>();
            _loggedInUserServiceMock.Setup(s => s.UserId).Returns(_loggedInUserId);

            _ticketManagerDbContext = new TicketManagerDbContext(dbContextOptions, _loggedInUserServiceMock.Object);
        }

        [Fact]
        public async Task Save_SetCreatedByProperty()
        {
            //arrange
            var ev = new Event
            {
                Name = "Test Event",
                Description = "Test Description",
                EventId = 5,
                CategoryId = 1
            };

            //act
            _ticketManagerDbContext.Events.Add(ev);
            await _ticketManagerDbContext.SaveChangesAsync();

            //assert
            ev.CreatedBy.ShouldBe(_loggedInUserId);
        }
    }
}
