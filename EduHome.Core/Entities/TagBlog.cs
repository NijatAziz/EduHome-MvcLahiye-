using EduHome.Core.Entities.BaseEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHome.Core.Entities
{
    public class TagBlog: BaseEntity
    {
        public int TagId { get; set; } 
        public int BlogId { get; set; } 
    }
}
