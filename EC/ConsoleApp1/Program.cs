using ConsoleApp1.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static ICustomerDataProvider _provider;
        static void Main(string[] args)
        {
            Customer customer = new Customer();
            List<Customer> list = new List<Customer>();
            customer.name = "Test";
            customer.Email = "TestEmail";
            customer.age = 32;
            customer.identifier = 1;
            list.Add(customer);
            customer.name = "Test2";
            customer.Email = "TestEmail2";
            customer.age = 28;
            customer.identifier = 2;
            list.Add(customer);
            customer.name = "Test3";
            customer.Email = "TestEmail3";
            customer.age = 29;
            customer.identifier = 3;
            list.Add(customer);

            List<Customer> saveData =  _provider.SaveCustomerList(list);

            list = _provider.GetCustomerListByAgeRange(30);
            foreach (Customer item in list)
            {
                Console.WriteLine("Nombre" + item.name);
                Console.WriteLine("Edad" + item.name);
                Console.WriteLine("Correo electronitno" + item.Email);
            }

            string json = JsonSerializer.Serialize<List<Customer>>(list);

            Console.WriteLine(json);

        }
    }
}
