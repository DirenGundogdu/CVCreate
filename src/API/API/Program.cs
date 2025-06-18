
using MediatR;
using Resume.Infrastructure;
using Users.Application;
using Users.Application.Commands.LoginUser;
using Users.Infrastructure;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddApplication();
builder.Services.AddInfrastructureUser(builder.Configuration);
builder.Services.AddInfrastructureResume(builder.Configuration);
builder.Services.AddMediatR(typeof(LoginUserQueryHandler).Assembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.UseHttpsRedirection();

app.Run();