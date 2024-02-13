

namespace WebApi.Errors
{
    public class DiccionaryMsgErrors
    {
        public Dictionary<string, string> diccionarioErrores;

        public DiccionaryMsgErrors()
        {
            diccionarioErrores = new Dictionary<string, string>();
            diccionarioErrores.Add("USER_NOT_FOUND", "Usuario no encontrado.");
            diccionarioErrores.Add("INVALID_PASSWORD", "Contraseña inválida.");
            diccionarioErrores.Add("INTERNAL_ERROR", "Internal error.");
        }
    }
}