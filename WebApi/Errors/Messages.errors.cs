

namespace WebApi.Errors
{
    public class DiccionaryMsgErrors
    {
        public Dictionary<string, string> diccionarioErrores;

        public DiccionaryMsgErrors()
        {
            diccionarioErrores = new Dictionary<string, string>();
            diccionarioErrores.Add("USER_NOT_FOUND", "Usuario no encontrado.");
            diccionarioErrores.Add("INCORRECT_PASSWORD", "Contraseña incorrecta.");
            diccionarioErrores.Add("INTERNAL_ERROR", "Internal error.");
        }
    }
}