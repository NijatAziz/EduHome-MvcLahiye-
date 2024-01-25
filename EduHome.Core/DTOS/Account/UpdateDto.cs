using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHome.Core.DTOS.Account
{
    public record UpdateDto
    {
        public string UserName { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string? OldPassword { get; set; }
        public string? NewPassword { get; set; }
    }
}
