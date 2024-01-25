using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHome.Core.DTOS.Category
{
    public class CategoryGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int BlogCount { get; set; }
        public int CourceCount { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
