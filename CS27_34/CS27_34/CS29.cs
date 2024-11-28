using System.IO;

namespace CS29
{
    class Program29
    {
        public static void Run()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (DriveInfo d in allDrives) // Duyệt qua từng ổ đĩa
            {
                Console.WriteLine("Drive {0}", d.Name);
                Console.WriteLine("  Drive type: {0}", d.DriveType);
                if (d.IsReady == true) // Kiểm tra ổ đĩa đã sẵn sàng chưa
                {
                    Console.WriteLine("  Volume label: {0}", d.VolumeLabel);
                    Console.WriteLine("  File system: {0}", d.DriveFormat);
                    Console.WriteLine("  Available space to current user:{0, 15} bytes", d.AvailableFreeSpace);
                    Console.WriteLine("  Total available space:          {0, 15} bytes", d.TotalFreeSpace);
                    Console.WriteLine("  Total size of drive:            {0, 15} bytes ", d.TotalSize);
                }
            }
            // Làm việc với File
            var filename = "test.txt"; // Tên File
            string contentfile = "Hello Word"; // Nội dung
            // Đường dẫn đến thưu mục
            var directoryPath = @"D:\C#\CS27_34\CS27_34";
            var directoryPath01 = @"C:\Users\trant\Searches";

            // Tạo thư mục nếu chưa tồn tại
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            // Tạo đường dẫn 
            var fullpath = Path.Combine(directoryPath, filename);
            // Lưu nội dung
            File.WriteAllText(fullpath, contentfile);

            string s = File.ReadAllText(fullpath);
            Console.WriteLine();
            Console.WriteLine($"Noi dung cua file: {s}");
            Console.WriteLine($"File luu tai: {fullpath} ");
            Console.WriteLine();

            //// Thêm vào File
            //string appendfile = "\nHello Word 01";
            //if (File.Exists(fullpath))
            //{
            //    File.AppendAllText(fullpath, appendfile);
            //    Console.WriteLine("Da them thanh cong");
            //    Console.WriteLine();
            //}
            //else
            //{
            //    File.WriteAllText(fullpath, contentfile);
            //    Console.WriteLine("Da tao file thanh cong");
            //    Console.WriteLine();
            //}

            // Làm việc với lớp Directory
            static void ListFileDirectory (string path)
            {
                String[] directories = System.IO.Directory.GetDirectories(path); // Lấy danh sách thư mục
                String[] files = System.IO.Directory.GetFiles(path); // Lấy danh sách file
                foreach (var file in files)
                {
                    Console.WriteLine(file);
                }
                foreach (var directory in directories)
                {
                    Console.WriteLine(directory);
                    ListFileDirectory(directory); // Đệ quy
                }
            }
            Console.WriteLine("Cac file va thu muc: ");
            ListFileDirectory(directoryPath);
        }
    }
}