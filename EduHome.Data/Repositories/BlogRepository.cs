using EduHome.Core.Entities;
using EduHome.Core.Repositories;
using EduHome.Data.DAl;

namespace EduHome.Data.Repositories
{
    public class BlogRepository : Repository<Blog>, IBlogRepository
    {
        public BlogRepository(EduHomeDbContext context) : base(context)
        {

        }
    }
}
