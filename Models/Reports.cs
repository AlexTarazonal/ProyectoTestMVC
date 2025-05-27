using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoTestMVC.Models
{
    [Table("reports")]
    public class Report
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("transaction_id")]
        public int TransactionId { get; set; }

        [Column("generated_at")]
        public DateTime GeneratedAt { get; set; }

        [Column("format")]
        public string Format { get; set; } = null!;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
