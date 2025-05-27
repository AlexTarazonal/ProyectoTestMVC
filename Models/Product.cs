using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoTestMVC.Models
{
    [Table("products")]
    public class Product
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; } = null!;

        [Column("description")]
        public string Description { get; set; } = null!;

        [Column("price")]
        public decimal Price { get; set; }

        [Column("barcode")]
        public string? Barcode { get; set; }

        [Column("entry_date")]
        public DateOnly EntryDate { get; set; }

        [Column("category_id")]
        public int CategoryId { get; set; }

        [Column("minimum_stock")]
        public int MinimumStock { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
