using Azure.Data.Tables;
using FieldExporter.UI.Components;
using FieldExporter.UI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<TableServiceClient>(sp =>
{ 
    var connectionString = builder.Configuration.GetValue<string>("ConnectionStrings:field-exporter") 
        ?? throw new InvalidOperationException("Azure Table Storage connection string is not configured.");

    return new TableServiceClient(connectionString);
});

builder.Services.AddSingleton<AzureTableStorageService>();

//builder.AddAzureTableClient("field-exporter");

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
