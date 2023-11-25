using SfPricingDev.Models;

namespace SfPricingDev.Helpers;

public static class GlyphHelper
{
    public static string ToGlyph(this Glyph glyph)
    {
        return glyph switch
        {
            Glyph.Yes => "✅",
            Glyph.No => "❌",
            Glyph.Heart => "❤️ ",
            Glyph.Target => "🎯",
            _ => throw new ArgumentOutOfRangeException(nameof(glyph))
        };
    }
}
