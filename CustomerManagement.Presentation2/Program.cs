using CustomerManagement.BLL;
using CustomerManagement.DAL;
using CustomerManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
          
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddTransient<Application>();
        }
    }

    public class Application
    {
        private readonly ICustomerService _customerService;

        public Application(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public void Run()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Müşteri ekle");
                Console.WriteLine("2. Müşeri sil");
                Console.WriteLine("3. Müşteri güncelle");
                Console.WriteLine("4. Müşteri listele");
                Console.WriteLine("5. Exit");
                Console.Write("Seçim yapınız: ");

                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        AddCustomer();
                        break;
                    case "2":
                        RemoveCustomer();
                        break;
                    case "3":
                        UpdateCustomer();
                        break;
                    case "4":
                        ListCustomers();
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Geçerli işlem gir.");
                        break;
                }
            }
        }

        private void AddCustomer()
        {
            Console.Write("Müşteri ismi: ");
            string name = Console.ReadLine();
            Console.Write("Telefon numarası: ");
            string phoneNumber = Console.ReadLine();

            var customer = new Customer { Name = name, PhoneNumber = phoneNumber };
            _customerService.AddCustomer(customer);
            Console.WriteLine("Customer added successfully.");
        }

        private void RemoveCustomer()
        {
            Console.Write("Enter Customer ID to remove: ");
            int id = int.Parse(Console.ReadLine());
            _customerService.RemoveCustomer(id);
            Console.WriteLine("Customer removed successfully.");
        }

        private void UpdateCustomer()
        {
            Console.Write("Müşteri Güncellendi ");
            int id = int.Parse(Console.ReadLine());

            var customer = _customerService.GetCustomer(id);
            if (customer != null)
            {
                Console.Write("Yeni Müşterinin ismi ");
                string newName = Console.ReadLine();
                Console.Write("Yeni Müşterinin Nosu: ");
                string newPhoneNumber = Console.ReadLine();

                customer.Name = newName;
                customer.PhoneNumber = newPhoneNumber;
                _customerService.UpdateCustomer(customer);
                Console.WriteLine("Customer updated successfully.");
            }
            else
            {
                Console.WriteLine("Böyle bir müşteri yok");
            }
        }

        private void ListCustomers()
        {
            var customers = _customerService.GetAllCustomers();
            if (customers.Any())
            {
                foreach (var customer in customers)
                {
                    Console.WriteLine($"ID: {customer.Id}, Name: {customer.Name}, Phone: {customer.PhoneNumber}");
                }
            }
            else
            {
                Console.WriteLine("Böyle bir müşteri yok.");
            }
        }
    }

}
