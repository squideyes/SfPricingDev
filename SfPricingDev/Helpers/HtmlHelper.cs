// ********************************************************
// The use of this source code is licensed under the terms
// of the MIT License (https://opensource.org/licenses/MIT)
// ********************************************************

using Microsoft.AspNetCore.Components;

namespace SfPricingDev.Helpers;

public static class HtmlHelper
{
    public static RenderFragment RenderHtml(string text) => builder =>
        builder.AddContent(0, new MarkupString(text!));
}