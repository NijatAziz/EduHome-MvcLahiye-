using EduHome.Core.Entities.BaseEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHome.Core.Entities
{
    public class Setting : BaseEntity
    {
        public string key { get; set; }
        public string value { get; set; }
    }
}