﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHome.Core.DTOS.Setting
{
    public class SettingPostDto
    {
        public string Key { get; set; } = null!;
        public string Value { get; set; } = null!;
    }
}