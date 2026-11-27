using static cc105_pose_proj.Services.PricingService;

namespace cc105_pose_proj.Services.Interfaces
{
    public interface ITransactionStateService
    {
        bool IsTransactionActive { get; }
        SaleSummary? CurrentSale { get; }

        void StartTransaction();
        void UpdateSale(SaleSummary summary);
        void EndTransaction();

        event EventHandler<SaleSummary?>? TransactionChanged;
    }
}
