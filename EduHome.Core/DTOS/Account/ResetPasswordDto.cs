using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHome.Core.DTOS.Account
{
    public class ResetPasswordDto
    {
        public string Email { get; set; } = null!;
        public string Token { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
