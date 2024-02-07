

namespace Users.Models;

public class User
{
   public int Id {get; set;} 
   public string Name {get; set;} 
   public string Mail {get; set;} 
   public string Pass {get; set;} 

   public User(string name, string mail, string pass) =>
     (Name, Mail, Pass) = (name, mail, pass);
}
