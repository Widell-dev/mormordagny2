using api.Helpers;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("mysql");

builder.Services.AddDbContext<MormorDagnysContext>(options =>
{
    //options.UseSqlite(builder.Configuration.GetConnectionString("sqlite"));
    options.UseMySql(connectionString,
    new MySqlServerVersion(new Version(8, 0, 36)));

});

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddAutoMapper(options =>
{
    options.LicenseKey = "eyJhbGciOiJSUzI1NiIsImtpZCI6Ikx1Y2t5UGVubnlTb2Z0d2FyZUxpY2Vuc2VLZXkvYmJiMTNhY2I1OTkwNGQ4OWI0Y2IxYzg1ZjA4OGNjZjkiLCJ0eXAiOiJKV1QifQ.eyJpc3MiOiJodHRwczovL2x1Y2t5cGVubnlzb2Z0d2FyZS5jb20iLCJhdWQiOiJMdWNreVBlbm55U29mdHdhcmUiLCJleHAiOiIxODA2NjI0MDAwIiwiaWF0IjoiMTc3NTEzNjIzNSIsImFjY291bnRfaWQiOiIwMTlkNGU1YzdhOTk3MjdlOTE2MTczNjFmNmY5NWI1OSIsImN1c3RvbWVyX2lkIjoiY3RtXzAxa243NXRyYnBucDZqd3Q1eGI0djFqMmszIiwic3ViX2lkIjoiLSIsImVkaXRpb24iOiIwIiwidHlwZSI6IjIifQ.rUZpqAO2TlP5y9L-6Fo8ZlGtS2RCUEL9UVU5ySS2E_QMTYNVRf50j2ueBYLD6FyYu55PNDq2BfhquoIrwn2_FXJO9W2W-lB57vqkjun0RNROrTcSb4bFW-YB9cgrqU3QkYhCOXe7CaUILPnv8pNY4rpKS8N-iuymuABrTVan7a7L5FYLArBqIjvzSB0pvdWJlu4t0cX97JFfRIawSbFmA343aVKZCQUMg0xPlYflXhRk65UBGZzR3Qu0rBTXVUCWnTmyUvsrUpCHbvnw71AkIohzbe_UynhTdd3Sb4VT6pXAOYgwHcQVT2P-wTDbGUh3rwXBAFy6lgsgLJCF2w6yeA";
    options.AddProfile(new MappingProfiles());
});

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();


