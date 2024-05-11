using CustomerManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.BLL
{
    public interface ICustomerService
    {
        void AddCustomer(Customer customer);
        void RemoveCustomer(int customerId);
        void UpdateCustomer(Customer customer);
        Customer GetCustomer(int customerId);
        IEnumerable<Customer> GetAllCustomers();
    }
}
