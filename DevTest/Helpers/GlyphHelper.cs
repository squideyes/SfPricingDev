// ********************************************************
// The use of this source code is licensed under the terms
// of the MIT License (https://opensource.org/licenses/MIT)
// ********************************************************

using DevTest.Models;

namespace DevTest.Helpers;

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