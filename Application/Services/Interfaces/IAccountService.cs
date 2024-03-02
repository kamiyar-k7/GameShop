using Application.DTOs.UserSide.Account;


namespace Application.Services.Interfaces;

public interface IAccountService
{
    Task<SignInDto> FindUser(SignInDto model);
    Task<bool> AddToDataBase(SignUpDto model, CancellationToken cancellation);
}
