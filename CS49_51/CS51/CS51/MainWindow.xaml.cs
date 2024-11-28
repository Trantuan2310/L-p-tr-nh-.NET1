using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CS51
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataTable table = new DataTable("Nhanvien");
        SqlConnection connection;
        SqlDataAdapter adapter;
        DataSet dataSet = new DataSet();
        public MainWindow()
        {
            InitAdapter();
            InitializeComponent();
        }
        void InitAdapter()
        {
            string sqlStringConnection = "Data Source=TUAN\\SQLEXPRESS; Initial Catalog=xtlab; User ID=sa; Password=1234";
            connection = new SqlConnection(sqlStringConnection);
            connection.Open();

            // PHASE 2 DataAdapter
            adapter = new SqlDataAdapter();
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

            dataSet.Tables.Add(table); 
        }
        void LoadDataTable()
        {
            table.Rows.Clear();
            adapter.Fill(dataSet);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataTable();
            datagrid.DataContext = table.DefaultView;
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            LoadDataTable();
            datagrid.DataContext = table.DefaultView;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            adapter.Update(dataSet);
            table.Rows.Clear ();
            adapter.Fill(dataSet);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedItem = (DataRowView)datagrid.SelectedItem;
            if (selectedItem != null)
            {
                selectedItem.Delete();
            }
        }
    }
}