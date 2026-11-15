using cc105_pose_proj.Models;
using Microsoft.VisualBasic.ApplicationServices;

namespace cc105_pose_proj.Services
{
    public class PricingService
    {
        public record LineItem(
            Product Product,
            int Quantity,
            decimal Price,
            Discount? AppliedDiscount,
            decimal DiscountAmount,
            decimal LineTotal
        );

        public record SaleSummary(
            List<LineItem> LineItems,
            decimal Subtotal,
            decimal TotalSaved,
            decimal GrandTotal
        );

        public record CartItem(Product Product, int Quantity);

        public decimal CalculateSubtotal(Product product, List<Discount> discounts)
        {
            Discount? best = FindBestDiscount(product, discounts);

            if (best == null)
                return product.Price;

            return ApplyDiscount(product.Price, best);
        }

        public SaleSummary CalculateSale(List<CartItem> cart, List<Discount> discounts)
        {
            var lineItems = new List<LineItem>();

            foreach (var cartItem in cart)
            {
                decimal price = cartItem.Product.Price;
                int quantity = cartItem.Quantity;
                Discount? applied = FindBestDiscount(cartItem.Product, discounts);
                decimal discountAmount = 0;

                if (applied != null)
                {
                    switch (applied.Type)
                    {
                        case Discount.DiscountType.PERCENTAGE:
                            discountAmount = (price * (applied.Value / 100m)) * quantity;
                            break;
                        case Discount.DiscountType.FIXED:
                            discountAmount = Math.Min(applied.Value, price) * quantity;
                            break;
                        case Discount.DiscountType.BUY_X_GET_Y:
                            int totalGet = applied.BuyAmount + applied.GetAmount;
                            if (totalGet > 0)
                            {
                                int freeItems = (cartItem.Quantity / totalGet) * applied.GetAmount;
                                discountAmount = freeItems * price;
                            }
                            break;
                    }
                }

                decimal lineTotal = (price * quantity) - discountAmount;

                lineItems.Add(new LineItem(
                    Product: cartItem.Product,
                    Quantity: quantity,
                    Price: price,
                    AppliedDiscount: applied,
                    DiscountAmount: discountAmount,
                    LineTotal: lineTotal
                ));
            }
            decimal subTotal = lineItems.Sum(l => l.Price * l.Quantity);
            decimal totalSaved = lineItems.Sum(l => l.DiscountAmount);
            decimal grandTotal = subTotal - totalSaved;

            return new SaleSummary(
                LineItems: lineItems,
                Subtotal: subTotal,
                TotalSaved: totalSaved,
                GrandTotal: grandTotal
            );
        }

        private static Discount? FindBestDiscount(Product product, List<Discount> activeDiscounts)
        {
            var applicable = activeDiscounts
                .Where(d => d.Active && IsDiscountApplicable(product, d))
                .ToList();

            if (!applicable.Any())
                return null;

            return applicable
                .OrderByDescending(d => CalculateSaving(product.Price, d))
                .First();
        }

        private static decimal CalculateSaving(decimal price, Discount discount)
        {
            return discount.Type switch
            {
                Discount.DiscountType.PERCENTAGE => price * (discount.Value / 100m),
                Discount.DiscountType.FIXED => Math.Min(discount.Value, price),
                Discount.DiscountType.BUY_X_GET_Y => 0m,
                _ => 0m
            };
        }

        private static bool IsDiscountApplicable(Product product, Discount discount)
        {
            if (!discount.EligibleItems.Any())
                return true;

            return discount.EligibleItems.Any(p => p.Id == product.Id);
        }

        private static decimal ApplyDiscount(decimal price, Discount discount)
        {
            return discount.Type switch
            {
                Discount.DiscountType.PERCENTAGE
                    => Math.Max(price - (price * (discount.Value / 100m)), 0),
                Discount.DiscountType.FIXED
                    => Math.Max(price - discount.Value, 0),
                _ => price
            };
        }
    }
}
