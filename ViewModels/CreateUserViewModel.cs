using FinanceTracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.ViewModels
{
    public class CreateUserViewModel
    {
        private readonly UserService _userService;

        public CreateUserViewModel(UserService UserService)
        {
            _userService = UserService;
        }
    }
}
