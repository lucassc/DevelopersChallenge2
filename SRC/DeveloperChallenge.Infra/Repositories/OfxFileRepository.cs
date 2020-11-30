using DeveloperChallenge.Domain.Enities;
using DeveloperChallenge.Domain.Interfaces.Repositories;
using DeveloperChallenge.Infra.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperChallenge.Infra.Repositories
{
    public class OfxFileRepository : IOfxFileRepository
    {
        private readonly DbSet<OfxFile> _dbSet;
        private readonly SqlContext _context;

        public OfxFileRepository(SqlContext context)
        {
            _context = context;
            _dbSet = _context.Set<OfxFile>();
        }

        public async Task AddAsync(OfxFile ofxFile)
        {
            await _dbSet.AddAsync(ofxFile);
            await _context.SaveChangesAsync();
        }

        public async Task<OfxFile> GetAsync(Guid id) => await _dbSet.Where(file => file.Id == id).FirstOrDefaultAsync();
    }
}