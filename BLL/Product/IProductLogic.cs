﻿using Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nettbutikk.BusinessLogic
{
    public interface IProductLogic
    {
        List<ProductModel> GetProducts(List<int> productIdList);
        ProductModel GetProduct(int productId);
        List<ProductModel> GetProductsByCategory(int categoryId);
        string GetCategoryName(int categoryId);
        List<CategoryModel> AllCategories();
    }
}
