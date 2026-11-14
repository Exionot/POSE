using cc105_pose_proj.Data;
using cc105_pose_proj.Models;
using cc105_pose_proj.Util;

namespace cc105_pose_proj.Services
{
    public class ProductService
    {
        private readonly IRepository<Product> _productRepo;

        public ProductService(IRepository<Product>? productRepo = null)
        {
            _productRepo = productRepo ?? new ProductRepository();
        }

        public List<Product> GetProducts()
        {
            var allProducts = _productRepo.GetAll();

            int? currentBusinessId = Session.CurrentUser?.Business?.Id; 

            if (currentBusinessId == null)
                return allProducts;

            return allProducts.Where(p => p.Business.Id == currentBusinessId.Value).ToList();
        }

        public Product? GetProductById(int id)
        {
            var product = _productRepo.GetById(id);

            if (product == null) 
                return null;

            int? currentBusinessId = Session.CurrentUser?.Business?.Id;

            if (currentBusinessId == null)
                return product;

            if (product.Business.Id != currentBusinessId.Value)
                return null;

            return product;
        }

        public bool CreateProduct(Product product, string imageSourcePath)
        {
            string savedImageName = ImgUtil.SaveImg(imageSourcePath);
            product.Image = savedImageName;

            var currentUserBusiness = Session.CurrentUser?.Business;
            if (currentUserBusiness != null)
                product.Business = currentUserBusiness;

            try
            {
                bool success = _productRepo.Add(product);

                if (!success)
                {
                    ImgUtil.DeleteImage(savedImageName);
                    return false;
                }

                return true;
            }
            catch 
            {
                ImgUtil.DeleteImage(savedImageName);
                throw;
            }
        }

        public bool UpdateProduct(Product product, string? newImagePath = null)
        {
            if (!string.IsNullOrEmpty(newImagePath))
            {
                product.Image = ImgUtil.ReplaceImage(product.Image, newImagePath);
            }

            return _productRepo.Update(product);
        }

        public bool DeleteProduct(int id)
        {
            var product = GetProductById(id);
            if (product == null) return false;

            bool isDeleted = _productRepo.Delete(id);
            if (isDeleted)
            {
                ImgUtil.DeleteImage(product.Image); 
            }
            return isDeleted;
        }
    }
}
