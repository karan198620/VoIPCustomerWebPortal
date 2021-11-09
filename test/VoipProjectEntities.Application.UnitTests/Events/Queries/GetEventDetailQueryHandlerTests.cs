using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VoipProjectEntities.Application.Contracts.Persistence;
using VoipProjectEntities.Application.Features.Events.Queries.GetEventDetail;
using VoipProjectEntities.Application.Profiles;
using VoipProjectEntities.Application.Responses;
using VoipProjectEntities.Application.UnitTests.Mocks;
using VoipProjectEntities.Domain.Entities;
using Xunit;

namespace VoipProjectEntities.Application.UnitTests.Events.Queries
{
    public class GetEventDetailQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IEventRepository> _mockEventRepository;
        private readonly Mock<ICategoryRepository> _mockCategoryRepository;

        Mock<IDataProtectionProvider> mockDataProtectionProvider = new Mock<IDataProtectionProvider>();
        public GetEventDetailQueryHandlerTests()
        {
            _mockEventRepository = EventRepositoryMocks.GetEventRepository();
            _mockCategoryRepository = CategoryRepositoryMocks.GetCategoryRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            Mock<IDataProtector> mockDataProtector = new Mock<IDataProtector>();
            mockDataProtector.Setup(sut => sut.Protect(It.IsAny<byte[]>())).Returns(Encoding.UTF8.GetBytes("CfDJ8LIWbthOAQNJnkaD5psOVPeVho-pJeI37QJSSA2Yq5iVE-zn4-NZufSPnfi_bsi_Lhy9GMvMvgukkdQC8iJb_2EDge_YBi-P--kyu3BDBF-yDYHGATAABSLEhwKw_A6fIy_qrIgJaXkiilmFgQHYJnncaCdpjtfaEYnZzQaKc7KN"));
            mockDataProtector.Setup(sut => sut.Unprotect(It.IsAny<byte[]>())).Returns(Encoding.UTF8.GetBytes("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"));
            mockDataProtectionProvider.Setup(s => s.CreateProtector(It.IsAny<string>())).Returns(mockDataProtector.Object);

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_GetEventDetail_FromEventsRepo()
        {
            var handler = new GetEventDetailQueryHandler(_mapper, _mockEventRepository.Object, _mockCategoryRepository.Object, mockDataProtectionProvider.Object);
            var eventId = _mockEventRepository.Object.ListAllAsync().Result.FirstOrDefault().EventId;

            var result = await handler.Handle(new GetEventDetailQuery() { Id = eventId.ToString() }, CancellationToken.None);

            result.ShouldBeOfType<Response<EventDetailVm>>();
        }
    }
}
