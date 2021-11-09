using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VoipProjectEntities.Application.Contracts.Persistence;
using VoipProjectEntities.Application.Responses;
using VoipProjectEntities.Domain.Entities;

namespace VoipProjectEntities.Application.Features.Categories.Queries.GetCategoriesList
{
    public class GetCategoriesListQueryHandler : IRequestHandler<GetCategoriesListQuery, Response<IEnumerable<CategoryListVm>>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public GetCategoriesListQueryHandler(IMapper mapper, ICategoryRepository categoryRepository, ILogger<GetCategoriesListQueryHandler> logger)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<CategoryListVm>>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var allCategories = (await _categoryRepository.ListAllAsync()).OrderBy(x => x.Name);
            var category = _mapper.Map<IEnumerable<CategoryListVm>>(allCategories);
            _logger.LogInformation("Hanlde Completed");
            return new Response<IEnumerable<CategoryListVm>>(category, "success");
        }

    }



}
