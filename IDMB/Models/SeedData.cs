using IDMB.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IDMB.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any movies.
                if (context.TopBoxOffice.Any())
                {
                    return;   // DB has been seeded
                }

                context.TopBoxOffice.AddRange(
                     new TopBoxOffice
                     {
                         Rank = 1,
                         Title = "Avengers: Infinity War" ,
                         Weekend = "$257.7M",
                         Gross = "$257.7M",
                         Week = 1
                     },

                     new TopBoxOffice
                     {
                         Rank = 2,
                         Title = "A Quit Place",
                         Weekend = "$11.0M",
                         Gross = "$148.5M",
                         Week = 4
                     },

                     new TopBoxOffice
                     {
                         Rank = 3,
                         Title = "I Feel Pretty",
                         Weekend = "$8.2M",
                         Gross = "$29.6M",
                         Week = 2
                     },

                   new TopBoxOffice
                   {
                       Rank = 4,
                       Title = "Rampage",
                       Weekend = "$7.2M",
                       Gross = "$78.0M",
                       Week = 3
                   },
                   new TopBoxOffice
                   {
                       Rank = 5,
                       Title = "Black Panther",
                       Weekend = "$4.7M",
                       Gross = "$688.4M",
                       Week = 11
                   },
                   new TopBoxOffice
                   {
                       Rank = 6,
                       Title = "Super Troopers 2",
                       Weekend = "$3.7M",
                       Gross = "$22.2M",
                       Week = 2
                   },
                   new TopBoxOffice
                   {
                       Rank = 7,
                       Title = "Truth or Dare",
                       Weekend = "$3.3M",
                       Gross = "$35.4M",
                       Week = 3
                   },
                   new TopBoxOffice
                   {
                       Rank = 8,
                       Title = "Blockers",
                       Weekend = "$3.0M",
                       Gross = "$53.2M",
                       Week = 4
                   },
                   new TopBoxOffice
                   {
                       Rank = 9,
                       Title = "Ready Player One",
                       Weekend = "$2.6M",
                       Gross = "$130.8M",
                       Week = 5
                   },
                   new TopBoxOffice
                   {
                       Rank = 10,
                       Title = "Traffik",
                       Weekend = "$1.7M",
                       Gross = "$6.8M",
                       Week = 2
                   }
                );
                context.SaveChanges();
            }
        }
    }
}
