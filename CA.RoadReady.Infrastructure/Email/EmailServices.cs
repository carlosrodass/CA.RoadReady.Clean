using CA.RoadReady.Application.Abstractions.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.RoadReady.Infrastructure.Email
{
    internal sealed class EmailServices : IEmailService
    {
        public Task SendAsync(Domain.Users.Email recipient, string subject, string body)
        {


            return Task.CompletedTask;

        }
    }
}
