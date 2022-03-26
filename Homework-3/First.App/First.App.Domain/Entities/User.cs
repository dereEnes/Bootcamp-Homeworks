using System;
using System.Collections.Generic;
using System.Text;

namespace First.App.Domain.Entities
{
    public class User:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public DateTime DateOfBorn { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
