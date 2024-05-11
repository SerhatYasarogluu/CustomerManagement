using CustomerManagement.BLL;
using CustomerManagement.DAL;
using CustomerManagement.Entities;

namespace CustomerUI
{
    public class Program
    {
        public static  CustomerService _customerService = new CustomerService(new CustomerRepository(new ApplicationDbContext()));

        static void Main(string[] args)
        {
            
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nİşlem seçiniz:");
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

        private static void AddCustomer()
        {
            Console.Write("Müşteri ismi: ");
            string name = Console.ReadLine();
            Console.Write("Telefon numarası: ");
            string phoneNumber = Console.ReadLine();

            var customer = new Customer { Name = name, PhoneNumber = phoneNumber };
            _customerService.AddCustomer(customer);
            Console.WriteLine("Müşteri başarıyla eklendi.");
        }

        private static void RemoveCustomer()
        {
            Console.Write("Silinecek Müşterinin ID'sini giriniz: ");
            int id = int.Parse(Console.ReadLine());
            _customerService.RemoveCustomer(id);
            Console.WriteLine("Müşteri silindi.");
        }

        private static void UpdateCustomer()
        {
            Console.Write("Müşteri Güncelle: ");
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
                Console.WriteLine("Müşteri başarıyla güncellendi.");
            }
            else
            {
                Console.WriteLine("Böyle bir müşteri yok");
            }
        }

        private static void ListCustomers()
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