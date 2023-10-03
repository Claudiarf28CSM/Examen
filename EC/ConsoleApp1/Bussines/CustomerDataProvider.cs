using ConsoleApp1.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Bussines
{
    public class CustomerDataProvider : ICustomerDataProvider
    {
        public CustomerDataProvider() { }
        public List<Customer> GetCustomerList()
        {
            List < Customer > result = new List < Customer >();
          


           return result;
        }

        public List<Customer> GetCustomerListByAgeRange(int Age)
        {
            List<Customer> list = GetCustomerList();
            List<Customer> result = list.Where(x => x.age > Age).ToList();

            return result;
        }

        public List<Customer> SaveCustomerList(List<Customer> customerList)
        {


            return customerList;
        }

        public void SaveCutomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
