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
                //Return an empty IEnumerable if there are no users in the database
                return new List<User>();
            }

            return [.. _context.Users];
        }

        public User GetUser(int id)
        {
            return _context.Users.FirstOrDefault(user => user.Id == id);
        }

        public User DeleteUser(int id)
        {
            var user = GetUser(id);
            if (user == null)
            {
                return null;
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
            return user;
        }

        public User UpdateUser(User updatedUser)
        {
            var user = GetUser(updatedUser.Id);
            if (user == null)
            {
                return null;
            }

            user.Name = updatedUser.Name;
            user.Email = updatedUser.Email;

            _context.SaveChanges();
            return user;
        }

        public User CreateUser(User newUser)
        {
            _context.Users.Add(newUser);
            _context.SaveChanges();
            return newUser;
        }
    }
}
