using cc105_pose_proj.Models;
using static cc105_pose_proj.Services.PricingService;

namespace cc105_pose_proj.UserControls.Interfaces
{
    public interface IMainTransactionView
    {
        string Subtotal { set; }
        string TotalSaved { set; }
        string GrandTotal { set; }
        string? SelectedProductName { get; }

        void SetProductButtons(List<Product> products);
        void FocusFirstRow();
        void SetCartItems(List<LineItem> lineItems);
        void SetProductAvailability(string productName, bool isAvailable);

        event EventHandler<Product>? ProductSelected;
        event EventHandler? RemoveOneRequest;
        event EventHandler? RemoveAllRequest;
        event EventHandler? ClearCartRequest;
        event EventHandler? BackRequest;
        event EventHandler? CheckoutRequest;
    }
}
