using System.Threading.Tasks;
using ProyectoTestMVC.ViewModels;

namespace ProyectoTestMVC.Interfaces
{
    public interface IDashboardRepository
    {
        Task<DashboardViewModel> GetDashboardAsync(int recentTransactionCount = 5);
    }
}
