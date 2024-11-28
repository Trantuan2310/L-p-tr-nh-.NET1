using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CS56
{
    public class Program56
    {
        public static async Task Run()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("SCAFFOLD");
            Console.ResetColor();
        }
    }
}
//dotnet ef
//dotnet ef dbcontext scaffold "Server=.\SQLEXPRESS;Database=shopdata55;User Id=sa;Password=1234;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models --force
