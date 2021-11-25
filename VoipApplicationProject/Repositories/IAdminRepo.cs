using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoipApplicationProject.Models;

namespace VoipApplicationProject.Repositories
{
    public interface IAdminRepo
    {
        List<TrialBalanceRequestModel> GetAllTBRRequest(string token, string fromDate = "", string toDate = "");
        TrialBalanceRequestModel GetCustomerById(string Id, string token);
    }
}
