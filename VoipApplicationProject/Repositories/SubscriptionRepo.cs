using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using VoipApplicationProject.Models;

namespace VoipApplicationProject.Repositories
{
    public class SubscriptionRepo : ISubscriptionRepo
    {
        string Baseurl = "https://localhost:44330/";
    }
}