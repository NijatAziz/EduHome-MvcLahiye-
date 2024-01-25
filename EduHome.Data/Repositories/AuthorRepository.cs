using EduHome.Core.Entities;
using EduHome.Core.Repositories;
using EduHome.Data.DAl;

namespace EduHome.Data.Repositories
{
    public class AuthorRepository:Repository<Author>,IAuthorRepository
    {
        public AuthorRepository(EduHomeDbContext context) : base(context)
        {
            
        }
    }
}
