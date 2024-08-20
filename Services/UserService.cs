using FinanceTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Services
{
    public class UserService
    {
        private readonly AppDbContext _context;

        public UserService()
        {
            _context = new AppDbContext();
        }

        public IEnumerable<User> GetUsers()
        {
            if (_context.Users.Any() == false)
            {
                return null;
            };

            return [.. _context.Users];
        }
    }
}
