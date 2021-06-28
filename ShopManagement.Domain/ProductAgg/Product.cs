using _0_Framework.Domain;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductAgg
{
  public  class Product : EntityBase
    {
        public string Name { get; private set; }
        public string Code { get; private set; }
        public double UnitPrice { get; private set; }
        public bool IsInStock { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Keywords { get; private set; }
        public string MetaDescription { get; private set; }
        public string Slug { get; private set; }
        public string ShortDecription { get; private set; }
        public string Description { get; private set; }
        public long CategoryId { get; private set; }
        public ProductCategory ProductCategory { get; private set; }
        public ICollection<ProductPicture> ProductPictures { get; private set; }

        protected Product()
        {
        }

        public Product(string name, string code, double unitPrice,
            string picture, string pictureAlt, string pictureTitle, 
            string keywords, string metaDescription, string slug, long categoryId ,
            string shortDescription , string description)
        {
            Name = name;
            Code = code;
            UnitPrice = unitPrice;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Keywords = keywords;
            MetaDescription = metaDescription;
            Slug = slug;
            CategoryId = categoryId;
            IsInStock =true;
            ShortDecription = shortDescription;
            Description = description;
            ProductPictures = new List<ProductPicture>();
        }

        public void Edit(
            string name, string code, double unitPrice,
            string picture, string pictureAlt, string pictureTitle,
            string keywords, string metaDescription, string slug, long categoryId,
             string shortDescription, string description)
        {
            Name = name;
            Code = code;
            UnitPrice = unitPrice;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Keywords = keywords;
            MetaDescription = metaDescription;
            Slug = slug;
            CategoryId = categoryId;
         
            ShortDecription = shortDescription;
            Description = description;
        }

        public void NotInStock()
        {
            IsInStock = false;
        }

        public void InStock()
        {
            IsInStock = true;
        }
    }
}
