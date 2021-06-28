
using _0_Framework.Application;
using ShopManagement.Application.Contracts.ProductCategory;
using System;
using System.Collections.Generic;

namespace ShopManagement.Application.Implementation
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        public OperationResult Create(CreateProductCategory command)
        {
            throw new NotImplementedException();
        }

        public EditProductCategory GetDetails(long id)
        {
            throw new NotImplementedException();
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            throw new NotImplementedException();
        }

        public OperationResult Update(EditProductCategory command)
        {
            throw new NotImplementedException();
        }
    }
}
