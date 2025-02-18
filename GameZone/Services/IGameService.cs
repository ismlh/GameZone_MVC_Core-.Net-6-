
namespace GameZone.Services
{
    public interface IGameService:IRepository<Game>
    {
        Task<IEnumerable<Game>> GamesWithCategoryAndDevices();
        Task<string> GameCoverPath(IFormFile cover);
    }
}
