using Microsoft.EntityFrameworkCore;
using MinimalApi.Application.Abstractions;
using MinimalApi.Application.Posts.Commands;
using MinimalApi.DataAccess;
using MinimalApi.DataAccess.Repositories;
using MediatR;
using MinimalApi.Application.Posts.Queries;
using MinimalApi.Domain.Models;
using MinimalApi.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.RegisterServices();


var app = builder.Build();


app.Use(async (ctx, next) =>
{
	try
	{
		await next();
	}
	catch (Exception)
	{
		ctx.Response.StatusCode = 500;
		await ctx.Response.WriteAsync("An error occurred");
	}
});
app.UseHttpsRedirection();

app.RegisterEndpointDefinitions();

app.Run();


