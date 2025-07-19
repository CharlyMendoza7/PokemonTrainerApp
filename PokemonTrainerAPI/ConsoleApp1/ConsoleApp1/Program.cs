using System.Security.Cryptography;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)));
        }
    }
}