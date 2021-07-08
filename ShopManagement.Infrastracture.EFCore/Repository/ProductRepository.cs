using _0_Framework.Infrastracture;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ShopManagement.Infrastracture.EFCore.Repository
{
    public class ProductRepository : RepositoryBase<long, Product>, IProductRepository
    {
        private readonly ShopContext _shopContext;
        

        public ProductRepository(ShopContext shopContext) : base(shopContext)
        {
            _shopContext = shopContext;

        }

        public EditProduct GetDetails(long id)
        {
            var result = _shopContext.Products.Include(x => x.ProductCategory).Select(x => new EditProduct
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code,
                Slug = x.Slug,
                PictureTitle = x.PictureTitle,
                PictureAlt = x.PictureAlt,
                MetaDescription = x.MetaDescription,
                Keywords = x.Keywords,
                CategoryId = x.ProductCategory.Id,
                ShortDecription = x.ShortDecription,
                Description = x.Description,

            }).FirstOrDefault(x => x.Id == id);

            return result;
        }

        public List<ProductViewModel> GetProducts()
        {
            return _shopContext.Products.Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
               
            }).ToList();
        }

        public Product GetProductWithCategoryById(long id)
        {
            return _shopContext.Products.Include(x => x.ProductCategory).FirstOrDefault(x => x.Id == id);
        }

        public string GetProductWithSlugById(long id)
        {
            return _shopContext.Products.Select(x => new { x.Id, x.Slug }).FirstOrDefault(x => x.Id == id).Slug;
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {

            var query = _shopContext.Products.Include(x => x.ProductCategory).Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Category = x.ProductCategory.Name,
                Code = x.Code,
               
                Picture = x.Picture,
                CategoryId = x.ProductCategory.Id,

                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture)
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            if (!string.IsNullOrWhiteSpace(searchModel.Code))
                query = query.Where(x => x.Code.Contains(searchModel.Code));

            if (searchModel.CategoryId > 0)
                query = query.Where(x => x.CategoryId == searchModel.CategoryId);


            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
