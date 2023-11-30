// ********************************************************
// The use of this source code is licensed under the terms
// of the MIT License (https://opensource.org/licenses/MIT)
// ********************************************************

using Round3.Helpers;
using Microsoft.AspNetCore.Components;

namespace Round3.Models;

public class Benefit
{
    public required int Id { get; init; }
    public required string Description { get; init; }
    public required string Glyph { get; init; }
    public required string Tooltip { get; init; }

    public RenderFragment GetFragment() =>
        HtmlHelper.RenderHtml(Glyph + "&nbsp;" + Description);

    public static Benefit Create(int id,
         Glyph glyph, string description, string toolTip)
    {
        return new Benefit()
        {
            Id = id,
            Glyph = glyph.ToGlyph(),
            Description = description,
            Tooltip = toolTip
        };
    }
}