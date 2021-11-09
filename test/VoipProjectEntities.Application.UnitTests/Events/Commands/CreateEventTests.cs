using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;
using VoipProjectEntities.Application.Contracts.Infrastructure;
using VoipProjectEntities.Application.Contracts.Persistence;
using VoipProjectEntities.Application.Features.Events.Commands.CreateEvent;
using VoipProjectEntities.Application.Profiles;
using VoipProjectEntities.Application.UnitTests.Mocks;
using Xunit;

namespace VoipProjectEntities.Application.UnitTests.Event.Commands
{
    public class CreateEventTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IEventRepository> _mockEventRepository;
        private readonly Mock<IEmailService> _emailService;
        private readonly Mock<ILogger<CreateEventCommandHandler>> _logger;

        public CreateEventTests()
        {
            _mockEventRepository = EventRepositoryMocks.GetEventRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _logger = new Mock<ILogger<CreateEventCommandHandler>>();
            _mapper = configurationProvider.CreateMapper();
            _emailService = EmailServiceMocks.GetEmailService();
        }

        [Fact]
        public async Task Handle_ValidEvent_AddedToEventRepo()
        {
            var handler = new CreateEventCommandHandler(_mapper, _mockEventRepository.Object, _emailService.Object, _logger.Object);

            await handler.Handle(new CreateEventCommand()
            {
                Name = "Test",
                Price = 25,
                Artist = "test",
                Date = new DateTime(2027, 1, 18),
                Description = "description",
                ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/musical.jpg",
                CategoryId = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}")
            }, CancellationToken.None);

            var allEvents = await _mockEventRepository.Object.ListAllAsync();
            allEvents.Count.ShouldBe(3);
        }
    }
}
