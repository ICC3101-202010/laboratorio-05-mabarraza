using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace Laboratorio_5
{
    public class User
    {
        public string Email { get; set; }
        
        public delegate void EmailVerifiedEventHandler(object source, EmailVerifiedEventArgs args);

        public event EmailVerifiedEventHandler EmailVerified;

        protected virtual void OnEmailVerified()
        {
            if (EmailVerified != null)
                EmailVerified(this, new EmailVerifiedEventArgs());
        }

        public void OnEmailSent(object source ,EmailSentEventArgs e)
        {
            string answer;
            Console.WriteLine("El email de registro ha sido enviado");
            Thread.Sleep(2000);
            verificacion:
            Console.WriteLine("¿Desea verificar su correo? Y/N");
            answer = Console.ReadLine();
            if (answer == "Y")
            {
                Console.WriteLine("Se abre el link...");
                Thread.Sleep(2000);
                OnEmailVerified();
                Thread.Sleep(2000);
            }
            else if (answer == "N")
            {
                Console.WriteLine("Cierras el email de verifcacion.");
                Thread.Sleep(2000);
            }
            else
            {
                Console.WriteLine("Comando Desconocido...");
                goto verificacion;
            }
        }
    }
}
