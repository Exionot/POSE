using cc105_pose_proj.Data;
using cc105_pose_proj.Models;

namespace cc105_pose_proj.Services
{
    public class InventoryMovementService : BaseService
    {
        private readonly ProductService _productService;
        private readonly InventoryMovementRepository _movementRepo;

        public InventoryMovementService(
            ProductService? productService = null,
            InventoryMovementRepository? movementRepo = null)
        {
            _productService = productService ?? new ProductService();
            _movementRepo = movementRepo ?? new InventoryMovementRepository();
        }

        public List<InventoryMovement> GetMovements()
        {
            if (CurrentUser == null) return [];

            var allMovements = _movementRepo.GetAll();

            if (IsAdmin)
                return allMovements;

            if (CurrentBusinessId == null)
                return [];

            return allMovements
                .Where(m => m.Product.Business.Id == CurrentBusinessId.Value)
                .ToList();
        }

        public List<InventoryMovement> GetMovementsByProductId(int productId)
        {
            if (CurrentUser == null) return [];

            var product = _productService.GetProductById(productId);
            if (product == null) return [];

            return _movementRepo.GetByProductId(productId);
        }

        public bool RecordMovement(int productId, MovementType type, int quantity)
        {
            if (CurrentUser == null) return false;
            if (quantity <= 0) return false;

            var product = _productService.GetProductById(productId);
            if (product == null) return false;

            bool isAddition = IsAddition(type);
            if (!isAddition && product.Quantity < quantity)
                return false;

            int newStock = isAddition
                ? product.Quantity + quantity
                : product.Quantity - quantity;

            product.Quantity = newStock;
            if (!_productService.UpdateProduct(product))
                return false;

            var movement = new InventoryMovement
            {
                Product = product,
                Type = type,
                Quantity = quantity,
                CreatedBy = CurrentUser,
                CreatedAt = DateTime.UtcNow
            };

            return _movementRepo.Add(movement);
        }

        private static bool IsAddition(MovementType type)
        {
            return type switch
            {
                MovementType.STOCK_IN or
                MovementType.ADJUST_IN or
                MovementType.RETURN => true,
                _ => false
            };
        }
    }
}
