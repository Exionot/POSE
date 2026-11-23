using cc105_pose_proj.Models;

namespace cc105_pose_proj.Services.Interfaces
{
    public interface IProductService
    {
        bool CreateProduct(Product product, string imageSourcePath);
        bool DeleteProduct(int id);
        Product? GetProductById(int id);
        List<Product> GetProducts();
        bool UpdateProduct(Product product, string? newImagePath = null);
    }
}