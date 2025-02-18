


namespace GameZone.Services
{
    public class GameService : Repository<Game>, IGameService
    {
        private readonly IWebHostEnvironment _environment;
        private readonly string _ImagesPath;
        private readonly ApplicationDbContext _dbContext;
        public GameService(ApplicationDbContext dbContext, IWebHostEnvironment environment) : base(dbContext)
        {
            _environment = environment;
            _ImagesPath = $"{_environment.WebRootPath}{Utilites.ImagePath}";
            _dbContext = dbContext;
        }

        public async Task<string> GameCoverPath(IFormFile cover)
        {
            var coverName = cover.FileName;

            var path = Path.Combine(_ImagesPath, coverName);

            using var strem =File.Create(path);

            await cover.CopyToAsync(strem);


            return coverName;
        }

        public async Task<IEnumerable<Game>> GamesWithCategoryAndDevices()
        {
            return await _dbContext.Games.Include(c => c.Category).
                Include(c => c.GameDevices)
                .ThenInclude(c => c.Device)
                .AsNoTracking().ToListAsync();
        }
    }
}
