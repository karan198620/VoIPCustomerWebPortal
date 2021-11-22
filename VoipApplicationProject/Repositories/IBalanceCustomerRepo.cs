using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoipApplicationProject.Models;

namespace VoipApplicationProject.Repositories
{
    public interface IBalanceCustomerRepo
    {
        List<BalanceCustomerModel> GetBalanceCustomerList(string CustomerId);

        //void DeleteCustomer(string BalanceCustomerID);
    }
}
