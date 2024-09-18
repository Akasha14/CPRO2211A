using Microsoft.EntityFrameworkCore;
using MovieProject.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MovieContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("MovieContext")));

var app = builder.Build();

