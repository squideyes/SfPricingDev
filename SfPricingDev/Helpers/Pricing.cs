// ********************************************************
// The use of this source code is licensed under the terms
// of the MIT License (https://opensource.org/licenses/MIT)
// ********************************************************

using SfPricingDev.Models;
using SquidEyes.Fundamentals;

namespace SfPricingDev.Helpers;

internal class Pricing
{
    private const int MAX_QUANTITY = 25;
    private const double PRICE_PER_LOT = 49.0;
    private const double DISCOUNT = 0.2;
    private const double FREE_PRICE = 0.0;
    private const double LITE_PRICE = 29.0;

    public static double GetPrice(
        Plan plan, int quantity, Billing billing)
    {
        plan.MustBe().EnumValue();
        quantity.MustBe().Between(1, MAX_QUANTITY);

        if (plan == Plan.Free)
            return FREE_PRICE;
        else if (plan == Plan.Lite)
            return LITE_PRICE;

        var price = PRICE_PER_LOT * quantity;

        if (billing == Billing.Month)
            return (int)Math.Round(price);

        price *= 12;

        return (int)Math.Round(price * (1 - DISCOUNT));
    }
}