using EndlessBoard_backend.models;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using EndlessBoard_backend.classes;
using Microsoft.Extensions.DependencyInjection;
using EndlessBoard_backend;
using Microsoft.AspNetCore.Http;
using EndlessBoard_backend.models;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(connection));

builder.Services.AddScoped<ApplicationContext>();
builder.Services.AddScoped<BaseAction>();

var app = builder.Build();

app.MapGet("/api/users", async (ApplicationContext context) =>
{
    var users = await context.Users.ToListAsync();
    return Results.Json(users);
});

app.MapGet("/api/users/{id}", async (ApplicationContext context, int id) =>
{
    var target = await context.Users.FirstOrDefaultAsync(u => u.Id == id);
    if (target != null)
    {
        return Results.Json(target);
    }
    else
    {
        return Results.Json(null);
    }
});

app.MapGet("/api/posts", async (ApplicationContext context, int offset = 0) =>
{
    var posts = await context.Posts
        .Skip(offset)
        .Take(25)
        .ToListAsync();

    return Results.Json(posts);
});

app.MapGet("/api/posts/{id}", async (ApplicationContext context, int id) =>
{
    var target = await context.Posts.FirstOrDefaultAsync(u => u.Id == id);
    if (target != null)
    {
        return Results.Json(target);
    }
    else
    {
        return Results.Json(null);
    }
});

app.MapGet("/api/comments/{user_id}", async (ApplicationContext context, int user_id) =>
{
    var target = await context.Comments
    .Where(c => c.UserId == user_id).ToListAsync();

    if( target != null)
    {
        return Results.Json(target);
    }
    else
    {
        return Results.Json(null);
    }
});

app.MapGet("/api/comments/{post_id}", async (ApplicationContext context, int post_id) => 
{
    var target = await context.Comments
    .Where(c => c.PostId == post_id).ToListAsync();
    if( target != null)
    {
        return Results.Json(target);
    }
    else { return Results.Json(null); }
});

app.MapGet("/api/reactions/", async (ApplicationContext context) =>
{
    var target = await context.Reactions.ToListAsync();
    if(target != null)
    {
        return Results.Json(target);
    }
    else
    {
        return Results.Json(null);
    }
});

app.MapGet("/api/reactions/{react_id}", async (ApplicationContext context,int react_id) =>
{
    var target = await context.Reactions.FirstOrDefaultAsync(n =>n.Id == react_id);
    if (target != null)
    {
        return Results.Json(target);
    }
    else
    {
        return Results.Json(null);
    }
});

app.MapGet("/api/reactionsList{list_id}", async (ApplicationContext context, int list_id) => 
{
    var target = await context.ReactionList.FirstOrDefaultAsync(n =>n.Id == list_id);
    if (target != null)
    {
        return Results.Json(target);
    }
    else 
    {
        return Results.Json(null);
    }
});

app.MapGet("/api/reactionsList{post_id}", async (ApplicationContext context, int post_id) => 
{
    var target = await context.ReactionList.FirstOrDefaultAsync(n => n.PostId == post_id);
    if (target != null)
    {
        return Results.Json(target);
    }
    else { return Results.Json(null); }
});

app.MapPost("/api/posts/", async(HttpContext context, string text, int user_id, int? image_id) => 
{
    var baseService = context.RequestServices.GetService<BaseAction>();
    var result = baseService.AddPost(user_id, text, image_id);
    if (result != null)
    {
        return Results.Json(result);
    }
    else
    {
        return Results.Json(null);
    }
});

app.MapPost("/api/comments", (HttpContext context, Post post, int user_id, string UserComm) =>
{
    var baseService = context.RequestServices.GetService<BaseAction>();
    var result = baseService.AddComment(post, user_id, UserComm);
    if (result != false)
    {
        return Results.Json(result);
    }
    else
    {
        return Results.Json(null);
    }
});


app.MapPost("/api/reactions", (HttpContext context,string reaction) =>
{
    var baseService = context.RequestServices.GetService<BaseAction>();
    var result = baseService.AddReaction(reaction);
    if (result != false)
    {
        return Results.Json(result);
    }
    else
    {
        return Results.Json(null);
    }
});

