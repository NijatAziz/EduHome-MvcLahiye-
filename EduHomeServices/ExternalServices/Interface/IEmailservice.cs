using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHomeServices.ExternalServices.Interface
{
    public interface IEmailService
    {
        public Task SendEmail(string to, string subject, string body);

    }
}
