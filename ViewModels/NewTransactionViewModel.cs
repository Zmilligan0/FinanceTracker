using FinanceTracker.Models;
using FinanceTracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.ViewModels
{
    public class NewTransactionViewModel
    {
        private User _currentUser;
        private UserService _userService;
        public NewTransactionViewModel(User LoggedInUser, UserService UserService)
        {
            _currentUser = LoggedInUser;
            _userService = UserService;
        }
    }
}
