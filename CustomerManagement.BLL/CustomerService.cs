using CustomerManagement.BLL;
using CustomerManagement.DAL;
using CustomerManagement.Entities;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public void AddCustomer(Customer customer)
    {
        _customerRepository.Add(customer);
    }

    public void RemoveCustomer(int customerId)
    {
        _customerRepository.Delete(customerId);
    }

    public void UpdateCustomer(Customer customer)
    {
        _customerRepository.Update(customer);
    }

    public Customer GetCustomer(int customerId)
    {
        return _customerRepository.GetById(customerId);
    }

    public IEnumerable<Customer> GetAllCustomers()
    {
        return _customerRepository.GetAll();
    }
}