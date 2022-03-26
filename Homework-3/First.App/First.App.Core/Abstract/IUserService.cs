using First.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace First.App.Business.Abstract
{
    public interface IUserService
    {
        User GetCompany(Expression<Func<User, bool>> filter);
        List<User> GetAllCompany();
        void AddCompany(User company);
        void UpdateCompany(User company);
        void DeleteCompany(User company);
    }
}
