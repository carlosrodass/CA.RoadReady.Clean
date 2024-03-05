using CA.RoadReady.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.RoadReady.Domain.Users
{
    public static class UserErrors
    {

        public static readonly Error NotFound = new Error(
            "User.NotFound",
            "User not found"
            );


        public static readonly Error InvalidCredentials = new Error(
            "User.InvalidCredentials",
            "Wrong user credentials"
            );

    }
}
