using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace CS49
{
    class Program49
    {
        public static void Run()
        {
            //var sqlstringBuilder = new SqlConnectionStringBuilder();
            //sqlstringBuilder["Server"] = "TUAN\\SQLEXPRESS";
            //sqlstringBuilder["Database"] = "xtlab";
            //sqlstringBuilder["UID"] = "sa";
            //sqlstringBuilder["PWD"] = "1234";

            //var sqlStringConnection = sqlstringBuilder.ToString();
            //Console.WriteLine(sqlStringConnection);

            string sqlStringConnection = "Data Source=TUAN\\SQLEXPRESS; Initial Catalog=xtlab; User ID=sa; Password=1234";
            Console.WriteLine(sqlStringConnection);
            using var connection = new SqlConnection(sqlStringConnection);

            connection.Open();
            Console.WriteLine($"State Server:{connection.State}");

            using DbCommand command = connection.CreateCommand();
            //using DbCommand command = new SqlCommand();
            //command.Connection = connection;
            command.CommandText = "SELECT TOP (5) * FROM SanPham";

            var datareader = command.ExecuteReader();
           
            while (datareader.Read())
            {
                Console.WriteLine($"{datareader["TenSanPham"]}: {datareader["Gia"]}");
            }

            connection.Close();
            Console.WriteLine($"State Server:{connection.State}");
        }
    }
}