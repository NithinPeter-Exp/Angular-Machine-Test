using System;
using System.Collections.Generic;

namespace AssetManagementSystem.Models
{
    public partial class Login
    {
        public Login()
        {
            UserRegistration = new HashSet<UserRegistration>();
        }

        public int LId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }

        public virtual ICollection<UserRegistration> UserRegistration { get; set; }
    }
}
