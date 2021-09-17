using PlatformService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlatformService.Data
{
    public class PlatformRepository : IPlatformRepository
    {
        private readonly AppDbContext _dbContext;

        public PlatformRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void CreatePlatform(Platform platform)
        {
            _dbContext.Add(platform);
        }

        public Platform GetPlatformById(int id)
        {
            return _dbContext.PlatForms.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Platform> GetPlatforms()
        {
            return _dbContext.PlatForms;
        }

        public bool SaveChanges()
        {
            return _dbContext.SaveChanges() > 0;
        }
    }
}
