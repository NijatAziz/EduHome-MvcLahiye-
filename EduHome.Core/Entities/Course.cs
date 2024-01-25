using EduHome.Core.Entities.BaseEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHome.Core.Entities
{
    public class Course : BaseEntity
    {
        public string Title { get; set; }
        public string Desc { get; set; }
        public string About { get; set; }
        public string HowToApply { get; set; }

        public string Certification { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int FeatureId { get; set; }
        public Feature Feature { get; set; }

    }

}