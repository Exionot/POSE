using cc105_pose_proj.Models;

namespace cc105_pose_proj.Services.Interfaces
{
    public interface IInventoryMovementService
    {
        int CalculateNewStock(int currentStock, int quantity, MovementType type);
        bool DeleteMovement(int id);
        List<InventoryMovement> GetMovements();
        List<InventoryMovement> GetMovementsByProductId(int productId);
        bool RecordMovement(int productId, MovementType type, int quantity, out int movementId);
    }
}