
using webBancoGeneroso.Models;

namespace webBancoGeneroso.Utils
{
    public  class Menssager
    {
        public static MensageReturn SendMenssager(string title, string message, string tipo)
        {
            string msg = string.Format(message, tipo);

           return new MensageReturn()
            {
                Menssage = msg,
                Title = title
            }; 
        }
    }
}
