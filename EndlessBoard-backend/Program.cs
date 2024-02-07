using EndlessBoard_backend.models;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using EndlessBoard_backend.classes;
using Microsoft.Extensions.DependencyInjection;
using EndlessBoard_backend;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(connection));

builder.Services.AddScoped<ApplicationContext>();
builder.Services.AddScoped<BaseAction>();

var app = builder.Build();



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
