using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FullPetflix.Models;
using FullPetflix.UserFiles;
using FullPetflix.AnimalFiles;
using System.Reflection;
using FullPetflix.FavoritesFiles;


namespace FullPetflix.AnimalFiles
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly AppDbContext _context;

        public AnimalRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Animal> AddAnimal(Animal animal)
        {
            try
            {
                var result = await _context.Animals.AddAsync(animal);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding animal: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteAnimal(int animalId)
        {
            try
            {
                // First delete any favorites referencing this animal
               var favorites = await _context.Favorites
                    .Where(f => f.AnimalId == animalId)
                    .ToListAsync();

                if (favorites.Any())
                {
                    _context.Favorites.RemoveRange(favorites);
                    await _context.SaveChangesAsync();
                } 

                // Then delete the animal
                var animal = await _context.Animals.FirstOrDefaultAsync(a => a.animal_id == animalId);
                if (animal == null)
                {
                    throw new KeyNotFoundException($"Animal with ID {animalId} not found");
                }

                _context.Animals.Remove(animal);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting animal: {ex.Message}");
                throw;
            }
        }

        public async Task<Animal> GetAnimal(int animalId)
        {
            try
            {
                return await _context.Animals.FirstOrDefaultAsync(a => a.animal_id == animalId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting animal: {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<Animal>> GetAnimals()
        {
            try
            {
                return await _context.Animals.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting animals: {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<Animal>> GetAnimalsByUserId(int userId)
        {
            try
            {
                return await _context.Animals.Where(a => a.userId == userId).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting animals by user ID: {ex.Message}");
                throw;
            }
        }

        public async Task<Animal> UpdateAnimal(Animal animal)
        {
            try
            {
                var existingAnimal = await _context.Animals.FindAsync(animal.animal_id);
                if (existingAnimal == null)
                {
                    return null;
                }

                existingAnimal.ItemType = animal.ItemType;
                existingAnimal.animal_title = animal.animal_title;
                existingAnimal.animal_category = animal.animal_category;
                existingAnimal.animal_type = animal.animal_type;
                existingAnimal.gender = animal.gender;
                existingAnimal.age = animal.age;
                existingAnimal.vaccineStatus = animal.vaccineStatus;
                existingAnimal.animal_weight = animal.animal_weight;
                existingAnimal.animal_size = animal.animal_size;
                existingAnimal.health_status = animal.health_status;
                existingAnimal.animal_description = animal.animal_description;
                existingAnimal.animal_new_price = animal.animal_new_price;
                existingAnimal.animal_old_price = animal.animal_old_price;

                // Handle picture update - allow setting to null
                existingAnimal.animal_pic = string.IsNullOrEmpty(animal.animal_pic) ? null : animal.animal_pic;

                await _context.SaveChangesAsync();
                return existingAnimal;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating animal: {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<Animal>> Search(string category, string type, Gender? gender)
        {
            try
            {
                IQueryable<Animal> query = _context.Animals;

                if (!string.IsNullOrEmpty(category))
                {
                    query = query.Where(a => a.animal_category == category);
                }

                if (!string.IsNullOrEmpty(type))
                {
                    query = query.Where(a => a.animal_type.Contains(type));
                }

                if (gender.HasValue)
                {
                    query = query.Where(a => a.gender == gender);
                }

                return await query.Include(a => a.User).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in animal search: {ex.Message}");
                throw;
            }
        }
    }
}