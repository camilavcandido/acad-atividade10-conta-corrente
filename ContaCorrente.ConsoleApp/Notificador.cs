using System;
namespace ContaCorrente.ConsoleApp
{
        public class Notificador{

        public void ApresentaMensagem(string msg, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;
            Console.WriteLine(msg);
            Console.ResetColor();
        } 
        
        }

}

