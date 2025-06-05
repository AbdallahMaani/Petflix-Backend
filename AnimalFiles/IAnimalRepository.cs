using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using FullPetflix.Models;
using FullPetflix.UserFiles;

namespace FullPetflix.AnimalFiles
{
    public interface IAnimalRepository
    {
        Task<IEnumerable<Animal>> GetAnimals();
        Task<Animal> GetAnimal(int animalId);
        Task<IEnumerable<Animal>> GetAnimalsByUserId(int userId);
        Task<Animal> AddAnimal(Animal animal);
        Task<Animal> UpdateAnimal(Animal animal);
        Task DeleteAnimal(int animalId);
        Task<IEnumerable<Animal>> Search(string category, string type, Gender? gender);
    }
}