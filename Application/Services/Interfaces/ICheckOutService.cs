

using Application.DTOs.UserSide.Account;

namespace Application.Services.Interfaces;

public interface ICheckOutService
{
    Task<List<CheckOutDto>> ShowcCheckOut(int userid);
}
