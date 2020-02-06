using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoOnCookies.Models
{
    public class UserAccount
    {
        [Key]
        public string UserName { get; set; }

        [DataType("Password")]
        public string Password { get; set; }
        public string Email{ get; set; }
        public string Role { get; set; }
        public string Status { get; set; }


    }
}
