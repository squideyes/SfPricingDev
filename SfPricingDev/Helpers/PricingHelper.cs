using SfPricingDev.Models;

namespace SfPricingDev;

internal static class PricingHelper
{
    public static int GetPrice(Plan plan, double oneLotPrice, 
        int quantity, Billing billing, double yearlyDiscount)
    {
        if (plan == Plan.Free)
            return 0;
        else if (plan == Plan.Lite)
            return 39;
        else if (plan == Plan.Elite)
            return 9999;

        var price = CalcFlexPrice(oneLotPrice, quantity);

        if (billing == Billing.Month)
            return (int)Math.Round(price);
        else
            return (int)Math.Round(price - (price * yearlyDiscount));
    }

    private static double CalcFlexPrice(
        double oneLotPrice, int quantity)
    {
        const double maxDiscountRate = 0.15;
        
        double discountRate;

        if (quantity >= 10)
        {
            discountRate = maxDiscountRate;
        }
        else
        {
            discountRate = maxDiscountRate
                * Math.Pow((double)quantity / 10, 2);
        }

        double totalCost = oneLotPrice * quantity;

        return totalCost * (1 - discountRate);
    }
}
