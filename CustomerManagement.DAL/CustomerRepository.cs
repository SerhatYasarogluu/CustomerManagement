using CustomerManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.DAL
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Customer customer)
        {
            _context.Add(customer);
            _context.SaveChanges();
        }

        public Customer GetById(int customerId)
        {
            return _context.Customers.Find(customerId);
        }

        public void Update(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }

        public void Delete(int customerId)
        {
            var customer = _context.Customers.Find(customerId);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }
    }
}
