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
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }


        //TODO: Set default date to today
        // Add labels to show what each box is for

        public NewTransactionViewModel(User LoggedInUser, TransactionService TransactionService)
        {
            _currentUser = LoggedInUser;
            _transactionService = TransactionService;

            NavigateToTransactionsCommand = new RelayCommand(OnNavigateToTransactions);
            AddTransactionCommand = new RelayCommand(OnAddTransaction);

            // Initialize the properties
            Categories = _transactionService.GetCategories();
            SelectedCategory = Categories.FirstOrDefault();
        }

        private void OnAddTransaction()
        {
            Transaction transactionToAdd = new Transaction
            {
                CatergoryId = SelectedCategory.Id,
                Description = Description,
                Amount = Amount,
                Date = Date,
                UserId = _currentUser.Id
            };

            _transactionService.AddTransaction(transactionToAdd);
            OnNavigateToTransactions();


        }

        private void OnNavigateToTransactions()
        {
            mainWindow.NavigateToTransactions();
        }
    }
}
