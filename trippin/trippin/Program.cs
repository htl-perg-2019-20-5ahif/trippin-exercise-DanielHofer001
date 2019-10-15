using System;
using System.Threading.Tasks;

namespace trippin
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello Tripin!");
            await new Tripin().CheckUsers();
            Console.ReadLine();
        }
    }
}
