using FinanceTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.ViewModels
{
    public class HomeViewModel
    {
        public User SelectedUser { get; }

        public HomeViewModel(User selectedUser)
        {
            SelectedUser = selectedUser;
        }
    }
}
