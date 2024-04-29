using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NewsWebAppAPI.ModelView
{
	public class UserModelView
	{       
            public string FullName { get; set; } = "";
            public string PhoneNumber { get; set; } = "";
            public string Address { get; set; } = "";
            [Required]
            [PasswordPropertyText]
            public string Password { get; set; } = "";
            public DateTime? DateOfBirth { get; set; }
            public int RoleId { get; set; }
            [Required]
            [EmailAddress]
            [StringLength(255)]
            public string Email { get; set; } = "";
            [StringLength(255)]
            public string ProfileImage { get; set; } = "";
	}
}

