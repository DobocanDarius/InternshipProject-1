using API.Helpers;
using API.Manager;
using DataAccess.DbAccess;
using DataAccess.Models;
using DataAccess.Repository;
using WebApi.Manager;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPostManager, PostManager>();
builder.Services.AddScoped<IPost, DataAccess.Repository.Post>();
builder.Services.AddScoped<IUserManager, UserManager>();
builder.Services.AddScoped<IUser, DataAccess.Repository.User>();
builder.Services.AddScoped<ICommentManager, CommentManager>();
builder.Services.AddScoped<IComment, DataAccess.Repository.Comment>();
builder.Services.AddScoped<ITopicManager, TopicManager>();
builder.Services.AddScoped<ITopic, DataAccess.Repository.Topic>();
builder.Services.AddScoped<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddScoped<TokenManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
