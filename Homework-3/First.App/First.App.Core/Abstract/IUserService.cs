using First.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace First.App.Business.Abstract
{
    public interface IUserService
    {
        User GetUser(Expression<Func<User, bool>> filter);
        List<User> GetAllUsers();
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}
