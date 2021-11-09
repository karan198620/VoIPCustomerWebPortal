using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace VoipProjectEntities.Application.Features.MenuAccesses.Command.DeleteMenuAccess
{
    public class DeleteMenuCommand : IRequest
    {
        public string MenuAccessId { get; set; }
    }
}
