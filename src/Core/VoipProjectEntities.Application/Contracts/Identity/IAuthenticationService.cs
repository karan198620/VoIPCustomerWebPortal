using System.Collections.Generic;
using System.Threading.Tasks;
using VoipProjectEntities.Application.Models.Authentication;

namespace VoipProjectEntities.Application.Contracts.Identity
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
        Task<FindEmailResponse> FindEmailAsync(string email);
        Task<RefreshTokenResponse> RefreshTokenAsync(RefreshTokenRequest request);
        Task<RevokeTokenResponse> RevokeToken(RevokeTokenRequest request);
        Task<DeleteResponse> DeleteAsync(string CustomerId);
        Task<UserManagerResponse> ForgetPasswordAsync(string email);
        Task<UserManagerResponse> ResetPasswordAsync(ResetPasswordRequest request);
        Task<GetByIdResponse> GetByIdAsync(string id);
    }
}
