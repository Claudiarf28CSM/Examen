using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Interface
{
    internal interface ICustomerDataProvider
    {
        List<Customer> GetCustomerList();
        List<Customer> GetCustomerListByAgeRange(int Age);
        void SaveCutomer(Customer customer);
        List<Customer> SaveCustomerList (List<Customer> customerList);

    }
}
