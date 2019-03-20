using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypingStudy
{
    public class Arguments
    {
    }
    public class UserArguments : Arguments
    {
        public string Username { get; }
        public bool IsGuest { get; }
        public UserArguments(string username)
        {
            if(string.IsNullOrEmpty(username) && string.IsNullOrWhiteSpace(username))
            {
                IsGuest = true;
                Username = "Guest";
            }
            else
            {
                IsGuest = false;
                Username = username;
            }
        }
    }
}
