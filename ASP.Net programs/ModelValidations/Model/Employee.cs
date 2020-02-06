using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace HandsOnModelValidations.Models
{
    public class Employee
    {

        [Required(ErrorMessage = "Plz Enter id")]
        [DisplayName("Employee ID")]
        public int ID { get; set; }



        [Required(ErrorMessage = "Please Enter Name")]
        [StringLength(maximumLength: 20, MinimumLength = 4, ErrorMessage = "Name should between 4 to 20 ")]
        public string Name { get; set; }



        [EmailAddress(ErrorMessage = "Inavalid Email id")]
        public string Email { get; set; }



        [RegularExpression(@"[6-9)]\d{9}", ErrorMessage = "Invalid Mobile No")]
        [Required(ErrorMessage = "mobile number is required")]
        public string Mobile { get; set; }


        [Required(ErrorMessage = "User name no is required")]
        public string Uname { get; set; }


        [Required(ErrorMessage = "Password is required")]
        public string Pwd { get; set; }
        [Compare("Pwd", ErrorMessage = "Password mismatch")]
        public string Cpwd { get; set; }



    }
}
