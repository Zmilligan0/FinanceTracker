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
        private UserService _userService;

        public ICommand NavigateToHomeCommand { get; }
        public ICommand AddTransactionCommand { get; }

        private MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;

        public TransactionsScreenViewModel(User LoggedInUser, UserService UserService)
        {
            _currentUser = LoggedInUser;
            _userService = UserService;

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
