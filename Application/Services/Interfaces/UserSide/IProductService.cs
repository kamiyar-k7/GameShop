using Application.DTOs.UserSide.StorePart;
using Application.ViewModel.AdminSide;
using Application.ViewModel.UserSide;


namespace Application.Services.Interfaces.UserSide;

public interface IProductService
{
    #region General

    Task<ProductViewModel> GetProductById(int Id);
    Task<bool> SubmitComment(CommentsViewModelProduct model);
    #endregion


    #region Admin Side
    Task<AdminProductViewModel> ListOfProducts(int userid);
    #endregion
}
