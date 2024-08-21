using FinanceTracker.Models;
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
    public class HomeViewModel
    {
        public User CurrentUser { get; }

        public ICommand NavigateToStartScreenCommand { get; }
        public ICommand NavigateToProfileCommand { get; }

        public ICommand NavigateToTransactionsCommand { get; }

        // mainwindow ref
        private MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;

        public HomeViewModel(User LoggedInUser)
        {
            CurrentUser = LoggedInUser;
            NavigateToStartScreenCommand = new RelayCommand(OnNavigateToStartScreen);
            NavigateToProfileCommand = new RelayCommand(OnNavigateToProfile);
            NavigateToTransactionsCommand = new RelayCommand(OnNavigateToTransactions);
        }

        private void OnNavigateToTransactions()
        {
            mainWindow.NavigateToTransactions();
        }

        private void OnNavigateToStartScreen()
        {
            mainWindow.NavigateToStartScreen();
        }

        private void OnNavigateToProfile()
        {

            mainWindow.NavigateToProfile();
        }
    }
}
