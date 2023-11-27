// ********************************************************
// The use of this source code is licensed under the terms
// of the MIT License (https://opensource.org/licenses/MIT)
// ********************************************************

using SfPricingDev.Models;
using static SfPricingDev.Models.Glyph;
using static SfPricingDev.Models.Plan;

namespace SfPricingDev.Helpers;

public static class MiscExtenders
{
    private record struct Info(
        Plan Plan,
        string MaxLots,
        string Pools,
        string Plural);

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
        var benefits = new List<Benefit>();

        var flexPools = quantity switch
        {
            <= 5 => 2,
            <= 10 => 3,
            <= 15 => 5,
            _ => 5,
        };

        var info = plan switch
        {
            Free => new Info(Free, "5 Micro", "1", ""),
            Lite => new Info(Lite, "50 Micro", "1", ""),
            Flex => new Info(Flex, $"{quantity} Std.", flexPools.ToString(), "s"),
            _ => throw new ArgumentOutOfRangeException(nameof(plan))
        };

        int id = 0;

        benefits.Add(Benefit.Create(id++, Yes,
            $"<b>{info.MaxLots} Lots</b> (<b>{info.Pools} Pool{info.Plural}</b>)",
            "The maximum number of forex lots that can be traded across all EAs and pools at once."));

        benefits.Add(Benefit.Create(id++, Yes,
            "Market-Savvy Updates",
            "Frequently updates keep SquidFolio in step with evolving market conditions."));

        benefits.Add(Benefit.Create(id++, Yes,
            "Setup / Config Wizard",
            "EA setup and configuration utility; step-by-step guidance and a video walkthrough."));

        benefits.Add(Benefit.Create(id++, Yes,
            "Email & Chat Support",
            "For setup, configuration, account and operational questions, but NOT FOR TRADING ADVICE."));

        benefits.Add(Benefit.Create(id++, info.Plan >= Lite ? Yes : No,
            "Join Our Discord",
            "Learn and grow as part of the SquidFolio community."));

        benefits.Add(Benefit.Create(id++, info.Plan >= Flex ? Yes : No,
            "Setup Help (via Zoom)",
            "1:1 support; via Zoom"));

        benefits.Add(Benefit.Create(id++, info.Plan >= Flex ? Yes : No,
            "Early-Access Program",
            "Get access to to our latest EAs and tunings; plus the ability to help shape SquidFolio's future."));

        var canMeetFounders = info.Plan == Flex 
            && ((prePayAndSave && quantity >= 5) || quantity >= 10);

        benefits.Add(Benefit.Create(id++, canMeetFounders ? Yes : No,
            "1:1 w/SquidEyes Team",
            "Meet 1:1 with the SquidEyes founders (via Zoom or in NYC.)"));

        return benefits;
    }
}