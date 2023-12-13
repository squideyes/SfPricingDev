// ********************************************************
// The use of this source code is licensed under the terms
// of the MIT License (https://opensource.org/licenses/MIT)
// ********************************************************

using Syncfusion.Blazor;
using Syncfusion.Licensing;
using SfPricingDev.Components;

var builder = WebApplication.CreateBuilder(args);

var licenceKey = builder.Configuration["Syncfusion:LicenseKey"];

SyncfusionLicenseProvider.RegisterLicense(licenceKey);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSyncfusionBlazor();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();