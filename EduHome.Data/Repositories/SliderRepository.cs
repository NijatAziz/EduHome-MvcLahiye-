using EduHome.Core.Entities;
using EduHome.Core.Repositories;
using EduHome.Data.DAl;
using NuGet.Protocol.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHome.Data.Repositories
{
    public class SliderRepository : Repository<Slider>, ISliderRepository
    {
        public SliderRepository(EduHomeDbContext context) : base(context)
        {

        }
    }
}