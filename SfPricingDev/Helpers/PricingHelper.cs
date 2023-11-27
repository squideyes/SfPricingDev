// ********************************************************
// The use of this source code is licensed under the terms
// of the MIT License (https://opensource.org/licenses/MIT)
// ********************************************************

using SfPricingDev.Models;

namespace SfPricingDev;

internal static class PricingHelper
{
    private const double ONE_LOT_PRICE = 69.0;
    private const double MAX_MONTHLY_DISCOUNT = 0.15;
    private const double YEARLY_DISCOUNT = 0.2;
    private const double FREE_PRICE = 0.0;
    private const double LITE_PRICE = 39.0;

    public static double GetPrice(
        Plan plan, int quantity, Billing billing)
    {
        if (plan == Plan.Free)
            return FREE_PRICE;
        else if (plan == Plan.Lite)
            return LITE_PRICE;

        var price = CalcFlexPrice(quantity);

        if (billing == Billing.Month)
            return (int)Math.Round(price);

        price *= 12;

        return (int)Math.Round(price - (price * YEARLY_DISCOUNT));
    }

    private static double CalcFlexPrice(int quantity)
    {
        double discountRate;

        if (quantity >= 25)
        {
            discountRate = MAX_MONTHLY_DISCOUNT;
        }
        else
        {
            discountRate = MAX_MONTHLY_DISCOUNT
                * Math.Pow((double)quantity / 10, 2);
        }

        double totalCost = ONE_LOT_PRICE * quantity;

        return totalCost * (1 - discountRate);
    }
}