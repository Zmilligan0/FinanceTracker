using FinanceTracker.Models;
using FinanceTracker.Services;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FinanceTracker.ViewModels
{
    public class TransactionsScreenViewModel
    {
        private User _currentUser;
        private TransactionService _transactionService;

        //properties for binding Transactions
        public IEnumerable<Transaction> Transactions { get; set; }

        public ICommand NavigateToHomeCommand { get; }
        public ICommand AddTransactionCommand { get; }

        private MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;

        public TransactionsScreenViewModel(User LoggedInUser, TransactionService TransactionService)
        {
            _currentUser = LoggedInUser;
            _transactionService = TransactionService;
            Transactions = _transactionService.GetTransactions(_currentUser.Id);


            NavigateToHomeCommand = new RelayCommand(OnNavigateToHome);
            AddTransactionCommand = new RelayCommand(OnAddTransaction);

        }

        private void OnAddTransaction()
        {
            mainWindow.NavigateToNewTransaction();
        }

        private void OnNavigateToHome()
        {
            mainWindow.NavigateToHome();
        }
    }
}
