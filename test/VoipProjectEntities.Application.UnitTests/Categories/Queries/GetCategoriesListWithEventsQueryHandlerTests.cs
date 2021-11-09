using AutoMapper;
using Moq;
using Shouldly;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VoipProjectEntities.Application.Contracts.Persistence;
using VoipProjectEntities.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using VoipProjectEntities.Application.Profiles;
using VoipProjectEntities.Application.Responses;
using VoipProjectEntities.Application.UnitTests.Mocks;
using Xunit;

namespace VoipProjectEntities.Application.UnitTests.Categories.Queries
{
    public class GetCategoriesListWithEventsQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICategoryRepository> _mockCategoryRepository;

        public GetCategoriesListWithEventsQueryHandlerTests()
        {
            _mockCategoryRepository = CategoryRepositoryMocks.GetCategoryRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Get_CategoriesList_WithEvents_IncludeHistory()
        {
            var handler = new GetCategoriesListWithEventsQueryHandler(_mapper, _mockCategoryRepository.Object);

            var result = await handler.Handle(new GetCategoriesListWithEventsQuery() { IncludeHistory = true }, CancellationToken.None);

            result.ShouldBeOfType<Response<IEnumerable<CategoryEventListVm>>>();
        }

        [Fact]
        public async Task Get_CategoriesList_WithEvents_DoNotIncludeHistory()
        {
            var handler = new GetCategoriesListWithEventsQueryHandler(_mapper, _mockCategoryRepository.Object);

            var result = await handler.Handle(new GetCategoriesListWithEventsQuery() { IncludeHistory = false }, CancellationToken.None);

            result.ShouldBeOfType<Response<IEnumerable<CategoryEventListVm>>>();
            result.Data.ShouldNotBeEmpty();
        }
    }
}
