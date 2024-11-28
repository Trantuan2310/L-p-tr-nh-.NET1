namespace CS28
{
    class Program28
    {
        public static void Run()
        {
            using (var a = new A())
            {
                Console.WriteLine("Su dung using");
                Console.WriteLine();
            }

            using (WriteData writeData = new WriteData("filename.txt"))
            {
                Console.WriteLine("Su dung  IDisposable & ham huy");
            }
        }
        class A : IDisposable
        {
            bool ketqua = true;
            public void Dispose()
            {
                Console.WriteLine("End"); // Phương thức này được gọi khi hết using
                ketqua = false; // Run 7
            }
        }
        public class WriteData : IDisposable
        {           
            private bool m_Disposed = false; // Theo dõi trạng thái giải phóng
                                             // tài nguyên của lớp
            private StreamWriter stream;     // Dùng để ghi dữ liệu vào file 

            public WriteData(string filename) // Nhận file 
            {
                stream = new StreamWriter(filename, true);
            }
           
            public void Dispose()
            {
                Dispose(true); // Giải phóng tài nguyên
                GC.SuppressFinalize(this); // Ngăn việc gọi phương thức hủy khi đã
                                           // được giải phóng bởi Dispose()
            }
            
            protected virtual void Dispose(bool disposing) // Kiểm tra xem tài nguyên
                                                           // giải phóng hay chưa
            {
                if (!m_Disposed)
                {
                    if (disposing)
                    {                       
                        stream.Dispose();
                    }

                    m_Disposed = true;
                }
            }

            ~WriteData() // Phươnh thức hủy khi đối tượng không con được sử dụng
            {
                Dispose(false); // Run 13
            }

        }
    }
}