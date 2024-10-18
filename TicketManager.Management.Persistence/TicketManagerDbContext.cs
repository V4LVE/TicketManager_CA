using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManager.Management.Domain.Common;

namespace TicketManager.Management.Persistence
{
    public class TicketManagerDbContext : DbContext
    {
        public TicketManagerDbContext(DbContextOptions<TicketManagerDbContext> options) : base(options)
        {
        }

        public DbSet<Domain.Entities.Category> Categories { get; set; }
        public DbSet<Domain.Entities.Event> Events { get; set; }
        public DbSet<Domain.Entities.Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TicketManagerDbContext).Assembly);

            // Seed data
            int concert = 1;
            int musical = 2;
            int sports = 3;
            int conference = 4;

            #region Categories
            modelBuilder.Entity<Domain.Entities.Category>().HasData(
                new Domain.Entities.Category { CategoryId = concert, Name = "Concert" },
                new Domain.Entities.Category { CategoryId = musical, Name = "Musical" },
                new Domain.Entities.Category { CategoryId = sports, Name = "Sports" },
                new Domain.Entities.Category { CategoryId = conference, Name = "Conference" });
            #endregion

            #region Events
            modelBuilder.Entity<Domain.Entities.Event>().HasData(
                new Domain.Entities.Event
                {
                    EventId = 1,
                    Name = "Metallica Concert",
                    Price = 299,
                    Artist = "Metallica",
                    Date = DateTime.Now.AddMonths(6),
                    Description = "A Metallica concert that is awesome,",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ8VYq1GiPAkL88ih7v850dtCQlSLDg9BbiRg&s",
                    CategoryId = concert
                },

                new Domain.Entities.Event
                {
                    EventId = 2,
                    Name = "Joker á deux",
                    Price = 149,
                    Artist = "Multiple Artists",
                    Date = DateTime.Now.AddMonths(7),
                    Description = "A movie made as a musical",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR8HF-VtwUAmaRI7RGJWxNWIh3waXEOyTdymQ&s",
                    CategoryId = musical
                },

                new Domain.Entities.Event
                {
                    EventId = 3,
                    Name = "SønderjyskE vs Aalborg Pirates",
                    Price = 119,
                    Artist = "Frøs Arena",
                    Date = DateTime.Now.AddMonths(3),
                    Description = "An epical hockey game",
                    ImageUrl = "https://cdn.britannica.com/50/219150-050-0032E44D/Marc-Andre-Fleury-Vegas-Golden-Knights-Stanley-Cup-Final-2018.jpg",
                    CategoryId = sports
                },

                new Domain.Entities.Event
                {
                    EventId = 4,
                    Name = "Learn to dont care",
                    Price = 999,
                    Artist = "Do you care?",
                    Date = DateTime.Now.AddMonths(8),
                    Description = "I would write something here. But I dont really care",
                    ImageUrl = "https://t3.ftcdn.net/jpg/01/48/07/30/360_F_148073033_3KmrbuUl4OW9qM0iFc0mr5M948VvWgkQ.jpg",
                    CategoryId = conference
                });
            #endregion

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Detached:
                        break;
                    case EntityState.Unchanged:
                        break;
                    case EntityState.Deleted:
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    default:
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
