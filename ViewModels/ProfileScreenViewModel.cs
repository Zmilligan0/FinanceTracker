using FinanceTracker.Models;
using FinanceTracker.Services;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FinanceTracker.ViewModels
{

    public class ProfileScreenViewModel
    {
        public User OriginalUser { get; }
        public User CopyUser { get; private set; }
        private UserService _userService;
        //Command to save changes to the user profile
        public ICommand SaveChangesCommand { get; }
        public ICommand DeleteUserCommand { get; }

        public ICommand NavigateToHomeCommand { get; }



        public ProfileScreenViewModel(User LoggedInUser)
        {
            _userService = new UserService();
            OriginalUser = LoggedInUser;
            // Create a copy of the original user data
            CopyUser = new User
            {
                Id = OriginalUser.Id,
                Name = OriginalUser.Name,
                Email = OriginalUser.Email,
            };

            SaveChangesCommand = new RelayCommand(OnSaveChanges);
            DeleteUserCommand = new RelayCommand(OnDeleteUser);
            NavigateToHomeCommand = new RelayCommand(OnNavigateToHome);

        }

        private void OnSaveChanges()
        {
           
            // Update the original user with the changes from CopyUser
            OriginalUser.Name = CopyUser.Name;
            OriginalUser.Email = CopyUser.Email;
            _userService.UpdateUser(OriginalUser);
            OnNavigateToHome();
            Console.WriteLine("Changes saved successfully!");
        }

        private void OnDeleteUser()
        {
            _userService.DeleteUser(CopyUser.Id);
            OnNavigateToHome();
            Console.WriteLine("User account deleted!");
        }

        private void OnNavigateToHome()
        {
            MainWindow mainWindow = (MainWindow)System.Windows.Application.Current.MainWindow;
            mainWindow.NavigateToHome();
        }
    }
}