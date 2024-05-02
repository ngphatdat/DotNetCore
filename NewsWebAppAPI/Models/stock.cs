using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsWebAppAPI.Models
{
    [Table("stock", Schema = "dbo")]
    public class Stock
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("stock_id")]
        public int StockId { get; set; }

        [Required]
        [StringLength(200)]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        [Column("symbol")]
        public string Symbol { get; set; }

        [Required]
        [StringLength(200)]
        [Column("company_name")]
        public string CompanyName { get; set; }

        [Required]
        [Column("price")]
        public decimal Price { get; set; }

        [Required]
        [Column("quantity")]
        public int Quantity { get; set; }

        [Required]
        [Column("market_cap")]
        public decimal MarketCap { get; set; }

        [Required]
        [StringLength(200)]
        [Column("secror")]
        public string Secror { get; set; }

        [Required]
        [StringLength(200)]
        [Column("inductry")]
        public string Inductry { get; set; }

        [Required]
        [StringLength(200)]
        [Column("secror_en")]
        public string SecrorEn { get; set; }

        [Required]
        [StringLength(200)]
        [Column("inductry_en")]
        public string InductryEn { get; set; }

        [Required]
        [StringLength(200)]
        [Column("stock_type")]
        public string StockType { get; set; }

        [Required]
        [Column("rank")]
        public int Rank { get; set; }

        [Required]
        [StringLength(200)]
        [Column("rank_source")]
        public string RankSource { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}