// ********************************************************
// The use of this source code is licensed under the terms
// of the MIT License (https://opensource.org/licenses/MIT)
// ********************************************************

using SfPricingDev.Models;
using static SfPricingDev.Models.Glyph;
using static SfPricingDev.Models.Plan;

namespace SfPricingDev.Helpers;

public static class BenefitsExtenders
{
    public static string ToTagLine(this Plan plan)
    {
        return plan switch
        {
            Free => "&quot;Kick The Tires&quot; (prove to yourself that SquidFolio works).",
            Lite => "Up your trading game while putting minimal capital at risk.",
            Flex => "Trade multiple EA pools to improve your profit potential.",
            _ => throw new ArgumentOutOfRangeException(nameof(plan))
        };
    }

    public static List<Benefit> ToBenefits(
        this Plan plan, int quantity, bool prePayAndSave)
    {
        var maxLots = plan switch
        {
            Free => "5 Micro",
            Lite => "5 Mini",
            Flex => $"{quantity} Std.",
            _ => throw new ArgumentOutOfRangeException(nameof(plan))
        };

        var multi = plan == Flex && quantity >= 5;

        var canMeetFounders = plan == Flex
            && ((prePayAndSave && quantity >= 5) || quantity >= 10);

        var benefits = new List<Benefit>();

        int id = 0;

        benefits.Add(Benefit.Create(id++, Yes,
            $"<b>{maxLots} Lots</b> (At Once)",
            "Maximum number of lots<br/>that can be traded across all MT4 instances at once."));

        if (multi)
        {
            benefits.Add(Benefit.Create(id++, Yes, $"Trade 2+ FX Accounts",
                "Hedge across multiple FX accounts (without violating NFA Rule 2-43b)."));
        }
        else
        {
            benefits.Add(Benefit.Create(id++, Yes, $"Trade One FX Account",
                "Trade one FX account,<br/>without hedging<br/>(per NFA Rule 2-43b)."));
        }

        benefits.Add(Benefit.Create(id++, Yes,
            "Market-Savvy Updates",
            "Frequent updates keep SquidFolio in step with evolving market conditions."));

        benefits.Add(Benefit.Create(id++, Yes,
            "Setup / Config Wizard",
            "EA setup and configuration utility, step-by-step guidance and a video walkthrough."));

        benefits.Add(Benefit.Create(id++, Yes,
            "Email & Chat Support",
            "For account, setup, config and operational questions, but NOT FOR TRADING ADVICE."));

        benefits.Add(Benefit.Create(id++, plan >= Lite ? Yes : No,
            "Join Our Discord",
            "Learn and grow as part of the SquidFolio community."));

        benefits.Add(Benefit.Create(id++, plan >= Flex ? Yes : No,
            "Setup Help (via Zoom)",
            "1:1 support; via Zoom"));

        benefits.Add(Benefit.Create(id++, plan >= Flex ? Yes : No,
            "Early-Access Program",
            "Get access to to our latest EAs and settings; plus the ability to help shape SquidFolio's future."));

        benefits.Add(Benefit.Create(id++, canMeetFounders ? Yes : No,
            "1:1 w/SquidEyes Team",
            "Meet 1:1 with the SquidEyes founders (via Zoom or in NYC.)"));

        return benefits;
    }
}