using EduHome.Core.DTOS.Comment;
using EduHome.Core.DTOS.Course;
using EduHome.Data.DAl;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHomeServices.Services.Implementations
{
    public class LayoutService
    {
        private readonly EduHomeDbContext _context;

        public LayoutService(EduHomeDbContext context)
        {
            _context = context;
        }

        public Dictionary<string, string> GetSettings()
        {
            Dictionary<string, string> settings = _context.Settings.ToDictionary(s => s.key, s => s.value);

            return settings;
        }
    }
}