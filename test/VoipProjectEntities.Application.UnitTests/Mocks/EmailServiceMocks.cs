using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using VoipProjectEntities.Application.Contracts.Infrastructure;
using VoipProjectEntities.Application.Models.Mail;

namespace VoipProjectEntities.Application.UnitTests.Mocks
{
    public class EmailServiceMocks
    {
        public static Mock<IEmailService> GetEmailService()
        {
            var mockEmailService = new Mock<IEmailService>();
            mockEmailService.Setup(x => x.SendEmail(It.IsAny<Email>())).ReturnsAsync(true);
            return mockEmailService;
        }
    }
}
