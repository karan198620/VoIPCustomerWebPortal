using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VoipProjectEntities.Application.Features.Orders.Queries.GetOrdersForMonth;

namespace VoipProjectEntities.Api.Controllers.v1
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]

    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        private OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet(Name = "GetOrdersForMonth")]
        private async Task<ActionResult> GetPagedOrdersForMonth(DateTime date, int page, int size)
        {
            var getOrdersForMonthQuery = new GetOrdersForMonthQuery() { Date = date, Page = page, Size = size };
            var dtos = await _mediator.Send(getOrdersForMonthQuery);
            return Ok(dtos);
        }
    }
}
