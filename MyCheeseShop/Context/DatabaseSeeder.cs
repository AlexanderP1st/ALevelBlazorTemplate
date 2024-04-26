using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyCheeseShop.Model;
using System.Runtime.CompilerServices;


namespace MyCheeseShop.Context
{
    public class DatabaseSeeder
    {
        private readonly DatabaseContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DatabaseSeeder(DatabaseContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;

        }

        public async Task Seed()
        {
            await _context.Database.MigrateAsync();

            if (!_context.Cheeses.Any())
            {
                var cheeses = GetCheeses();
                _context.Cheeses.AddRange(cheeses);
                await _context!.SaveChangesAsync();
            }

            if (!_context.Users.Any())
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                await _roleManager.CreateAsync(new IdentityRole("Customer"));

                var adminEmail = "admin@cheese.com";
                var adminPassword = "Cheese123!";

                var admin = new User
                {
                    UserName = adminEmail,
                    Email = adminPassword,
                    FirstName = "Admin",
                    LastName = "User",
                    Address = "123 Admin Street",
                    City = "Adminville",
                    PostCode = "AD12 MIN"
                };

                await _userManager.CreateAsync(admin, adminPassword);
                await _userManager.AddToRoleAsync(admin, "Admin");
            }
        }
               
         private List<Cheese> GetCheeses()
         {
              return
                [
                 new Cheese { Name = "Cheddar", Type = "Hard", Description = "A sharp, aged cheese originating in England.", Strength = "Strong", Price = 10.99m },
                 new Cheese { Name = "Brie", Type = "Soft", Description = "A creamy cheese originating in France.", Strength = "Mild", Price = 12.50m },
                 new Cheese { Name = "Gouda", Type = "Semi-Hard", Description = "A Dutch cheese known for its nutty flavor and smooth texture.", Strength = "Medium", Price = 8.75m },
                 new Cheese { Name = "Roquefort", Type = "Blue", Description = "A French blue cheese made from sheep's milk.", Strength = "Strong", Price = 15.25m },
                 new Cheese { Name = "Mozzarella", Type = "Soft", Description = "An Italian cheese known for its stretchy texture and mild flavor.", Strength = "Mild", Price = 9.99m },
                 new Cheese { Name = "Gruyère", Type = "Hard", Description = "A Swiss cheese with a rich, nutty flavor. ", Strength = "Medium", Price = 14.75m },
                 new Cheese { Name = "Camembert", Type = "Soft", Description = "A French cheese similar to Brie, but with a stronger flavor.", Strength = "Medium", Price = 11.25m },
                 new Cheese { Name = "Parmesan", Type = "Hard", Description = "A hard Italian cheese used for grating.", Strength = "Strong", Price = 13.99m },
                 new Cheese { Name = "Emmental", Type = "Hard", Description = "A Swiss cheese with characteristic holes and a mild, nutty flavor.", Strength = "Medium", Price = 10.50m },
                 new Cheese { Name = "Manchego", Type = "Hard", Description = "A Spanish cheese made from sheep's milk, with a buttery texture and nutty flavor.", Strength = "Medium", Price = 11.99m },
                 new Cheese { Name = "Feta", Type = "Soft", Description = "A Greek cheese made from sheep's milk or a mixture of sheep's and goat's milk, with a tangy flavor.", Strength = "Medium", Price = 9.25m },
                 new Cheese { Name = "Havarti", Type = "Semi-Soft", Description = "A Danish cheese with a creamy texture and buttery flavor.", Strength = "Mild", Price = 10.75m },
                 new Cheese { Name = "Provolone", Type = "Semi-Hard", Description = "An Italian cheese with a smooth texture and mild flavor when young, becoming sharper with age.", Strength = "Medium", Price = 11.50m },
                 new Cheese { Name = "Colby", Type = "Semi-Hard", Description = "An American cheese similar to Cheddar, but milder and moister.", Strength = "Mild", Price = 8.99m },
                 new Cheese { Name = "Monterey Jack", Type = "Semi-Hard", Description = "An American cheese with a mild flavor and smooth texture.", Strength = "Mild", Price = 9.50m },
                 new Cheese { Name = "Pepper Jack", Type = "Semi-Hard", Description = "A variation of Monterey Jack cheese with spicy peppers added.", Strength = "Medium", Price = 10.25m },
                 new Cheese { Name = "Swiss", Type = "Hard", Description = "A Swiss cheese with a sweet, nutty flavor and characteristic holes.", Strength = "Medium", Price = 12.99m },
                 new Cheese { Name = "Blue Cheese", Type = "Blue", Description = "A general term for cheeses inoculated with Penicillium mold cultures, resulting in a blue or green vein.", Strength = "Strong", Price = 14.99m },
                 new Cheese { Name = "Gorgonzola", Type = "Blue", Description = "An Italian blue cheese with a creamy texture and tangy flavor.", Strength = "Strong", Price = 16.50m },
                  new Cheese { Name = "Boursin", Type = "Soft", Description = "A French cheese flavored with herbs and spices, known for its creamy texture.", Strength = "Mild", Price = 11.99m }
                 ];
         }
     
    }
}
