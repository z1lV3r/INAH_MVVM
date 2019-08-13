using System;

namespace INAH.Services
{
    internal class SecurityService
    {
        internal bool authenticate(string email, string password)
        {
            return true;
        }

        internal string cypherPass(string password)
        {
            return password;
        }
    }
}