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
    public class StartScreenViewModel
    {
        private readonly UserService _userService;

        public ObservableCollection<UserCardViewModel> Users { get; set; }

        public ICommand AddUserCommand { get; }

        public ICommand QuitApplicationCommand { get; }

        public StartScreenViewModel(UserService UserService)
        {
            _userService = UserService;
            var users = _userService.GetUsers();
            Users = new ObservableCollection<UserCardViewModel>(
                users.Select(user => new UserCardViewModel(user))
            );

            AddUserCommand = new RelayCommand(OnAddUser);
            QuitApplicationCommand = new RelayCommand(OnQuitApplication);
        }

        private void OnQuitApplication()
        {

            Application.Current.Shutdown();
        }

        private void OnAddUser()
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.NavigateToCreateUser();
        }
    }
}
