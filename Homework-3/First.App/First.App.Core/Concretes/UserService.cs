using First.App.Business.Abstract;
using First.App.DataAccess.EntityFramework.Repository.Abstracts;
using First.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace First.App.Business.Concretes
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;

        private readonly IUnitOfWork _unitOfWork;
        public UserService(IRepository<User> repository, IUnitOfWork unitOfWork)
        {
            this._repository = repository;
            this._unitOfWork = unitOfWork;
        }

        public void AddUser(User user)
        {
            _repository.Add(user);
            _unitOfWork.Commit();
        }

        public void DeleteUser(User user)
        {
            _repository.Delete(user);
            _unitOfWork.Commit();
        }

        public List<User> GetAllUsers()
        {
            return _repository.Get().ToList();
        }

        public User GetUser(Expression<Func<User, bool>> filter)
        {
            return _repository.Get(filter);
        }

        public void UpdateUser(User user)
        {
            _repository.Update(user);
            _unitOfWork.Commit();
        }
    }
}
