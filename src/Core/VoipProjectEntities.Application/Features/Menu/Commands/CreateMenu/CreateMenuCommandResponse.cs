using VoipProjectEntities.Application.Responses;

namespace VoipProjectEntities.Application.Features.Menu.Commands.CreateMenu
{ 
    public class CreateMenuCommandResponse
    {
        public CreateMenuCommandResponse()
        {

        }

        public CreateMenuDto Menus { get; set; }
    }
}