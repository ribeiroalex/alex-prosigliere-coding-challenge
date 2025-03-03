using FluentValidation;
using Microsoft.EntityFrameworkCore;
using prosigliere_coding_challange.Infra.Contexts;
using prosigliere_coding_challange.Infra.Repositories;
using prosigliere_coding_challenge.Domain.Entities.Validators;
using prosigliere_coding_challenge.Domain.Handlers;
using prosigliere_coding_challenge.Domain.Mapping;
using prosigliere_coding_challenge.Domain.Repositories;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("connectionString")),
        optionsLifetime: ServiceLifetime.Scoped);

builder.Services.AddAutoMapper(typeof(BlogPostProfile));
builder.Services.AddTransient<IBlogPostsRepository, BlogPostRepository>();
builder.Services.AddTransient<ICommentsRepository, CommentsRepository>();
builder.Services.AddTransient<BlogPostsHandler>();
builder.Services.AddTransient<CommentsHandler>();

builder.Services.AddValidatorsFromAssemblyContaining<BlogPostValidator>(ServiceLifetime.Transient);


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors(x =>
    x.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
DataContext context = scope.ServiceProvider.GetRequiredService<DataContext>();
context.Database.Migrate();

app.Run();
