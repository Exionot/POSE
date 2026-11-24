using cc105_pose_proj.Models;
using cc105_pose_proj.Navigation;
using cc105_pose_proj.Services.Interfaces;
using cc105_pose_proj.UserControls;
using cc105_pose_proj.UserControls.Interfaces;

namespace cc105_pose_proj.Presenters
{
    public class InventoryViewPresenter
    {
        private readonly IInventoryView _view;
        private readonly IProductService _productService;
        private readonly INavigator _nav;

        private Product? _selectedProduct;

        public InventoryViewPresenter(
            IInventoryView view,
            IProductService productService,
            INavigator nav)
        {
            _view = view;
            _productService = productService;
            _nav = nav;

            _view.ProductSelected += ProductSelected;
            _view.CreateProductRequest += CreateProductRequest;
            _view.EditProductRequest += EditProductRequest;
            _view.BackRequest += (_, _) => _nav.NavigateTo<Home>();

            LoadProducts();
        }

        public void LoadProducts()
        {
            var products = _productService.GetProducts();
            _view.SetProducts(products);

            if (_selectedProduct != null)
            {
                _selectedProduct = _productService.GetProductById(_selectedProduct.Id);
                _view.DisplayProductDetails(_selectedProduct);
            }
            else
            {
                _view.DisplayProductDetails(null);
            }
        }

        private void ProductSelected(object? sender, Product product)
        {
            _selectedProduct = product;
            _view.DisplayProductDetails(product);
        }

        private void CreateProductRequest(object? sender, EventArgs e)
        {
            if (_view.OpenProductDialog(null))
            {
                LoadProducts();
            }
        }

        private void EditProductRequest(object? sender, EventArgs e)
        {
            if (_selectedProduct == null) return;

            if (_view.OpenProductDialog(_selectedProduct))
            {
                LoadProducts();
            }
        }
    }
}
