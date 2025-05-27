using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoTestMVC.Models
{
    [Table("stocks")]
    public class Stock
    {
        [Column("product_id")]
        public int ProductId { get; set; }

        [Column("warehouse_id")]
        public int WarehouseId { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
