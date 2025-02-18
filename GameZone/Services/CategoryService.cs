

namespace GameZone.Services
{
    public class CategoryService : Repository<Category>,ICategoryService
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryService(ApplicationDbContext applicationDb):base(applicationDb) 
        {
            _dbContext = applicationDb;
        }

        public async Task<IEnumerable<Category>> GetCategoriesOrdereds()
        {
           return await _dbContext.Categories.AsNoTracking().OrderBy(c=>c.Name).ToListAsync();
        }
    }
}
