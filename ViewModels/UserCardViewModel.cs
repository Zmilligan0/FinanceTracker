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
    public class UserCardViewModel
    {
        public User User { get; }
        public ICommand SelectUserCommand { get; }

        public UserCardViewModel(User user)
        {
            User = user;
            SelectUserCommand = new RelayCommand(OnSelectUser);
        }

        private void OnSelectUser()
        {
            // Implement logic to handle user selection.
            // For example, you might notify the MainWindow of the selected user
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.SelectedUser = User;

            // Navigate to Home.xaml
            mainWindow.NavigateToHome();
        }
    }
}

