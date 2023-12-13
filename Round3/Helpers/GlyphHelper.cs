// ********************************************************
// The use of this source code is licensed under the terms
// of the MIT License (https://opensource.org/licenses/MIT)
// ********************************************************

using Round3.Models;

namespace Round3.Helpers;

public static class GlyphHelper
{
    public static string ToGlyph(this Glyph glyph)
    {
        return glyph switch
        {
            Glyph.Yes => "✅",
            Glyph.No => "❌",
            _ => throw new ArgumentOutOfRangeException(nameof(glyph))
        };
    }
}