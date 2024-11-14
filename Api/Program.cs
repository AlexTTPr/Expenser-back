using Api;

using Application;

using Infrastructure;
using Infrastructure.Common;

var builder = WebApplication.CreateBuilder(args);


builder.Services
	.AddPresentation()
	.AddApplication()
	.AddInfrastructure(builder.Configuration);

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

//FIX: SHIT!
using(var scope = app.Services.CreateScope())
{
	DbSeeder.SeedDb(scope.ServiceProvider.GetRequiredService<AppDbContext>());
}


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
