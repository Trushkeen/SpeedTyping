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
        public double? Score { get; set; }
        public UserArguments(string username, double? score = null)
        {
            if (string.IsNullOrEmpty(username) && string.IsNullOrWhiteSpace(username))
            {
                IsGuest = true;
                Username = "Guest";
                Score = score;
            }
            else
            {
                IsGuest = false;
                Username = username;
                Score = score;
            }
        }
    }
}
