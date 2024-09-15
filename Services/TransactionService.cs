using FinanceTracker.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public void UpdateTransaction(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public void DeleteTransaction(int transactionId)
        {
            //delete transaction from database using transactionId 
            var transaction = _context.Transactions.FirstOrDefault(transaction => transaction.Id == transactionId);
            if (transaction != null)
            {
                _context.Transactions.Remove(transaction);
                _context.SaveChanges();
            }


        }

        public void GetTransaction()
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Transaction> GetTransactions(int UserId)
        {

            return new ObservableCollection<Transaction>(_context.Transactions.Where(transaction => transaction.UserId == UserId).ToList());
        }


        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }







    }
}
