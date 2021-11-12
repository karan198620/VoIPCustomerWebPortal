using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoipApplicationProject.Models;
using static VoipApplicationProject.RootObjects.RootObject;

namespace VoipApplicationProject.Repositories
{
    public interface ICustomerRepo
    {
        //int GetEnumValue(string Type);
        CustomerModel IsAuthenticated(CustomerModel customer);
        List<RootCustomer> GetAllCustomers();
        string ValidateEmail(string Email);
        RootCustomer Register(CustomerModel customer);
        CustomerModel GetCustomerById(string CustomerId);
        bool CreateMenuAccess(string CustomerId);
        void DeleteCustomer(string CustomerId);
        bool ForgotPassword(string Email);
        bool ResetPassword(ResetPasswordModel customer);
    }
}
