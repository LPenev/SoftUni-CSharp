﻿using ShoppingListApp.Models.Product;

namespace ShoppingListApp.Contracts;

public interface IProductService
{
    Task<IEnumerable<ProductViewModel>> GetAllAsync();

    Task<ProductViewModel> GetByIdReadonlyAsync(int id);

    Task AddProductAsync(ProductViewModel model);

    Task UpdateProductAsync(ProductViewModel model);

    Task DeleteProductAsync(int id);

}
