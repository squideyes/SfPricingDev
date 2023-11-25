﻿using Syncfusion.Blazor;
using Syncfusion.Licensing;
using SfPricingDev.Components;

var builder = WebApplication.CreateBuilder(args);

SyncfusionLicenseProvider.RegisterLicense(
    "MjkxODk1OEAzMjMzMmUzMDJlMzBtVFE2Z3h2VXIySWN2Q3pDVVdmQ2tpUHV5QzZFSXhTd1lJbzA0a2lnMDVVPQ==");

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