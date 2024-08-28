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


        // Method to get CategoryName from CategoryId
        public string GetCategoryName(int categoryId)
        {
            // Replace with actual logic or data retrieval
            var categories = new Dictionary<int, string>
            {
                { 1, "Food" },
                { 2, "Transport" },
                { 3, "Entertainment" },
                { 4, "Utilities" },
                { 5, "Rent" },
                { 6, "Other" }
            };

            return categories.TryGetValue(categoryId, out var categoryName) ? categoryName : "Unknown";
        }


    }
}
