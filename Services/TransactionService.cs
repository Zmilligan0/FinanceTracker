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

        public void AddTransaction(User user, Transaction transaction)
        {

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (transaction == null)
            {
                throw new ArgumentNullException(nameof(transaction));
            }
            //Create a new transaction using the user and transaction object
            var newTransaction = new Transaction
            {
                UserId = user.Id,
                Amount = transaction.Amount,
                Description = transaction.Description,
                Date = transaction.Date,
                Catergory = transaction.Catergory,
            };

            //Add the transaction to the database
            _context.Transactions.Add(newTransaction);

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


        public List<Catergory> GetCategories()
        {
            List<Catergory> categories = new List<Catergory>
            {
                new Catergory { Id = 1, Name = "Food" },
                new Catergory { Id = 2, Name = "Transportation" },
                new Catergory { Id = 3, Name = "Entertainment" }
            };

            return categories;
        }





    }
}
