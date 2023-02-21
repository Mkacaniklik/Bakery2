//using Bakery2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Bakery2.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bakery2.Models;

namespace Bakery2.Models
{
    public class SeedData
    {
        public static async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<Bakery2User>>();
            IdentityResult roleResult;
            //Add Admin Role
            var roleCheck = await RoleManager.RoleExistsAsync("Admin");
            if (!roleCheck) { roleResult = await RoleManager.CreateAsync(new IdentityRole("Admin")); }
            Bakery2User user = await UserManager.FindByEmailAsync("admin@rsweb.com");
            if (user == null)
            {
                var User = new Bakery2User();
                User.Email = "admin@rsweb.com";
                User.UserName = "admin@rsweb.com";
                string userPWD = "ADMIN111";
                IdentityResult chkUser = await UserManager.CreateAsync(User, userPWD);
                //Add default User to Role Admin
                if (chkUser.Succeeded) { var result1 = await UserManager.AddToRoleAsync(User, "Admin"); }
            }

            var roleCheck1 = await RoleManager.RoleExistsAsync("Baker");
            if (!roleCheck1) { roleResult = await RoleManager.CreateAsync(new IdentityRole("Baker")); }
            Bakery2User user1 = await UserManager.FindByEmailAsync("baker@rsweb.com");
            if (user1 == null)
            {
                var User = new Bakery2User();
                User.Email = "baker@rsweb.com";
                User.UserName = "baker@rsweb.com";
                string userPWD = "BAKER222";
                IdentityResult chkUser = await UserManager.CreateAsync(User, userPWD);
                //Add default User to Role Admin
                if (chkUser.Succeeded) { var result1 = await UserManager.AddToRoleAsync(User, "Baker"); }
            }

