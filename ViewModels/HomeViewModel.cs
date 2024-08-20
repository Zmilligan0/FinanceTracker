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

        public HomeViewModel(User LoggedInUser)
        {
            CurrentUser = LoggedInUser;
            NavigateToStartScreenCommand = new RelayCommand(OnNavigateToStartScreen);
            NavigateToProfileCommand = new RelayCommand(OnNavigateToProfile);
        }

        private void OnNavigateToStartScreen()
        {
            // Implement logic to navigate to the StartScreen
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.NavigateToStartScreen();
        }

        private void OnNavigateToProfile()
        {
            // Implement logic to navigate to the Profile screen
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.NavigateToProfile();
        }
    }
}
