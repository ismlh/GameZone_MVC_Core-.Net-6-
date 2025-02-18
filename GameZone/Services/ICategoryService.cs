namespace GameZone.Services
{
    public interface ICategoryService:IRepository<Category>
    {
        Task<IEnumerable<Category>> GetCategoriesOrdereds();
    }
}
