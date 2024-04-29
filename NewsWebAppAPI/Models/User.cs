using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace NewsWebAppAPI.Models
{
        [Table("Users")]
        public class User
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
            public int Id { get; set; }
            [Column("name")]    
            [StringLength(100)]
            public string FullName { get; set; } = "";
            [Column("phone_number")]
            [StringLength(15)]
            public string PhoneNumber { get; set; } = "";
            [Column("address")]    
            [StringLength(64)]
            public string Address { get; set; } = "";
            [Column("hash_password")]
            [Required]
            [StringLength(200)]
            public string HashPassword { get; set; } = "";
            [Column("created_at")]
            public DateTime? CreatedAt { get; set; }
            [Column("updated_at")]
            public DateTime? UpdatedAt { get; set; }
            //[Column("active")]  
           // public bool Active { get; set; }
            [Column("date_of_birth")]
            public DateTime? DateOfBirth { get; set; }
            //[Column("facbook_account_id")]
            //public int FacebookAccountId { get; set; }
            //[Column("google_account_id")]
            //public int GoogleAccountId { get; set; }
            [Column("role_id")]
            public int RoleId { get; set; }
            [Required]
            [EmailAddress]
            [StringLength(255)]
            [Column("email")]
            public string Email { get; set; } = "";
            [StringLength(255)]
            [Column("profile_image")]
            public string ProfileImage { get; set; } = "";
        }
}

