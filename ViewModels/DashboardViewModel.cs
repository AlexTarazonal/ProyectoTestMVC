using System;
using System.Collections.Generic;

namespace ProyectoTestMVC.ViewModels
{
    public class DashboardViewModel
    {
        public int TotalProducts { get; set; }
        public int TotalCategories { get; set; }
        public int TotalWarehouses { get; set; }
        public int TotalProviders { get; set; }
        public int LowStockAlerts { get; set; }

        public List<TransactionDto> RecentTransactions { get; set; } = new();

        public class TransactionDto
        {
            public DateTime OccurredAt { get; set; }
            public string ProductName { get; set; } = string.Empty;
            public string WarehouseName { get; set; } = string.Empty;
            public int Quantity { get; set; }
            public string Type { get; set; } = string.Empty;
        }
    }
}
