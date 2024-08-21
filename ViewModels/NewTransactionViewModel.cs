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
    public class NewTransactionViewModel
    {
        private User _currentUser;
        private TransactionService _transactionService;
        public ICommand NavigateToTransactionsCommand { get; }
        public ICommand AddTransactionCommand { get; }

        private MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;

        // Properties for binding to the boxes in NewTransaction.xaml
        public List<Catergory> Categories { get; set; }
        public Catergory SelectedCategory { get; set; }
        public Transaction Transaction { get; set; }

        public NewTransactionViewModel(User LoggedInUser, TransactionService TransactionService)
        {
            _currentUser = LoggedInUser;
            _transactionService = TransactionService;

            NavigateToTransactionsCommand = new RelayCommand(OnNavigateToTransactions);
            AddTransactionCommand = new RelayCommand(OnAddTransaction);

            // Initialize the properties
            Categories = _transactionService.GetCategories();
            SelectedCategory = Categories.FirstOrDefault();
            Transaction = new Transaction();
        }

        private void OnAddTransaction()
        {
            //Create a new transaction and use _transactionService to add it to the user's transactions


            Transaction.Catergory = SelectedCategory;
            _transactionService.AddTransaction(_currentUser, Transaction);
        }

        private void OnNavigateToTransactions()
        {
            mainWindow.NavigateToTransactions();
        }
    }
}
