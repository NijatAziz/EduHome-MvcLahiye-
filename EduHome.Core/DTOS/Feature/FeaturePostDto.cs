using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHome.Core.DTOS.Feature
{
    public class FeaturePostDto
    {
        public DateTime Starts { get; set; }
        public byte Duration { get; set; }
        public byte ClassDuration { get; set; }
        public string Level { get; set; }
        public string Language { get; set; }
        public int Students { get; set; }
        public string Assesments { get; set; }

        public decimal CourseFee { get; set; }
    }
}