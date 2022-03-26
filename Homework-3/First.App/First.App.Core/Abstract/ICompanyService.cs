using First.App.Business.DTOs;
using First.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace First.App.Business.Abstract
{
    public interface ICompanyService
    {
        Company GetCompany(Expression<Func<Company, bool>> filter);
        List<Company> GetAllCompany();
        void AddCompany(Company company);
        void UpdateCompany(Company company);
        void DeleteCompany(Company company);

    }
}
