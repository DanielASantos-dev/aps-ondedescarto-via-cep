using ViaCepApi.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapMethods(EnderecoGet.Template, EnderecoGet.Metodo, EnderecoGet.Func);

app.Run();
