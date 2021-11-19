using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoipApplicationProject.Models;

namespace VoipApplicationProject.Repositories
{
    public interface IAdminRepo
    {
        TrialBalanceRequestModel GetAllTBRRequest(string token);
        TrialBalanceRequestModel GetCustomerById(string Id, string token);
    }
}
