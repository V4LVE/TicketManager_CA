using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManager.Management.Application.Contracts.Persistence;
using TicketManager.Management.Domain.Entities;
using TicketManager.Management.Persistence;

namespace TicketManager.Management.API.IntegrationsTest.Base
{
    public class Utilities
    {
        public static void InitializeDbForTests(TicketManagerDbContext context)
        {
            int concert = 1;
            int musical = 2;
            int sports = 3;
            int conference = 4;

            context.Categories.Add(new Domain.Entities.Category { CategoryId = concert, Name = "Concert" });
            context.Categories.Add(new Domain.Entities.Category { CategoryId = musical, Name = "Musical" });
            context.Categories.Add(new Domain.Entities.Category { CategoryId = sports, Name = "Sports" });
            context.Categories.Add(new Domain.Entities.Category { CategoryId = conference, Name = "Conference" });

            context.SaveChanges();
        }

       
    }
}
