using System.Configuration;
using System.Data.Entity;
using System.Linq;
using NgTodoList.Data.Context;
using NgTodoList.Domain.Repositories;
using NgTodoList.Domain;

namespace NgTodoList.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private NgTodoListDataContext _context;

        public UserRepository(NgTodoListDataContext context)
        {
            _context = context;
        }

        public User Get(string email)
        {
            return _context.Users.FirstOrDefault(x => x.Email.ToLower() == email.ToLower()); 
        }

        public void SaveOrUpdate(User user)
        {
            if (user.Id == 0)
                _context.Users.Add(user);
            else
                _context.Entry<User>(user).State = EntityState.Modified;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Users.Remove(_context.Users.Find(id));
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}