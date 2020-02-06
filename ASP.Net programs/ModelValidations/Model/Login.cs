using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;   //For displaying our required  property name on UI

namespace HandsOnModelValidations.Models
{
    public class Login
    {
        [Required(ErrorMessage ="User Name is Required")]
        [DisplayName("UserName")]
        public string Uname { get; set; }
        [Required(ErrorMessage ="Password is Required")]
        [DisplayName("Password")]
        public string Pwd { get; set; }
    }
}
