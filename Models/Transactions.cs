using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoTestMVC.Models
{
    [Table("transactions")]
    public class Transaction
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("occurred_at")]
        public DateTime OccurredAt { get; set; }

        [Column("product_id")]
        public int ProductId { get; set; }

        [Column("warehouse_id")]
        public int WarehouseId { get; set; }

        [Column("provider_id")]
        public int? ProviderId { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("type")]
        public string Type { get; set; } = null!;

        [Column("client_name")]
        public string? ClientName { get; set; }

        [Column("created_by")]
        public int? CreatedBy { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
