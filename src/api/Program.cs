var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MarkelTaskContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MarkelTaskDbContext")));
builder.Services.AddScoped<IMarkelTaskRepository, MarkelTaskRepository>();

var app = builder.Build();

app.MapGet("/company/{id}", (IMarkelTaskApi api, int id) => api.GetCompany(id));
app.MapGet("/claim/company/{companyId}", (IMarkelTaskApi api, int companyId) => api.GetClaims(companyId));
app.MapGet("/claim/{ucr}", (IMarkelTaskApi api, string ucr) => api.GetClaim(ucr));
app.MapPost("/claim", (IMarkelTaskApi api, ClaimModel claim) => api.UpdateClaim(claim));

app.Run();
