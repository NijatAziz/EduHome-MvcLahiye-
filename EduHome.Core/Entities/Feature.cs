using EduHome.Core.Entities.BaseEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHome.Core.Entities
{
    public class Feature : BaseEntity
    {
        public DateTime Starts { get; set; }
        public byte Duration { get; set; }
        public byte ClassDuration { get; set; }
        public string Level { get; set; }
        public string Language { get; set; }
        public int Students { get; set; }
        public string Assesments { get; set; }

        public decimal CourseFee { get; set; }


        public List<Course> Courses { get; set; }
    }
}
