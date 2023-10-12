using ArtCorp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtCorp.Domain.Exceptions
{
    public class InvalidLoginException : Exception
    {
        public LoginModel Login { get; set; }

        public InvalidLoginException(string msg, LoginModel login) : base(msg)
        {
            this.Login = login;
        }
    }
}
