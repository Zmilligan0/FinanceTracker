using FinanceTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Services
{
    public class TransactionService
    {

        private readonly AppDbContext _context;
        public TransactionService()
        {
            _context = new AppDbContext();
        }

        public void AddTransaction(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            _context.SaveChanges();

        }

        public void UpdateTransaction()
        {
            throw new NotImplementedException();
        }

        public void DeleteTransaction()
        {
            throw new NotImplementedException();
        }

        public void GetTransaction()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Transaction> GetTransactions(int UserId)
        {

            return _context.Transactions.Where(transaction => transaction.UserId == UserId).ToList();
        }


        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }







    }
}
