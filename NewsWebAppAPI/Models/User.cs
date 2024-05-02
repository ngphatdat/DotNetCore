using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsWebAppAPI.Models
{
    [Table("users", Schema = "dbo")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("user_id")]
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        [Column("user_name")]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(200)]
        [Column("email")]
        public string Email { get; set; }
        [Required]
        [StringLength(200)]
        [Column("hash_password")]
        public string HashPassword { get; set; }
        [Required]
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Required]
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [Required]
        [StringLength(200)]
        [Column("contry")]
        public string Country { get; set; }

        [Required]
        [Column("date_of_birth")]
        public DateTime? DateOfBirth { get; set; }

        [Column("role_id")]
        public int? RoleId { get; set; }

        [Column("is_active")]
        public int? IsActive { get; set; }
    }
}