﻿using Application.DTOs.UserSide.StorePart;
using Application.ViewModel.UserSide;


namespace Application.Services.Interfaces;

public interface IProductService
{
    #region General

    Task<ProductViewModel> GetProductById(int Id);
    Task<bool> SubmitComment(CommentsViewModelProduct model);
    #endregion

}
