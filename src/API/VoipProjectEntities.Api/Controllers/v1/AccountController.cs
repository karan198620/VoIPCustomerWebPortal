using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using VoipProjectEntities.Application.Contracts.Identity;
using VoipProjectEntities.Application.Models.Authentication;
using VoipProjectEntities.Identity.Models;

namespace VoipProjectEntities.Api.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly UserManager<Customer> _userManager;
        public AccountController(IAuthenticationService authenticationService, UserManager<Customer> userManager)
        {
            _authenticationService = authenticationService;
            _userManager = userManager;
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request)
        {
            return Ok(await _authenticationService.AuthenticateAsync(request));
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> RegisterAsync(RegistrationRequest request)
        {
            return Ok(await _authenticationService.RegisterAsync(request));
        }

        [HttpGet("findemail/{email}")]
        public async Task<ActionResult<FindEmailResponse>> FindEmailAsync(string email)
        {
            return Ok(await _authenticationService.FindEmailAsync(email));
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshTokenAsync(RefreshTokenRequest request)
        {
            return Ok(await _authenticationService.RefreshTokenAsync(request));
        }

        [HttpPost("revoke-token")]
        public async Task<IActionResult> RevokeTokenAsync(RevokeTokenRequest request)
        {
            var response = await _authenticationService.RevokeToken(request);
            if (response.Message == "Token is required")
                return BadRequest(response);
            else if (response.Message == "Token did not match any users")
                return NotFound(response);
            else
                return Ok(response);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var response = await _authenticationService.DeleteAsync(id);

            if (response.Message == "Successfully deleted !")
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpGet("getall")]
        public async Task<ActionResult<GetAllResponse>> GetAllAsync()
        {
            var response = await _userManager.GetUsersInRoleAsync("Viewer");

            if (response != null)
                return Ok(response);
            else
                return BadRequest();
        }

        
        [HttpGet("getById")]
        public async Task<IActionResult> GetByIdAsync([FromQuery]string Id)
        {
            var response = await _authenticationService.GetByIdAsync(Id);

            if (response != null)
                return Ok(response);
            else
                return BadRequest();
        }

        [HttpPost("ForgetPassword")]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordRequest request)
        {
            if (string.IsNullOrEmpty(request.Email))
                return NotFound();

            var result = await _authenticationService.ForgetPasswordAsync(request.Email);

            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordRequest request)
        {
            var result = await _authenticationService.ResetPasswordAsync(request);

            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
