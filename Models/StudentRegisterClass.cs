using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Questionnaire.Models
{
    public class StudentRegisterClass
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int MobileNumber { get; set; }
        [Required]
        public string UserPassword { get; set; }
        [Required]
        public string DOB { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string LoginUserName { get; set; }
        [Required]
        public String LoginPassword { get; set; }
    }
}
