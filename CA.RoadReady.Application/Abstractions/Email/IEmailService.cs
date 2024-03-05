using CA.RoadReady.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.RoadReady.Application.Abstractions.Email
{
    public interface IEmailService
    {
        Task SendAsync(CA.RoadReady.Domain.Users.Email recipient, string subject, string body);

    }
}
