// Models/Product.cs
using System;
using System.Collections.Generic;
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
        public Category? Category { get; set; }

        [Column("minimum_stock")]
        public int MinimumStock { get; set; }

        // Navegación a Stocks
        public ICollection<Stock> Stocks { get; set; } = new List<Stock>();

        // Navegación a Transactions
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}