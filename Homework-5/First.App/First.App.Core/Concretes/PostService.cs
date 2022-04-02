using First.App.Business.Abstract;
using First.App.DataAccess.EntityFramework.Repository.Abstracts;
using First.App.DataAccess.EntityFramework.Repository.Concretes;
using First.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace First.App.Business.Concretes
{
    public class PostService : IPostService
    {
        //private readonly IRepository<Post> _repository;
        private readonly PostRepository<Post> repo;
        private readonly IUnitOfWork _unitOfWork;

        public PostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            //_repository = repository;
            repo = new PostRepository<Post>(_unitOfWork);
        }


        public void Add(Post post)
        {
            repo.Add(post);
            _unitOfWork.Commit();
        }

    }
}
