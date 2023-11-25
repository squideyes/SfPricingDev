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

    public static List<Benefit> ToBenefits(this Plan plan, int maxLots)
    {
        var benefits = new List<Benefit>();

        var info = plan switch
        {
            Free => new Info(Free, "5 Micro", "1", ""),
            Lite => new Info(Lite, "0.5 Std.", "1", ""),
            Flex => new Info(Flex, $"{maxLots} Std.", "2", "s"),
            Elite => new Info(Elite, "25 Std.", "3+", "s"),
            _ => throw new ArgumentOutOfRangeException(nameof(plan))
        };

        int id = 0;

        benefits.Add(Benefit.Create(id++, Yes,
            $"<b>{info.MaxLots} Lots</b> (<b>{info.Pools} Pool{info.Plural}</b>)",
            "The maximum number of forex lots that can be traded across all EAs and pools at once."));

        benefits.Add(Benefit.Create(id++, Yes,
            "Market-Savvy Updates",
            "SquidEyes believes in Science; Not Guesswork!"));

        benefits.Add(Benefit.Create(id++, Yes,
            "Setup / Config Wizard",
            "EA setup and configuration utility with step-by-step instructions and a video walkthrough."));

        benefits.Add(Benefit.Create(id++, Yes,
            "Email & Chat Support",
            "For setup, configuration, account and operational questions, but NOT FOR TRADING ADVICE."));

        benefits.Add(Benefit.Create(id++, info.Plan >= Flex ? Yes : No,
            "Setup Help (via Zoom)",
            "1:1 support; via Zoom"));

        benefits.Add(Benefit.Create(id++, info.Plan >= Flex ? Yes : No,
            "Join Our Discord",
            "Learn and grow as part of the SquidFolio community."));

        benefits.Add(Benefit.Create(id++, info.Plan >= Flex ? Yes : No,
            "Early-Access Program",
            "Get access to to our latest EAs and tunings; plus the ability to help shape SquidFolio's future."));

        benefits.Add(Benefit.Create(id++, info.Plan == Elite ? Yes : No,
            "1:1 w/SquidEyes Team",
            "Meet 1:1 with the SquidEyes founders (via Zoom or in NYC.)"));

        return benefits;
    }
}
