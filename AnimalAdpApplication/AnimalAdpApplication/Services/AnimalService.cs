using AnimalAdpApplication.Data;
using Microsoft.EntityFrameworkCore;
using AnimalAdpApplication.Entities;

namespace AnimalAdpApplication.Services
{
    public class AnimalService
    {
        private readonly GenericDbContext _context;

        public AnimalService(GenericDbContext context)
        {
            _context = context;
        }

        public async Task<List<Animal>> GetAllAnimalsAsync()
        {
            return await _context.Set<Animal>().ToListAsync();
        }

        public async Task<Animal> GetAnimalByIdAsync(int id)
        {
            return await _context.Set<Animal>().FindAsync(id);
        }

        public async Task AddAnimalAsync(Animal animal)
        {
            await _context.Set<Animal>().AddAsync(animal);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAnimalAsync(Animal animal)
        {
            _context.Set<Animal>().Update(animal);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAnimalAsync(int id)
        {
            var animal = await GetAnimalByIdAsync(id);
            if (animal != null)
            {
                _context.Set<Animal>().Remove(animal);
                await _context.SaveChangesAsync();
            }
        }
    }
}
