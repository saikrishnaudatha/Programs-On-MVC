using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HandsOnMVCUsingModelValidations.Models
{
    public class User
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = " Email is required")]
        [EmailAddress(ErrorMessage = "Enter valid mail Id")]
        public string Email { get; set; }

       [DataType (DataType.Date)]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Mobile Number is required")]
        [RegularExpression(@"[6-9)]\d{9}", ErrorMessage = "Invalid Mobile No")]
        public string Mobile { get; set; }

        public string Country { get; set; }

       [Required(ErrorMessage ="UserName is required")]
        public string Uname { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Pwd { get; set; }

    }
}
