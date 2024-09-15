using FinanceTracker.Models;
using FinanceTracker.Services;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ObservableCollection<Transaction> Transactions { get; set; }
        public ICommand NavigateToHomeCommand { get; }
        public ICommand AddTransactionCommand { get; }
        public ICommand EditTransactionCommand { get; }
        public ICommand DeleteTransactionCommand { get; }

        private MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;

        public TransactionsScreenViewModel(User LoggedInUser, TransactionService TransactionService)
        {
            _currentUser = LoggedInUser;
            _transactionService = TransactionService;
            Transactions = _transactionService.GetTransactions(_currentUser.Id);

            NavigateToHomeCommand = new RelayCommand(OnNavigateToHome);
            AddTransactionCommand = new RelayCommand(OnAddTransaction);
            EditTransactionCommand = new RelayCommand<Transaction>(OnEditTransaction);
            DeleteTransactionCommand = new RelayCommand<Transaction>(OnDeleteTransaction);
        }

        private void OnAddTransaction()
        {
            mainWindow.NavigateToNewTransaction();
        }

        private void OnNavigateToHome()
        {
            mainWindow.NavigateToHome();
        }

        private void OnEditTransaction(Transaction transaction)
        {
            mainWindow.NavigateToEditTransaction(transaction);
        }

        private void OnDeleteTransaction(Transaction transaction)
        {
            if (transaction != null)
            {
                var result = MessageBox.Show($"Are you sure you want to delete the transaction?\n\n" +
                                             $"Category: {GetCategoryName(transaction.CategoryId)}\n" +
                                             $"Description: {transaction.Description}\n" +
                                             $"Amount: {transaction.Amount:C}\n" +
                                             $"Date: {transaction.Date:d}",
                                             "Delete Transaction",
                                             MessageBoxButton.YesNo,
                                             MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    _transactionService.DeleteTransaction(transaction.Id);

                    // Remove the transaction from the ObservableCollection
                    Transactions.Remove(transaction);
                }
            }
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
