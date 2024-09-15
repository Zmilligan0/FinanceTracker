using FinanceTracker.Models;
using FinanceTracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.ViewModels
{
    public class EditTransactionViewModel
    {
        private User _currentUser;
        private TransactionService _transactionService;
        private Transaction _transaction;

        public EditTransactionViewModel(User LoggedInUser, TransactionService TransactionService, Transaction Transaction)
        {
            _currentUser = LoggedInUser;
            _transactionService = TransactionService;
            _transaction = Transaction;

        }
    }
}
