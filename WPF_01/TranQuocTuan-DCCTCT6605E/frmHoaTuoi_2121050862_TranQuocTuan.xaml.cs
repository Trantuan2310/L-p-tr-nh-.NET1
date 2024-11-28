using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace TranQuocTuan_DCCTCT6605E
{
    public partial class frmHoaTuoi_2121050862_TranQuocTuan : Window
    {
        private string connectionString = "Data Source=TUAN\\SQLEXPRESS; Initial Catalog=QLHoaTuoi; User ID=sa; Password=1234;Trusted_Connection=True;";
        private bool isAddingNew = false;

        public frmHoaTuoi_2121050862_TranQuocTuan()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM HoaTuoi", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvDanhSach.ItemsSource = dt.DefaultView;
            }
        }

        private void btnTimKiem_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM HoaTuoi WHERE 1=1";
                if (!string.IsNullOrEmpty(txtMaHoaTuoi.Text)) query += $" AND MaHoaTuoi LIKE '%{txtMaHoaTuoi.Text}%'";
                if (!string.IsNullOrEmpty(txtTenHoaTuoi.Text)) query += $" AND TenHoaTuoi LIKE '%{txtTenHoaTuoi.Text}%'";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvDanhSach.ItemsSource = dt.DefaultView;
            }
        }
        private void dgvDanhSach_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //// Hiển thị chi tiết sản phẩm khi chọn dòng
            //if (dgvDanhSach.SelectedItem is DataRowView selectedRow)
            //{
            //    // Hiển thị khu vực chi tiết sản phẩm
            //    grbChiTiet.Visibility = Visibility.Visible;

            //    // Điền dữ liệu vào các TextBox
            //    txtMaHoaTuoiChiTiet.Text = selectedRow["MaHoaTuoi"].ToString();
            //    txtTenHoaTuoiChiTiet.Text = selectedRow["TenHoaTuoi"].ToString();
            //    dtpNgaySX.SelectedDate = DateTime.TryParse(selectedRow["NgaySX"].ToString(), out var ngaySX) ? ngaySX : (DateTime?)null;
            //    dtpNgayHH.SelectedDate = DateTime.TryParse(selectedRow["NgayHH"].ToString(), out var ngayHH) ? ngayHH : (DateTime?)null;
            //    txtDonVi.Text = selectedRow["DonVi"].ToString();
            //    txtDonGia.Text = selectedRow["DonGia"].ToString();
            //    txtGhiChu.Text = selectedRow["GhiChu"].ToString();
            //}
            //else
            //{
            //    // Ẩn khu vực chi tiết sản phẩm nếu không có dòng nào được chọn
            //    grbChiTiet.Visibility = Visibility.Collapsed;

            //    // Xóa sạch dữ liệu trên các TextBox trong trường hợp không có dòng nào được chọn
            //    txtMaHoaTuoiChiTiet.Text = string.Empty;
            //    txtTenHoaTuoiChiTiet.Text = string.Empty;
            //    dtpNgaySX.SelectedDate = null;
            //    dtpNgayHH.SelectedDate = null;
            //    txtDonVi.Text = string.Empty;
            //    txtDonGia.Text = string.Empty;
            //    txtGhiChu.Text = string.Empty;
            //}
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            isAddingNew = true;
            //Thêm mới hoa tươi
            // Hiển thị khu vực chi tiết để nhập dữ liệu mới
            grbChiTiet.Visibility = Visibility.Visible;

            // Xóa sạch các trường chi tiết để chuẩn bị cho việc nhập liệu mới
            txtMaHoaTuoiChiTiet.Text = string.Empty; // Mã có thể để trống nếu database tự sinh
            txtTenHoaTuoiChiTiet.Text = string.Empty;
            dtpNgaySX.SelectedDate = null;
            dtpNgayHH.SelectedDate = null;
            txtDonVi.Text = string.Empty;
            txtDonGia.Text = string.Empty;
            txtGhiChu.Text = string.Empty;

        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            // Cập nhật hoa tươi
            if (dgvDanhSach.SelectedItem != null)
            {
                isAddingNew = false;

                grbChiTiet.Visibility = Visibility.Visible;

                DataRowView row = (DataRowView)dgvDanhSach.SelectedItem;
                txtMaHoaTuoiChiTiet.Text = row["MaHoaTuoi"].ToString();
                txtTenHoaTuoiChiTiet.Text = row["TenHoaTuoi"].ToString();
                dtpNgaySX.SelectedDate = DateTime.Parse(row["NgaySX"].ToString());
                dtpNgayHH.SelectedDate = DateTime.Parse(row["NgayHH"].ToString());
                txtDonVi.Text = row["DonVi"].ToString();
                txtDonGia.Text = row["DonGia"].ToString();
                txtGhiChu.Text = row["GhiChu"].ToString();
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            // Xoá hoa tươi
            if (dgvDanhSach.SelectedItem != null)
            {
                DataRowView row = (DataRowView)dgvDanhSach.SelectedItem;
                string maHoaTuoi = row["MaHoaTuoi"].ToString();

                MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa hoa tươi này không?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string deleteQuery = "DELETE FROM HoaTuoi WHERE MaHoaTuoi = @MaHoaTuoi";
                        SqlCommand cmd = new SqlCommand(deleteQuery, conn);
                        cmd.Parameters.AddWithValue("@MaHoaTuoi", maHoaTuoi);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Xóa thành công.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                            LoadData(); // Tải lại dữ liệu để cập nhật DataGrid sau khi xóa
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa. Vui lòng thử lại.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            // Kiểm tra nếu mã hoa tươi rỗng
            if (string.IsNullOrEmpty(txtMaHoaTuoiChiTiet.Text))
            {
                MessageBox.Show("Vui lòng nhập mã hoa tươi.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd;

                // Kiểm tra nếu thêm mới (khi txtMaHoaTuoiChiTiet không trống)
                if (IsAddingNewFlower(txtMaHoaTuoiChiTiet.Text))
                {
                    // Lệnh SQL thêm mới hoa tươi với mã hoa tươi người dùng nhập
                    cmd = new SqlCommand("INSERT INTO HoaTuoi (MaHoaTuoi, TenHoaTuoi, NgaySX, NgayHH, DonVi, DonGia, GhiChu) VALUES (@MaHoaTuoi, @TenHoaTuoi, @NgaySX, @NgayHH, @DonVi, @DonGia, @GhiChu)", conn);

                }
                else // Nếu cập nhật hoa tươi
                {
                    cmd = new SqlCommand("UPDATE HoaTuoi SET TenHoaTuoi = @TenHoaTuoi, NgaySX = @NgaySX, NgayHH = @NgayHH, DonVi = @DonVi, DonGia = @DonGia, GhiChu = @GhiChu WHERE MaHoaTuoi = @MaHoaTuoi", conn);
                }

                cmd.Parameters.AddWithValue("@MaHoaTuoi", txtMaHoaTuoiChiTiet.Text);
                // Thêm các tham số chung
                cmd.Parameters.AddWithValue("@TenHoaTuoi", txtTenHoaTuoiChiTiet.Text);
                cmd.Parameters.AddWithValue("@NgaySX", dtpNgaySX.SelectedDate ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@NgayHH", dtpNgayHH.SelectedDate ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@DonVi", txtDonVi.Text);
                cmd.Parameters.AddWithValue("@DonGia", txtDonGia.Text);
                cmd.Parameters.AddWithValue("@GhiChu", txtGhiChu.Text);

                cmd.ExecuteNonQuery(); // Thực thi lệnh SQL
                LoadData(); // Tải lại dữ liệu để cập nhật
            }

            grbChiTiet.Visibility = Visibility.Collapsed; // Ẩn giao diện chi tiết sau khi lưu
            //isAddingNew = false;

        }

        private bool IsAddingNewFlower(string maHoaTuoi)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM HoaTuoi WHERE MaHoaTuoi = @MaHoaTuoi", conn);
                cmd.Parameters.AddWithValue("@MaHoaTuoi", maHoaTuoi);

                int count = (int)cmd.ExecuteScalar();
                return count == 0; // Nếu không có bản ghi với mã này thì là thêm mới
            }
        }

        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            // Hủy thao tác
            grbChiTiet.Visibility = Visibility.Collapsed; // Ẩn giao diện chi tiết mà không lưu
        }
    }
}

