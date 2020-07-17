using API.Persistence.Contexts;

namespace API.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext context;

        protected BaseRepository(AppDbContext context)
        {
            this.context = context;
        }
    }
}