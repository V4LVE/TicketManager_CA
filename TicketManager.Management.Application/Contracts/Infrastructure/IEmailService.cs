using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManager.Management.Application.Models.Mail;

namespace TicketManager.Management.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        /// <summary>
        /// Specify whether to send an email or not
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<bool> SendMail(Email email);
    }
}
