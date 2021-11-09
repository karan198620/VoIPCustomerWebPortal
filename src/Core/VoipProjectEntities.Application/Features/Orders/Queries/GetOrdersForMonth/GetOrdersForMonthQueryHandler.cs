using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VoipProjectEntities.Application.Contracts.Persistence;
using VoipProjectEntities.Application.Responses;

namespace VoipProjectEntities.Application.Features.Orders.Queries.GetOrdersForMonth
{
    public class GetOrdersForMonthQueryHandler : IRequestHandler<GetOrdersForMonthQuery, PagedResponse<IEnumerable<OrdersForMonthDto>>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrdersForMonthQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<OrdersForMonthDto>>> Handle(GetOrdersForMonthQuery request, CancellationToken cancellationToken)
        {
            var list = await _orderRepository.GetPagedOrdersForMonth(request.Date, request.Page, request.Size);
            var orders = _mapper.Map<List<OrdersForMonthDto>>(list);

            var count = await _orderRepository.GetTotalCountOfOrdersForMonth(request.Date);

            var response = new PagedResponse<IEnumerable<OrdersForMonthDto>>(orders, count, request.Size);

            return response;
        }
    }
}
