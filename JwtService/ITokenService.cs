using Application.Dtos;

namespace JwtService
{
    public interface ITokenService
    {
        Task GenerateToken(LoginDto login);
    }
}