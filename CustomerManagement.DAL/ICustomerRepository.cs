using CustomerManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.DAL
{
    public interface ICustomerRepository
    {
        void Add(Customer customer);
        Customer GetById(int customerId);
        void Update(Customer customer);
        void Delete(int customerId);
        IEnumerable<Customer> GetAll();
    }
}
