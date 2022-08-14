using CleanArchitecture.Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Contratcs.Infrastructure
{
    public interface IEmailSender 
    {
        Task<bool> SendEmail(Email email);
    }
}
