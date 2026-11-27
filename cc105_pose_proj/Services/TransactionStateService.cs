using cc105_pose_proj.Services.Interfaces;
using static cc105_pose_proj.Services.PricingService;

namespace cc105_pose_proj.Services
{
    public class TransactionStateService : ITransactionStateService
    {
        public bool IsTransactionActive { get; private set; }
        public SaleSummary? CurrentSale { get; private set; }

        public event EventHandler<SaleSummary?>? TransactionChanged;

        public void StartTransaction()
        {
            IsTransactionActive = true;
            CurrentSale = null;
            TransactionChanged?.Invoke(this, null);
        }

        public void UpdateSale(SaleSummary summary)
        {
            IsTransactionActive = true;
            CurrentSale = summary;
            TransactionChanged?.Invoke(this, summary);
        }

        public void EndTransaction()
        {
            IsTransactionActive = false;
            CurrentSale = null;
            TransactionChanged?.Invoke(this, null);
        }
    }
}
