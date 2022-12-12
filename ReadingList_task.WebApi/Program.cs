using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReadingList_task.Data;
using ReadingList_task.Data.Entities;
using ReadingList_task.Data.Repositories.Implementations;
using ReadingList_task.Data.Repositories.Interfaces;
using ReadingList_task.Services.Services.Implementations;
using ReadingList_task.Services.Services.Interfaces;
using ReadingList_task.Services.ViewModels;

var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy  =>
        {
            policy.WithOrigins("http://localhost:3000")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();;
        });
});

builder.Services.Configure<JsonOptions>(op =>
{
    op.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
});
builder.Services.AddDbContext<ReadingListDbContext>(options =>
    options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("Default")));
//builder.Services.AddDbContext<ReadingListDbContext>();
builder.Services.AddTransient<ICollectionService, CollectionService>();
builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddTransient<ILibraryService, LibraryService>();
builder.Services.AddTransient<IBooksOfUserRepository, BooksOfUserRepository>();
builder.Services.AddTransient<IBookRepository, BooksRepository>();
builder.Services.AddTransient<ICollectionRepository, CollectionRepository>();
builder.Services.AddTransient<IBooksOfUserToCollections, BooksOfUserToCollections>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();