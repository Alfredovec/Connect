using Connect.Data.Entities;
using Connect.Data.Repositories.Interfaces;

namespace Connect.Data.Repositories
{
    public class LanguageRepository : Repository<LanguageEntity>, ILanguageRepository
    {
        public LanguageRepository(ConnectDbContext context) : base(context) { }
    }
}
