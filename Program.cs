using Microsoft.EntityFrameworkCore;
using Users.Models;
using Users.Repository;
using Users.Services;
using Users.Controller;

public class Program
{
   public static void Main(string[] args)
   {
      var builder = WebApplication.CreateBuilder(args);
      builder.Services.AddDbContext<UserDb>(opt => 
          opt.UseInMemoryDatabase("Users"));
      builder.Services.AddDatabaseDeveloperPageExceptionFilter();

      /*Swagger*/
      builder.Services.AddEndpointsApiExplorer();
      builder.Services.AddSwaggerGen();


      var app = builder.Build();

      // Configure the HTTP request pipeline.
      if (app.Environment.IsDevelopment())
      {
          app.UseSwagger();
          app.UseSwaggerUI();
      }

      var usersRouter = app.MapGroup("/users");
      var authRouter = app.MapGroup("/auth");

      app.MapGet("/", () => "Hello World!");

      /*DI*/
      var userRepository = new UserRepository();
      var userService = new UserService(userRepository);
      var userController = new UserController(userService);

      /* User routes */
      usersRouter.MapGet("/", userController.GetAll);
      usersRouter.MapGet("/{id}", userController.GetById);
      usersRouter.MapPut("/{id}", userController.Update);
      usersRouter.MapDelete("/{id}", userController.Delete);

      /* Auth routes */
      authRouter.MapPost("/login", AuthController.Login);
      authRouter.MapPost("/register", AuthController.Register);

      app.Run();
   }
}
