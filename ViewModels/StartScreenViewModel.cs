using FinanceTracker.Models;
using FinanceTracker.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.ViewModels
{
    public class StartScreenViewModel
    {
        private readonly UserService _userService;

        public ObservableCollection<UserCardViewModel> Users { get; set; }

        public StartScreenViewModel()
        {
            _userService = new UserService();
            var users = _userService.GetUsers();
            Users = new ObservableCollection<UserCardViewModel>(
                users.Select(user => new UserCardViewModel(user))
            );
        }
    }
}
