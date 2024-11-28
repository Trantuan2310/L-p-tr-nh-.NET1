using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace TranQuocTuan_DCCTCT6605E
{
    /// <summary>
    /// Interaction logic for frmShippers_2121050862_TranQuocTuan.xaml
    /// </summary>
    public partial class frmShippers_2121050862_TranQuocTuan : Window
    {
        private string connectionString = "Data Source=TUAN\\SQLEXPRESS; Initial Catalog=Northwind; User ID=sa; Password=1234;Trusted_Connection=True;";
        private bool isAddingNew = false;

        public frmShippers_2121050862_TranQuocTuan()
        {
            InitializeComponent();
            LoadShippers();
        }

        private void LoadShippers()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Shippers", conn);                   
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvShippers.ItemsSource = dt.DefaultView;
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Shippers WHERE 1=1";
                if (!string.IsNullOrEmpty(txtShipperID.Text))
                    query += $" AND ShipperID = {txtShipperID.Text}";
                if (!string.IsNullOrEmpty(txtCompanyName.Text))
                    query += $" AND CompanyName LIKE '%{txtCompanyName.Text}%'";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvShippers.ItemsSource = dt.DefaultView;
            }
        }

        private void dgvShippers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (dgvShippers.SelectedItem != null)
            //{
            //    DataRowView row = (DataRowView)dgvShippers.SelectedItem;
            //    txtShipperIDDetail.Text = row["ShipperID"].ToString();
            //    txtCompanyNameDetail.Text = row["CompanyName"].ToString();
            //    txtPhone.Text = row["Phone"].ToString();
            //    btnEdit.IsEnabled = true;
            //    btnDelete.IsEnabled = true;
            //}
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //txtShipperIDDetail.Clear();
            //txtCompanyNameDetail.Clear();
            //txtPhone.Clear();
            //txtShipperIDDetail.IsReadOnly = true;
            //btnSave.Tag = "Add";

            isAddingNew = true;
            grbChiTiet.Visibility = Visibility.Visible;

            txtShipperIDDetail.Text = string.Empty;
            txtCompanyNameDetail.Text = string.Empty;
            txtPhone.Text = string.Empty;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            //if (dgvShippers.SelectedItem != null)
            //{
            //    btnSave.Tag = "Edit";
            //}

            if (dgvShippers.SelectedItem != null)
            {
                isAddingNew = false;

                grbChiTiet.Visibility = Visibility.Visible;

                DataRowView row = (DataRowView)dgvShippers.SelectedItem;
                txtShipperIDDetail.Text = row["ShipperID"].ToString();
                txtCompanyNameDetail.Text = row["CompanyName"].ToString();
                txtPhone.Text = row["Phone"].ToString();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            //if (dgvShippers.SelectedItem != null)
            //{
            //    using (SqlConnection conn = new SqlConnection(connectionString))
            //    {
            //        conn.Open();
            //        DataRowView row = (DataRowView)dgvShippers.SelectedItem;
            //        string query = $"DELETE FROM Shippers WHERE ShipperID = {row["ShipperID"]}";
            //        SqlCommand cmd = new SqlCommand(query, conn);
            //        cmd.ExecuteNonQuery();
            //        MessageBox.Show("Xoá thành công!");
            //        LoadShippers();
            //    }
            //}

            if (dgvShippers.SelectedItem != null)
            {
                DataRowView row = (DataRowView)dgvShippers.SelectedItem;
                string shipperID = row["ShipperID"].ToString();

                MessageBoxResult result = MessageBox.Show("You want to delete this Shipper?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string deleteQuery = "DELETE FROM Shippers WHERE ShipperID = @ShipperID";
                        SqlCommand cmd = new SqlCommand(deleteQuery, conn);
                        cmd.Parameters.AddWithValue("@ShipperID", shipperID);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Delete successful.", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                            LoadShippers();
                        }
                        else
                        {
                            MessageBox.Show("Unable to delete. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a line to delete.", "Notification", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //using (SqlConnection conn = new SqlConnection(connectionString))
            //{
            //    conn.Open();
            //    string query;
            //    if (btnSave.Tag.ToString() == "Add")
            //    {
            //        query = $"INSERT INTO Shippers (CompanyName, Phone) VALUES ('{txtCompanyNameDetail.Text}', '{txtPhone.Text}')";
            //    }
            //    else // Edit
            //    {
            //        query = $"UPDATE Shippers SET CompanyName = '{txtCompanyNameDetail.Text}', Phone = '{txtPhone.Text}' WHERE ShipperID = {txtShipperIDDetail.Text}";
            //    }
            //    SqlCommand cmd = new SqlCommand(query, conn);
            //    cmd.ExecuteNonQuery();
            //    MessageBox.Show("Lưu thành công!");
            //    LoadShippers();
            //}

            if (string.IsNullOrEmpty(txtCompanyNameDetail.Text) || string.IsNullOrEmpty(txtPhone.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Notification", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd;

                if (isAddingNew)
                {
                    cmd = new SqlCommand(
                                    "SET IDENTITY_INSERT Shippers ON; " +
                                    "INSERT INTO Shippers (ShipperID, CompanyName, Phone) VALUES (@ShipperID, @CompanyName, @Phone); " +
                                    "SET IDENTITY_INSERT Shippers OFF;", conn);
                    cmd.Parameters.AddWithValue("@ShipperID", txtShipperIDDetail.Text);
                }
                else
                {
                    cmd = new SqlCommand("UPDATE Shippers SET CompanyName = @CompanyName, Phone = @Phone WHERE ShipperID = @ShipperID", conn);
                    cmd.Parameters.AddWithValue("@ShipperID", txtShipperIDDetail.Text);
                }

                cmd.Parameters.AddWithValue("@CompanyName", txtCompanyNameDetail.Text);
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);

                cmd.ExecuteNonQuery();
                LoadShippers();
            }

            grbChiTiet.Visibility = Visibility.Collapsed;
            MessageBox.Show("Save successful!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            //txtShipperIDDetail.Clear();
            //txtCompanyNameDetail.Clear();
            //txtPhone.Clear();
            //btnEdit.IsEnabled = false;
            //btnDelete.IsEnabled = false;

            grbChiTiet.Visibility = Visibility.Collapsed;
        }

        // Gán nút enter cho tìm kiếm theo CompanyName
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnSearch_Click(sender, e);
            }
        }


    }
}