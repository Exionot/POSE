using cc105_pose_proj.Models;
using cc105_pose_proj.Navigation;
using cc105_pose_proj.Services;
using cc105_pose_proj.Services.Interfaces;
using cc105_pose_proj.UserControls;
using cc105_pose_proj.UserControls.Interfaces;
using static cc105_pose_proj.Services.PricingService;

namespace cc105_pose_proj.Presenters
{
    public class MainTransactionViewPresenter
    {
        private readonly IMainTransactionView _view;
        private readonly INavigator _nav;
        private readonly IProductService _productService;
        private readonly IDiscountService _discountService;
        private readonly IDialogService _dialogService;
        private readonly PricingService _pricingService;

        private List<Discount> _activeDiscounts = [];
        private List<Product> _products = [];
        private readonly List<CartItem> _cart = [];

        public MainTransactionViewPresenter(
                IMainTransactionView view,
                INavigator nav,
                IProductService productService,
                IDiscountService discountService,
                IDialogService dialogService,
                PricingService? pricingService = null)
        {
            _view = view;
            _nav = nav;
            _productService = productService;
            _discountService = discountService;
            _dialogService = dialogService;
            _pricingService = pricingService ?? new PricingService();

            _view.ProductSelected += ProductSelected;
            _view.RemoveOneRequest += RemoveOneRequest;
            _view.RemoveAllRequest += RemoveAllRequest;
            _view.ClearCartRequest += ClearCartRequest;
            _view.BackRequest += BackRequest;

            LoadData();
        }

        private void LoadData()
        {
            _activeDiscounts = _discountService.GetDiscounts()
                .Where(d => d.Active)
                .ToList();

            _products = _productService.GetProducts();
            _view.SetProductButtons(_products);

            UpdateSaleSummary();
        }

        private void ProductSelected(object? sender, Product p)
        {
            var existing = _cart.FirstOrDefault(c => c.Product.Id == p.Id);
            int currentQty = existing?.Quantity ?? 0;

            if (currentQty >= p.Quantity)
            {
                _dialogService.ShowWarning(
                    $"Cannot add more than {p.Quantity} units of '{p.Name}'. Stock limit reached.",
                    "Insufficient Stock");
                return;
            }

            if (existing == null)
            {
                _cart.Insert(0, new CartItem(p, 1));
            }
            else
            {
                _cart.Remove(existing);
                _cart.Insert(0, existing with { Quantity = currentQty + 1 });
            }

            UpdateSaleSummary();
            _view.FocusFirstRow();
        }

        private void RemoveOneRequest(object? sender, EventArgs e)
        {
            string? name = _view.SelectedProductName;
            if (name == null) return;

            var existing = _cart.FirstOrDefault(c => c.Product.Name == name);
            if (existing == null) return;

            int index = _cart.IndexOf(existing);
            if (existing.Quantity > 1)
            {
                _cart[index] = existing with { Quantity = existing.Quantity - 1 };
            }
            else
            {
                _cart.RemoveAt(index);
            }

            UpdateSaleSummary();
        }

        private void RemoveAllRequest(object? sender, EventArgs e)
        {
            string? name = _view.SelectedProductName;
            if (name == null) return;

            _cart.RemoveAll(c => c.Product.Name == name);
            UpdateSaleSummary();
        }

        private void ClearCartRequest(object? sender, EventArgs e)
        {
            if (_cart.Count == 0) return;

            if (_dialogService.Confirm("Are you sure you want to clear all items?", "Confirm Clear"))
            {
                _cart.Clear();
                UpdateSaleSummary();
            }
        }

        private void BackRequest(object? sender, EventArgs e)
        {
            if (_cart.Count > 0)
            {
                if (!_dialogService.Confirm("Cancel this transaction and go back to home?", "Confirm Exit"))
                    return;
            }

            _nav.NavigateTo<Home>();
        }

        private void UpdateSaleSummary()
        {
            SaleSummary summary = _pricingService.CalculateSale(_cart, _activeDiscounts);

            _view.SetCartItems(summary.LineItems);
            _view.Subtotal = summary.Subtotal.ToString("C2");
            _view.TotalSaved = summary.TotalSaved > 0 ? $"-{summary.TotalSaved:C2}" : "₱0.00";
            _view.GrandTotal = summary.GrandTotal.ToString("C2");

            foreach (var product in _products)
            {
                int inCart = _cart.FirstOrDefault(c => c.Product.Id == product.Id)?.Quantity ?? 0;
                _view.SetProductAvailability(product.Name, (product.Quantity - inCart) > 0);
            }
        }
    }
}
