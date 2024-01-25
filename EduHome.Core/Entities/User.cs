using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHome.Core.Entities
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        public List<Comment> Comments { get; set; }



        public User()
        {
            Comments = new();
        }
    }
}