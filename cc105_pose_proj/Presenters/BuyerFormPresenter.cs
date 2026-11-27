using cc105_pose_proj.Forms.Interfaces;
using cc105_pose_proj.Services.Interfaces;
using System.Windows.Forms;
using static cc105_pose_proj.Services.PricingService;

namespace cc105_pose_proj.Presenters
{
    public class BuyerFormPresenter
    {
        private readonly IBuyerForm _view;
        private readonly ITransactionStateService _transactionState;

        public BuyerFormPresenter(IBuyerForm view, ITransactionStateService transactionState)
        {
            _view = view;
            _transactionState = transactionState;

            _transactionState.TransactionChanged += OnTransactionChanged;

            RenderState(_transactionState.CurrentSale);
        }

        private void OnTransactionChanged(object? sender, SaleSummary? summary)
        {
            RenderState(summary);
        }

        private void RenderState(SaleSummary? summary)
        {
            if (!_transactionState.IsTransactionActive || summary == null || summary.LineItems.Count == 0)
            {
                _view.ShowIdle();
                return;
            }

            _view.ShowTransactionItems(summary.LineItems);

            _view.SubTotal = summary.Subtotal.ToString("C2"); 
            _view.SavedTotal = summary.TotalSaved > 0 ? $"-{summary.TotalSaved:C2}" : "₱0.00";
            _view.Total = summary.GrandTotal.ToString("C2");
        }
    }
}
