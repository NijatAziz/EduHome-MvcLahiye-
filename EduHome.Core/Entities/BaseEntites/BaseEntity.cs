﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHome.Core.Entities.BaseEntites
{
    public class BaseEntity
    {

        public int ID { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}