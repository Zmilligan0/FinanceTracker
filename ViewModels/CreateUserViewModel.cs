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
    public class CreateUserViewModel
    {
        private readonly UserService _userService;

        public ICommand CreateUserCommand { get; }
        public ICommand NavigateToStartScreenCommand { get; }

        public string Name { get; set; }
        public string Email { get; set; }

        public CreateUserViewModel(UserService UserService)
        {
            _userService = UserService;
            CreateUserCommand = new RelayCommand(OnCreateUser);
            NavigateToStartScreenCommand = new RelayCommand(OnNavigateToStartScreen);
        }

        private void OnNavigateToStartScreen()
        {
            // Implement logic to navigate to the StartScreen
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.NavigateToStartScreen();
        }

        private void OnCreateUser()
        {
            User userToCreate = new User
            {
                Name = Name,
                Email = Email
            };


            _userService.CreateUser(userToCreate);

            OnNavigateToStartScreen();
        }
    }
}
