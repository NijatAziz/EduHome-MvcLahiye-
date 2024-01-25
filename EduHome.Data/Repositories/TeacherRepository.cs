using EduHome.Core.Entities;
using EduHome.Core.Repositories;
using EduHome.Data.DAl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHome.Data.Repositories
{
    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(EduHomeDbContext context) : base(context)
        {

        }
    }
}
