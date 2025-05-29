using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoTestMVC.Data;
using ProyectoTestMVC.Interfaces;
using ProyectoTestMVC.Models;

namespace ProyectoTestMVC.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDbContext _db;
        public TransactionRepository(ApplicationDbContext db)
            => _db = db;

        public async Task<IEnumerable<Transaction>> GetAllAsync()
            => await _db.Transactions.ToListAsync();

        public async Task<Transaction?> GetByIdAsync(int id)
            => await _db.Transactions.FirstOrDefaultAsync(t => t.Id == id);

        public async Task AddAsync(Transaction transaction)
        {
            _db.Transactions.Add(transaction);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Transaction transaction)
        {
            _db.Transactions.Update(transaction);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _db.Transactions.FindAsync(id);
            if (entity != null)
            {
                _db.Transactions.Remove(entity);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
            => await _db.Transactions.AnyAsync(t => t.Id == id);
    }
}
