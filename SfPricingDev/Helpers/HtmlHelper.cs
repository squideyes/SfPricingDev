using Microsoft.AspNetCore.Components;

namespace SfPricingDev.Helpers;

public static class HtmlHelper
{
    public static RenderFragment RenderHtml(string text) => builder =>
        builder.AddContent(0, new MarkupString(text!));
}
