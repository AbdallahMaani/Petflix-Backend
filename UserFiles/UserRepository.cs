using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FullPetflix.Models;
using FullPetflix.UserFiles;

namespace FullPetflix.UserFiles
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Users> AddUser(Users user)
        {
            var result = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

           var cart = new Cart { UserId = result.Entity.userId };
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task DeleteUser(int userId)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // 1. Get the user with all related data we need to reference
                var user = await _context.Users
                    .Include(u => u.Animals)
                    .Include(u => u.Products)
                    .Include(u => u.Orders)
                    .FirstOrDefaultAsync(u => u.userId == userId);

                if (user == null) return;

                // 2. Delete reports where user is reporter or reported
                await _context.Reports
                    .Where(r => r.ReporterId == userId || r.ReportedUserId == userId)
                    .ExecuteDeleteAsync();

                // 3. Delete favorites (both where user is favoriter and where user's items are favorited)
                var userAnimalIds = user.Animals.Select(a => a.animal_id).ToList();
                var userProductIds = user.Products.Select(p => p.product_id).ToList();

                await _context.Favorites
                    .Where(f => f.UserId == userId ||
                               (f.AnimalId.HasValue && userAnimalIds.Contains(f.AnimalId.Value)) ||
                               (f.ProductId.HasValue && userProductIds.Contains(f.ProductId.Value)))
                    .ExecuteDeleteAsync();

                // 4. Delete reviews where user is reviewer or for user's items
                await _context.ProductReviews
                    .Where(pr => pr.ReviewerId == userId ||
                                (pr.ProductId.HasValue && userProductIds.Contains(pr.ProductId.Value)))
                    .ExecuteDeleteAsync();

                await _context.AnimalReviews
                    .Where(ar => ar.ReviewerId == userId ||
                                (ar.AnimalId.HasValue && userAnimalIds.Contains(ar.AnimalId.Value)))
                    .ExecuteDeleteAsync();

                // 5. Delete cart items (through cart which will be deleted with user)
                await _context.CartItems
                    .Where(ci => ci.Cart.UserId == userId)
                    .ExecuteDeleteAsync();

                // 6. Delete the cart
                await _context.Carts
                    .Where(c => c.UserId == userId)
                    .ExecuteDeleteAsync();

                // 7. Now delete the user (which will cascade to Animals, Products, Orders, etc.)
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw; // Re-throw to be handled by the controller
            }
        }

        public async Task<Users> GetUser(int UserId)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.userId == UserId);
        }

        public async Task<Users> GetUserByEmail(string Email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.email == Email);
        }

        public async Task<Users> GetUserByUsername(string Username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.username == Username);
        }

        public async Task<IEnumerable<Users>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<Users> UpdateUser(Users user)
        {
            var result = await _context.Users.FirstOrDefaultAsync(u => u.userId == user.userId);
            if (result != null)
            {
                result.username = user.username;
                result.name = user.name;
                result.email = user.email;
                result.password = user.password;
                result.location = user.location;
                result.gender = user.gender;
                result.phone = user.phone;
                result.birthDay = user.birthDay;
                result.availableDays = user.availableDays;
                result.availableHours = user.availableHours;
                result.delivery_method = user.delivery_method;
                result.bio = user.bio;
                result.ProfilePic = user.ProfilePic;
                result.isAdmin = user.isAdmin;

                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Users> UpdateUserPassword(int userId, string oldPassword, string newPassword)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.userId == userId);
            if (user == null)
            {
                return null;
            }

            // Verify old password (adjust if hashed)
            if (user.password != oldPassword)
            {
                throw new ArgumentException("Old password is incorrect.");
            }

            user.password = newPassword; // Update with new password (hash it if needed)
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<IEnumerable<Users>> Search(string name, Gender? gender)
        {
            IQueryable<Users> query = _context.Users;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(u => u.name.Contains(name));
            }

            if (gender.HasValue)
            {
                query = query.Where(u => u.gender == gender);
            }

            return await query.ToListAsync();
        }
    }
}