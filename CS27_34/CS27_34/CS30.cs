using System.Text;

namespace CS30
{
    class Program30
    {
        public static void Run()
        {
            // Lấy thông tin của Stream
            string filepath01 = @"D:\C#\CS27_34\CS27_34\Test01.txt";
            using (var stream = new FileStream(path: filepath01, mode: FileMode.Open, access: FileAccess.ReadWrite, share: FileShare.Read))
            {
                Console.WriteLine(stream.Name);
                Console.WriteLine($"Kich thuoc stream: {stream.Length} bytes \nVi tri {stream.Position}");
                Console.WriteLine($"Stream co the: Doc {stream.CanRead} -  Ghi {stream.CanWrite} - Seek {stream.CanSeek} - Timeout {stream.CanTimeout} ");
                Console.WriteLine();
            }

            // Ghi file text bằng stream
            string filepath02 = @"D:\C#\CS27_34\CS27_34\Test02.txt";
            using (var stream = new FileStream(path: filepath02, mode: FileMode.Create, access: FileAccess.Write, share: FileShare.None))
            {
                Encoding encoding = Encoding.UTF8; // Mã hóa tệp tin
                byte[] bom = encoding.GetPreamble(); // Trả về 1 mảng byte đại diện cho 
                stream.Write(bom, 0, bom.Length); // Ghi bom vào tệp

                string s = "Ghi file text bang stream";

                byte[] buffer = encoding.GetBytes(s);
                stream.Write(buffer, 0, buffer.Length);  // lưu vào stream
                Console.WriteLine("Ghi thanh cong vao file Test02");
                Console.WriteLine();
            }

            // Đọc file text bằng stream 
            string filepath03 = @"D:\C#\CS27_34\CS27_34\Test02.txt";
            int SIZEBUFFER = 256;
            using (var stream = new FileStream(path: filepath03, mode: FileMode.Open, access: FileAccess.ReadWrite, share: FileShare.Read))
            {
                Encoding encoding = GetEncoding(stream); // Xác định mã hóa
                Console.WriteLine(encoding.ToString());
                byte[] buffer = new byte[SIZEBUFFER]; // Chứa dữ liệu từ tệp đọc
                bool endread = false; // Dùng để xác định khi nào quá trình đọc file kết thúc 
                do
                {
                    int numberRead = stream.Read(buffer, 0, SIZEBUFFER);
                    if (numberRead == 0) endread = true;
                    if (numberRead < SIZEBUFFER) // Nếu số byte đọc ít hơn 256
                                                 // thì xóa các byte không được dùng
                    {
                        Array.Clear(buffer, numberRead, SIZEBUFFER - numberRead);
                    }
                    string s = encoding.GetString(buffer, 0, numberRead); // Chuyển đổi thành chuỗi mã hóa 
                    Console.WriteLine($"Noi dung cua file Test02: {s}");
                    break;
                } while (!endread);
            }

            // Copy file
            string filepath_src = @"D:\C#\CS27_34\CS27_34\Test01.txt";
            string filepath_des = @"D:\C#\CS27_34\CS27_34\Test03.txt";

            int SIZEBUFFER01 = 5;   // tăng lên đọc sẽ nhanh
            using (var streamwrite = File.OpenWrite(filepath_des))
            using (var streamread = File.OpenRead(filepath_src))
            {
                byte[] buffer = new byte[SIZEBUFFER]; // Chứa dữ liệu đọc
                bool endread = false; // Kiểm soát viêc đọc tệp
                do
                {
                    int numberRead = streamread.Read(buffer, 0, SIZEBUFFER);
                    if (numberRead == 0) endread = true;
                    else
                    {
                        streamwrite.Write(buffer, 0, numberRead);
                    }

                } while (!endread);

            }
        }
        public static Encoding GetEncoding(Stream stream)
        {
            byte[] BOMBytes = new byte[4]; // mảng chứa 4 byte để làm bộ nhớ lưu byte đọc được
            int offset = 0; // vị trí (index) trong buffer - nơi ghi byte đầu tiên đọc được
            int count = 4; // đọc 4 byte
            int numberbyte = stream.Read(BOMBytes, offset, count); // bắt đầu đọc 4 đầu tiên lưu vào buffer

            if (BOMBytes[0] == 0xfe && BOMBytes[1] == 0xff)
            {
                stream.Seek(2, SeekOrigin.Begin); // Di chuyển về vị trí bắt đầu của dữ liệu (đã trừ BOM)
                return Encoding.BigEndianUnicode;
            }
            if (BOMBytes[0] == 0xff && BOMBytes[1] == 0xfe)
            {
                stream.Seek(2, SeekOrigin.Begin); // Di chuyển về vị trí bắt đầu của dữ liệu (đã trừ BOM)
                return Encoding.Unicode;
            }

            if (BOMBytes[0] == 0xef && BOMBytes[1] == 0xbb && BOMBytes[2] == 0xbf)
            {
                stream.Seek(3, SeekOrigin.Begin);
                return Encoding.UTF8;
            }
            if (BOMBytes[0] == 0x2b && BOMBytes[1] == 0x2f && BOMBytes[2] == 0x76)
            {
                stream.Seek(3, SeekOrigin.Begin);
                return Encoding.UTF7;
            }
            if (BOMBytes[0] == 0xff && BOMBytes[1] == 0xfe && BOMBytes[2] == 0 && BOMBytes[3] == 0)
            {
                stream.Seek(4, SeekOrigin.Begin);
                return Encoding.UTF32;
            }
            if (BOMBytes[0] == 0 && BOMBytes[1] == 0 && BOMBytes[2] == 0xfe && BOMBytes[3] == 0xff)
            {
                stream.Seek(4, SeekOrigin.Begin);
                return Encoding.GetEncoding(12001);
            }

            stream.Seek(0, SeekOrigin.Begin);
            return Encoding.Default;

        }
    }
}