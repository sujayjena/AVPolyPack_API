using AVPolyPack.Application.Models;
using AVPolyPack.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVPolyPack.Application.Interfaces
{
    public interface ICustomerRepository
    {
        Task<int> SaveCustomer(Customer_Request parameters);
        Task<IEnumerable<CustomerList_Response>> GetCustomerList(Customer_Search parameters);
        Task<CustomerList_Response?> GetCustomerById(int Id);

        Task<IEnumerable<Customer_ImportDataValidation>> ImportCustomer(List<Customer_ImportData> parameters);
        Task<IEnumerable<Contact_ImportDataValidation>> ImportCustomerContact(List<Contact_ImportData> parameters);
        Task<IEnumerable<Address_ImportDataValidation>> ImportCustomerAddress(List<Address_ImportData> parameters);
    }
}
