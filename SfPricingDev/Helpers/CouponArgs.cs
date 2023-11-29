namespace SfPricingDev;

public class CouponArgs : EventArgs
{
    public required string Coupon { get; init; }
    public required bool IsValid { get; init; }
    public required double? DiscountPercent { get; init; }
}
