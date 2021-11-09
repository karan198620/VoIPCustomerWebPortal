using MediatR;
using System;
using System.Collections.Generic;
using VoipProjectEntities.Application.Responses;

namespace VoipProjectEntities.Application.Features.Orders.Queries.GetOrdersForMonth
{
    public class GetOrdersForMonthQuery : IRequest<PagedResponse<IEnumerable<OrdersForMonthDto>>>
    {
        public DateTime Date { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