app.MapPost("/api/reactionsList", (HttpContext context, int userId, int postId, int reactionId)=>
{
    var baseService = context.RequestServices.GetService<BaseAction>();
    var result = baseService.AddReactionList(userId, postId, reactionId);
    if (result != false)
    {
        return Results.Json(result);
    }
    else
    {
        return Results.Json(null);
    }
});

app.MapDelete("/api/users/{id}", async (HttpContext context, int id) =>
{
    var baseService = context.RequestServices.GetService<BaseAction>();
    var result = baseService.RemoveUser(id);
    if (result)
    {
        return Results.Ok();
    }
    else
    {
        return Results.NotFound();
    }
});

app.MapDelete("/api/posts/{id}", async (HttpContext context, int id) =>
{
    var baseService = context.RequestServices.GetService<BaseAction>();
    var result = baseService.DeletePost(id);
    if (result)
    {
        return Results.Ok();
    }
    else
    {
        return Results.NotFound();
    }
});

app.MapDelete("/api/reactions/{id}", async (HttpContext context, int id) =>
{
    var baseService = context.RequestServices.GetService<BaseAction>();
    var result = baseService.DeleteReaction(id);
    if (result)
    {
        return Results.Ok();
    }
    else
    {
        return Results.NotFound();
    }
});

app.MapDelete("/api/reactionsList/{id}", async (HttpContext context, int id) =>
{
    var baseService = context.RequestServices.GetService<BaseAction>();
    var result = baseService.RemoveReactionList(id);
    if (result)
    {
        return Results.Ok();
    }
    else
    {
        return Results.NotFound();
    }
});


app.MapDelete("/api/comments/{id}", async (HttpContext context, int id) =>
{
    var baseService = context.RequestServices.GetService<BaseAction>();
    var result = baseService.DeleteComment(id);
    if (result)
    {
        return Results.Ok();
    }
    else
    {
        return Results.NotFound();
    }
});


app.MapGet("/", (HttpContext context) =>
{
    //var baseService = context.RequestServices.GetService<BaseAction>();
    //var result = baseService.AddUser("bomber", true, null, "sqwad123");
    //if (result != null)
    //{
    //    Console.WriteLine("пользователь успешно создан! ID is" + result.Id);
    //}
    //else { Console.WriteLine("ERROR!!!!"); }

    //var baseService = context.RequestServices.GetService<BaseAction>();
    //var result = baseService.RemoveUser(1);
    //if (result != null)
    //{
    //    Console.WriteLine("Sucsess!");

    //}
    //else { Console.WriteLine("ERROR!!!!"); }

    //var baseService = context.RequestServices.GetService<BaseAction>();
    //Post resultPost = baseService.AddPost(2, "my test!", null);
    //bool resultCom = baseService.AddComment(resultPost, 3, "nice");

    //if (resultCom == true)
    //{
    //    Console.WriteLine("Скрипт успешно выполнен!");
    //    return;
    //}
    //else { Console.WriteLine("на этапе создания поста или комментария произошла ошибка"); }
    //return;


    //var baseService = context.RequestServices.GetService<BaseAction>();
    //bool resultCom = baseService.DeleteComment(1);
    //if (resultCom == true)
    //{
    //    Console.WriteLine("комментарий успешно удалён");
    //}
    //bool resultPost = baseService.DeletePost(1);
    //if (resultPost == true)
    //{
    //    Console.WriteLine("пост успешно удалён");
    //}

    //var baseService = context.RequestServices.GetService<BaseAction>();
    //bool reactResult = baseService.AddReaction(":)");
    //if (reactResult)
    //{
    //    Console.WriteLine("реацкия успешно добавлена!");
    //}

    //bool reactDel = baseService.DeleteReaction(1);
    //if (reactDel)
    //{
    //    Console.WriteLine("реакция успешно удалена!");
    //}




});

app.Run();
