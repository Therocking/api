

namespace Users.Models;

public class UserDto
{
    public int Id {get; set;}
    public string Name {get; set;}
    public string Mail {get; set;}

    public UserDto(User user) =>
      (Id, Name, Mail) = (user.Id, user.Name, user.Mail);
}

public class UpdateUserDto
{
    public string? Name {get; set;}
    public string? Pass {get; set;}

    public UpdateUserDto() {}
    public UpdateUserDto(User user) =>
      (Name, Pass) = (user.Name, user.Pass);
}

public class LoginUserDto
{
   public string Mail {get;} 
   public string Pass {get;}

   public LoginUserDto(string mail, string pass) =>
     (Mail, Pass) = (mail, pass);
}

public class RegisterUserDto
{
    public string Name {get; set;}
    public string Mail {get; set;}
    public string Pass {get; set;}

    public RegisterUserDto(string name, string mail, string pass) => 
      (Name, Mail, Pass) = (name, mail, pass);
}
