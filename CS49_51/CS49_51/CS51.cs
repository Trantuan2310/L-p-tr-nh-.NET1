using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace CS51
{
    class Program51
    {
        public static void ShowDataTable(DataTable table)
        {
            Console.WriteLine($"Table name: {table.TableName}");
            Console.Write($"{"Index",15}");
            foreach (DataColumn c in table.Columns)
            {
                Console.Write($"{c.ColumnName, 15}");
            }
            Console.WriteLine();

            int index = 0;

            foreach(DataRow r in table.Rows)
            {
                Console.Write($"{index, 15}");
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    Console.Write($"{r[i], 15}") ;
                }
                Console.WriteLine();
                index++;
            }
        }
        public static void Run()
        {
            string sqlStringConnection = "Data Source=TUAN\\SQLEXPRESS; Initial Catalog=xtlab; User ID=sa; Password=1234";
            Console.WriteLine(sqlStringConnection);
            using var connection = new SqlConnection(sqlStringConnection);

            connection.Open();

// PHASE 1 DataSet
            // var dataset = new DataSet();
            // var table = new DataTable("MyTable");
            // dataset.Tables.Add(table);

            // table.Columns.Add("STT");
            // table.Columns.Add("HoTen");
            // table.Columns.Add("Tuoi");

            // table.Rows.Add(1, "Nguyen Van A", 21);
            // table.Rows.Add(2, "Nguyen Van B", 23);
            // table.Rows.Add(3, "Nguyen Van C", 25);

            //ShowDataTable(table);
// PHASE 1 DataSet

// PHASE 2 DataAdapter
            var adapter = new SqlDataAdapter();
            adapter.TableMappings.Add("Table", "NhanVien");
            // SelectCommand
            adapter.SelectCommand = new SqlCommand("SELECT NhanviennID, Ten, Ho FROM NhanVien", connection);
            // InsertCommand
            adapter.InsertCommand = new SqlCommand("INSERT INTO Nhanvien (Ho, Ten) VALUES (@Ho, @Ten)", connection);
            adapter.InsertCommand.Parameters.Add("@Ho", SqlDbType.NVarChar, 255, "Ho");
            adapter.InsertCommand.Parameters.Add("@Ten", SqlDbType.NVarChar, 255, "Ten");
            // DeleteCommand
            adapter.DeleteCommand = new SqlCommand("DELETE FROM Nhanvien WHERE NhanviennID = @NhanviennID", connection);
            var pr1 = adapter.DeleteCommand.Parameters.Add(new SqlParameter("@NhanviennID", SqlDbType.Int));
            pr1.SourceColumn = "NhanviennID";
            pr1.SourceVersion = DataRowVersion.Original;
            // UpdateCommand
            adapter.UpdateCommand = new SqlCommand("UPDATE Nhanvien SET Ho = @Ho, Ten = @Ten WHERE NhanviennID = @NhanviennID", connection);
            var pr2 = adapter.UpdateCommand.Parameters.Add(new SqlParameter("@NhanviennID", SqlDbType.Int));
            pr2.SourceColumn = "NhanviennID";
            pr2.SourceVersion = DataRowVersion.Original;
            adapter.UpdateCommand.Parameters.Add("@Ho", SqlDbType.NVarChar, 255, "Ho");
            adapter.UpdateCommand.Parameters.Add("@Ten", SqlDbType.NVarChar, 255, "Ten");

            var dataSet = new DataSet();
            adapter.Fill(dataSet);

            DataTable table = dataSet.Tables["NhanVien"];
            ShowDataTable(table);

            //var row = table.Rows.Add();
            //row["Ten"] = "A";
            //row["Ho"] = "Nguyen Van";

            //var row10 = table.Rows[10];
            //row10.Delete();

            //var r = table.Rows[9];
            //r["Ten"] = "Anh";

            adapter.Update(dataSet);

            connection.Close();
        }
    }
}