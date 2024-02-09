using Microsoft.EntityFrameworkCore;
using Users.Models;
using Users.Repository;
using Users.Services;
using Users.Controller;
using Auth.Services;
using Auth.Repository;

public class Program
{
   public static void Main(string[] args)
   {
      var builder = WebApplication.CreateBuilder(args);
      builder.Services.AddDbContext<UserDb>(opt => 
          opt.UseInMemoryDatabase("Users"));
      builder.Services.AddScoped<IUserRepository, UserRepository>();
      builder.Services.AddScoped<IAuthRepository, AuthRepository>();
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

      // Mueve la lógica de resolución dentro del ámbito creado por CreateScope()
      using(var scope = app.Services.CreateScope())
      { 
        var services = scope.ServiceProvider;

        // Users
        var userRepository = app.Services.GetRequiredService<IUserRepository>();
        var userService = new UserService(userRepository);
        var userController = new UserController(userService);

        // Auth
        var authRepository = app.Services.GetRequiredService<IAuthRepository>();
        var authSerice = new AuthService(authRepository);
        var authController = new AuthController(authSerice);

        /* User routes */
        usersRouter.MapGet("/", userController.GetAll);
        usersRouter.MapGet("/{id}", userController.GetById);
        usersRouter.MapPut("/{id}", userController.Update);
        usersRouter.MapDelete("/{id}", userController.Delete);

        /* Auth routes */
        authRouter.MapPost("/login", authController.Login);
        authRouter.MapPost("/register", authController.Register);
      }

      app.Run();
   }
}
