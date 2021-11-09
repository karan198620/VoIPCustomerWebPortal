using AutoMapper;
using VoipProjectEntities.Application.Contracts.Persistence;
using VoipProjectEntities.Application.Responses;
using VoipProjectEntities.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace VoipProjectEntities.Application.Features.BalanceCustomers.Queries.GetBalanceCustomersList
{
    public class BalanceCustomerListVm
    {
        public string BalanceCustomerID { get; set; }

        public double BalanceAmount { get; set; }

        public int TranscationType { get; set; }
    }
}
