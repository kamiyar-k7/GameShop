using Application.DTOs.UserSide.StorePart;
using Application.ViewModel.AdminSide;
using Application.ViewModel.UserSide;
using Domain.entities.GamePart.Game;


namespace Application.Services.Interfaces.UserSide;

public interface IProductService
{
    #region General

    Task<ProductViewModel> GetProductById(int Id , int Adminid);
    Task<bool> SubmitComment(CommentsViewModelProduct model);

    #endregion


    #region Admin Side
    Task<ProductViewModel> ListOfProducts(int userid);
    Task<ProductViewModel> ShowAddGame(int id);
    #endregion
}
