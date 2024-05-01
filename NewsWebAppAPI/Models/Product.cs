using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsWebAppAPI.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("content")]
        public string Content { get; set; }
        [Column("title")]
        [MaxLength]
        public string Title { get; set; }
        [Column("description")]
        [MaxLength]
        public string Description { get; set; }
        [Column("thumbnail")]
        [MaxLength]
        public string Thumbnail { get; set; }
        [Column("category_id")]   
        public int CategoryId { get; set; }
        [MaxLength]
        public string ModifiedBy { get; set; }
        [Column("created_at")]                
        public DateTime? CreatedAt { get; set; }
         [Column("updated_at")]                              
        public DateTime? UpdatedAt { get; set; }
        [Column("status")]
        public int? Status { get; set; }
    }
}