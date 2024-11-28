namespace CS57
{
    public class Program57
    {
        public static async Task Run()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("MIGRATION");
            Console.ResetColor();
        }
    }
}
//dotnet ef migrations add V0 --context WebContext

//dotnet ef migrations list --context WebContext

//dotnet ef migrations remove --context WebContext

//dotnet ef database update --context WebContext

//dotnet ef database drop -f --context WebContext

//dotnet ef migrations script --context WebContext

//dotnet ef migrations script V1 V2 --context WebContext

//dotnet ef migrations script -o migrations.sql --context WebContext

//dotnet ef dbcontext scaffold -o Models -d "Data Source=TUAN\SQLEXPRESS;Initial Catalog = xtlab;User ID = sa;Password = 1234;Encrypt = false" "Microsoft.EntityFrameworkCore.SqlServer"