            var roleCheck2 = await RoleManager.RoleExistsAsync("Customer");
            if (!roleCheck2) { roleResult = await RoleManager.CreateAsync(new IdentityRole("Customer")); }
            Bakery2User user2 = await UserManager.FindByEmailAsync("customer@rsweb.com");
            if (user2 == null)
            {
                var User = new Bakery2User();
                User.Email = "customer@rsweb.com";
                User.UserName = "customer@rsweb.com";
                string userPWD = "CUSTOMER333";
                IdentityResult chkUser = await UserManager.CreateAsync(User, userPWD);
                //Add default User to Role Admin
                if (chkUser.Succeeded) { var result1 = await UserManager.AddToRoleAsync(User, "Customer"); }
            }
        }

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Bakery2Context(
            serviceProvider.GetRequiredService<
            DbContextOptions<Bakery2Context>>()))
            {
            //    CreateUserRoles(serviceProvider).Wait();
                //  

                /*  context.Order.AddRange(
                      new Order { CustomerId = 1, ProductId = 1 },
                new Order { CustomerId = 2, ProductId = 2 },
                new Order { CustomerId = 3, ProductId = 3 },
                new Order { CustomerId = 4, ProductId = 1 },
                new Order { CustomerId = 5, ProductId = 2 },
                new Order { CustomerId = 6, ProductId = 3 },
                new Order { CustomerId = 4, ProductId = 1 },
                new Order { CustomerId = 5, ProductId = 2 },
                new Order { CustomerId = 6, ProductId = 3 });
                 */
                if (context.Products.Any() || context.Customer.Any() || context.Baker.Any())
                {
                    return; // DB has been seeded
                };
              /*  context.Baker.AddRange(
                               new Baker { BakerId = 1, FirstName = "Simona", LastName = "Naumoska" },
                               new Baker { BakerId = 2, FirstName = "Dejan", LastName = "Vasilevski" },
                               new Baker { BakerId = 3, FirstName = "Irina", LastName = "Smith" }
                               );
                //context.SaveChanges();
                context.Customer.AddRange(
          new Customer { CustomerId = 1, FirstName = "Sara", LastName = "Trajkovska" },

          new Customer { CustomerId = 2, FirstName = "Matej", LastName = "Miloshevski" },
          new Customer { CustomerId = 3, FirstName = "Lina", LastName = "Hristovska" },
          new Customer { CustomerId = 4, FirstName = "Luka", LastName = "Fasolino" },
          new Customer { CustomerId = 5, FirstName = "Elena", LastName = "Angelovska" },
          new Customer { CustomerId = 6, FirstName = "Zaklina", LastName = "Kristinovska" },
          new Customer { CustomerId = 7, FirstName = "Stefan", LastName = "Petrovikj" },
          new Customer { CustomerId = 8, FirstName = "Nikola", LastName = "Dimitrievski" }
          );
               // context.SaveChanges();

                context.Products.AddRange(
                new Products
                {
                    ProductsId = 1,
                    Name = "Pogacha ",
                    Price = 200,
                    BakerId = context.Baker.Single(d => d.BakerId == 1).BakerId
                },
             new Products
             {
                 ProductsId = 2,
                 Name = "Pastrmajlija ",
                 Price = 600,
                 BakerId = context.Baker.Single(d => d.BakerId == 2).BakerId
             },
             new Products
             {
                 ProductsId = 3,
                 Name = "Pletenka ",
                 Price = 400,
                 BakerId = context.Baker.Single(d => d.BakerId == 3).BakerId
             }
             );*/
              //  context.SaveChanges();
                /* context.Baker.AddRange(
                 new Baker { BakerId = 1,FirstName = "Simona", LastName = "Naumoska" },
                 new Baker { BakerId = 2, FirstName = "Dejan", LastName = "Vasilevski" },
                 new Baker { BakerId = 3, FirstName = "Irina", LastName = "Smith" }
                 );
                 context.SaveChanges();
                 context.Customer.AddRange(
           new Customer { CustomerId = 1, FirstName = "Sara", LastName = "Trajkovska"},

           new Customer { CustomerId = 2, FirstName = "Matej", LastName = "Miloshevski" },
           new Customer { CustomerId = 3,FirstName = "Lina", LastName = "Hristovska"},
           new Customer { CustomerId = 4, FirstName = "Luka", LastName = "Fasolino"},
           new Customer { CustomerId = 5, FirstName = "Elena", LastName = "Angelovska"},
           new Customer { CustomerId = 6, FirstName = "Zaklina", LastName = "Kristinovska" },
           new Customer { CustomerId = 7, FirstName = "Stefan", LastName = "Petrovikj"},
           new Customer { CustomerId = 8, FirstName = "Nikola", LastName = "Dimitrievski" }
           );
                 context.SaveChanges();

                 context.Products.AddRange(
                 new Products
                 {
                     ProductsId = 1,
                     Title = "Pogacha ",
                     Price = 200,
                     BakerId = context.Baker.Single(d=>d.BakerId==1).BakerId     },
              new Products
              {
                  ProductsId = 2,
                  Title = "Pastrmajlija ",
                  Price = 600,
                  BakerId = context.Baker.Single(d => d.BakerId == 2).BakerId
              },
              new Products
              {
                  ProductsId = 3,
                  Title = "Pletenka ",
                  Price = 400,
                  BakerId = context.Baker.Single(d => d.BakerId == 3).BakerId
              }
              );
                 context.SaveChanges();
 */
                /* context.Order.AddRange(
                       new Order { CustomerId = 1, ProductId = 1 },
                 new Order { CustomerId = 2, ProductId = 2 },
                 new Order { CustomerId = 3, ProductId = 3 },
                 new Order { CustomerId = 4, ProductId = 1 },
                 new Order { CustomerId = 5, ProductId = 2 },
                 new Order { CustomerId = 6, ProductId = 3 },
                 new Order { CustomerId = 4, ProductId = 1 },
                 new Order { CustomerId = 5, ProductId = 2 },
                 new Order { CustomerId = 6, ProductId = 3 });*
                          /* new Enrollment
                           {
                               StudentId = context.Student.Single(d => d.FirstName == "Sara" && d.LastName == "Trajkovska").StudentId,
                               CourseId = context.Course.Single(d => d.Title == "Programiranje i algoritmi ").CourseId
                           },
                            new Enrollment
                            {
                                StudentId = context.Student.Single(d => d.FirstName == "Zaklina" && d.LastName == "Kristinovska").StudentId,
                                CourseId = context.Course.Single(d => d.Title == "Kompjuterski Tehnologii").CourseId
                            },
                             new Enrollment
                             {
                                 StudentId = context.Student.Single(d => d.FirstName == "Matej" && d.LastName == "Miloshevski").StudentId,
                                 CourseId = context.Course.Single(d => d.Title == "Fizika 1").CourseId
                             },
                            new Enrollment
                            {
                                StudentId = context.Student.Single(d => d.FirstName == "Nikola" && d.LastName == "Dimitrievski").StudentId,
                                CourseId = context.Course.Single(d => d.Title == "Programiranje i algoritmi ").CourseId,
                            },
                               new Enrollment
                               {
                                   StudentId = context.Student.Single(d => d.FirstName == "Luka" && d.LastName == "Fasolino").StudentId,
                                   CourseId = context.Course.Single(d => d.Title == "Kompjuterski Tehnologii").CourseId,
                               }*/



            }
        }

       /* private static object CreateUserRoles(IServiceProvider serviceProvider)
        {
            throw new NotImplementedException();
        }*/
    }
}
