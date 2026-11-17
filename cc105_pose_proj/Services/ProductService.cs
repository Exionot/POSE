using cc105_pose_proj.Data;
using cc105_pose_proj.Models;
using cc105_pose_proj.Util;

namespace cc105_pose_proj.Services
{
    public class ProductService : BaseService
    {
        private readonly IRepository<Product> _productRepo;

        public ProductService(IRepository<Product>? productRepo = null)
        {
            _productRepo = productRepo ?? new ProductRepository();
        }

        public List<Product> GetProducts()
        {
            if (CurrentUser == null)
                return [];

            var allProducts = _productRepo.GetAll();

            if (IsAdmin)
                return allProducts;

            if (CurrentBusinessId == null)
                return [];

            return allProducts.Where(p => p.Business.Id == CurrentBusinessId.Value).ToList();
        }

        public Product? GetProductById(int id)
        {
            if (CurrentUser == null) return null;

            var product = _productRepo.GetById(id);
            if (product == null) 
                return null;

            if (!IsAdmin && product.Business.Id != CurrentBusinessId)
                return null;

            return product;
        }

        public bool CreateProduct(Product product, string imageSourcePath)
        {
            if (CurrentUser == null) return false;

            if (!IsAdmin)
            {
                if (CurrentBusiness == null)
                    return false;

                product.Business = CurrentBusiness;
            }

            if (product.Business == null)
                return false;

            string savedImageName = ImgUtil.SaveImg(imageSourcePath);
            product.Image = savedImageName;

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
            if (CurrentUser == null) return false;

            var existing = GetProductById(product.Id);
            if (existing == null) return false;

            if (!IsAdmin)
                product.Business = existing.Business;

            if (!string.IsNullOrEmpty(newImagePath))
                product.Image = ImgUtil.ReplaceImage(existing.Image, newImagePath);
            else 
                product.Image = existing.Image;

            return _productRepo.Update(product);
        }

        public bool DeleteProduct(int id)
        {
            if (CurrentUser == null) return false;

            var product = GetProductById(id);
            if (product == null) return false;

            bool isDeleted = _productRepo.Delete(id);
            if (isDeleted)
                ImgUtil.DeleteImage(product.Image); 
            
            return isDeleted;
        }
    }
}
