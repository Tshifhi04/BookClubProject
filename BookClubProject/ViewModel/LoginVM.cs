﻿using System.ComponentModel.DataAnnotations;

namespace BookClubProject.ViewModel
{
    public class LoginVM
    {
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = " Please enter your Email Address")]

        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]

        public string Password { get; set; }
    }
}
