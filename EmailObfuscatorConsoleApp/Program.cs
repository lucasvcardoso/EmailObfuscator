using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmailObfuscator;

namespace EmailObfuscatorConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type the e-mail address to obfuscate:");
            string email = Console.ReadLine();
            Console.WriteLine($"Obfuscated e-mail: {Email.Obfuscate(email, 25)}");
            Console.ReadLine();
        }
    }
}
