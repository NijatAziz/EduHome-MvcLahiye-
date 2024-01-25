using EduHome.Core.Entities.BaseEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHome.Core.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public List<Course> Course { get; set; }
    }
}