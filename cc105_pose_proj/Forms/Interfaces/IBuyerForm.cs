using static cc105_pose_proj.Services.PricingService;

namespace cc105_pose_proj.Forms.Interfaces
{
    public interface IBuyerForm
    {
        string SubTotal { set; }
        string SavedTotal { set; }
        string Total { set; }
        string Change {  set; }

        void ShowIdle();
        void ShowTransactionItems(List<LineItem> lineItems);
    }
}
