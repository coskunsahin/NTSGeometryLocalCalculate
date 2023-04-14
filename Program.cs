
using NetTopologySuite;
using NetTopologySuite.IO.Converters;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // this constructor is overloaded.  see other overloads for options.
        var geoJsonConverterFactory = new GeoJsonConverterFactory();
        options.JsonSerializerOptions.Converters.Add(geoJsonConverterFactory);
    });

// nothing to do with NTS.IO.GeoJSON4STJ specifically, but a recommended
// best-practice is to inject this instead of using the global variable:
builder.Services.AddSingleton(NtsGeometryServices.Instance);
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
