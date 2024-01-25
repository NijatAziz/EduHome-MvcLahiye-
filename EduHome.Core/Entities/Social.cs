using EduHome.Core.Entities.BaseEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHome.Core.Entities
{
    public class Social : BaseEntity
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
