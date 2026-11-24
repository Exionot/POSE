using cc105_pose_proj.Models;

namespace cc105_pose_proj.UserControls.Interfaces
{
    public interface IInventoryView
    {
        void SetProducts(List<Product> products);
        void DisplayProductDetails(Product? product);
        bool OpenProductDialog(Product? product = null);


        event EventHandler<Product>? ProductSelected;
        event EventHandler? CreateProductRequest;
        event EventHandler? EditProductRequest;
        event EventHandler? BackRequest;
    }
}
