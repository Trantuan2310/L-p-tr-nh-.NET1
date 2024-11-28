using System.Data.Common;
using System.Data.SqlClient;
using System.Data;

namespace CS50
{
    class Program50
    {
        public static void Run()
        {
            string sqlStringConnection = "Data Source=TUAN\\SQLEXPRESS; Initial Catalog=xtlab; User ID=sa; Password=1234";
            Console.WriteLine(sqlStringConnection);

            using var connection = new SqlConnection(sqlStringConnection);

            connection.Open();

            using var command = new SqlCommand();
            command.Connection = connection;

// PHASE 1 ExecuteReader
            //// command.ExecuteReader(); - Dùng khi kết quả trả về có nhiều dòng
            //command.CommandText = "SELECT DanhMucID, TenDanhMuc, Mota FROM Danhmuc WHERE DanhmucID >= @DanhmucID";

            //var danhmucid = command.Parameters.AddWithValue("@DanhmucID", 5);

            //danhmucid.Value = 3;
            //using var sqlreader = command.ExecuteReader();
            //if (sqlreader.HasRows)
            //{
            //    while (sqlreader.Read())
            //    {
            //        var id = sqlreader.GetInt32(0);
            //        var ten = sqlreader["TenDanhMuc"];
            //        var mota = sqlreader["Mota"];

            //        Console.WriteLine($"{id} - {ten} - {mota}");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("No data");
            //}


// PHASE 2 ExecuteScalar
            //// command.ExecuteScalar(); -  Trả về 1 giá trị (1 dòng, 1 cột)
            //command.CommandText = "SELECT TenDanhMuc FROM DanhMuc WHERE DanhmucID >= 5;";
            //var sqlreader = command.ExecuteScalar();
            //Console.WriteLine(sqlreader);


// PHASE 3 ExecuteNonQuery
            ////command.ExecuteNonQuery(); -Insert, Update, Delete
            ////command.CommandText = "INSERT INTO Shippers (Hoten, Sodienthoai) VALUES (@Hoten, @Sodienthoai)";
            ////command.CommandText = "UPDATE Shippers SET Hoten = 'XanhSm' WHERE ShipperID = 4";
            //command.CommandText = "DELETE FROM Shippers WHERE ShipperID = 4";

            //var hoten = command.Parameters.AddWithValue("@Hoten", "");
            //hoten.Value = "Nguyen Van A";

            //var sodienthoai = command.Parameters.AddWithValue("@Sodienthoai", "");
            //sodienthoai.Value = "123456789";

            ////for (int i = 0; i < 3; i++)
            ////{
            ////    hoten.Value = "HoTen" + i;
            ////    sodienthoai.Value = "1234" + i;
            ////    var sqlreader = command.ExecuteNonQuery();
            ////    Console.WriteLine(sqlreader);
            ////}

            //var sqlreader = command.ExecuteNonQuery();
            //Console.WriteLine(sqlreader);


// PHASE 4 Procedure
            command.CommandText = "getproducinfo";
            command.CommandType = CommandType.StoredProcedure;

            var id = command.Parameters.AddWithValue("@id","");
            //var id = new SqlParameter("@id", 0);
            //command.Parameters.Add(id);
            id.Value = 3;

            var reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                var tensp = reader["TenSanPham"];
                var tendm = reader["TenDanhMuc"];

                Console.WriteLine($"{tensp} - {tendm}");
            }

            connection.Close();
        }
    }
}