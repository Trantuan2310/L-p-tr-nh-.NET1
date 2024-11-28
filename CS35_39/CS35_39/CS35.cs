namespace CS35
{
    class Program35
    {
        public static void Run()
        {
            // PHASE 1
            Console.WriteLine("TEST DICTIONARY");
            Dictionary<string, int> sodem = new Dictionary<string, int>()
            {
                ["one"] = 1,
                ["two"] = 2,
                ["three"] = 3,
                ["four"] = 4,
            };
            // Số phần tử 
            Console.WriteLine($"So phan tu trong dictionary la:{sodem.Count}");
            
            // Truy cập đến phần tử có key
            Console.WriteLine($"Phan tu thu nhat la:{sodem["one"]}"); 
            
            // Lấy danh sách các key
            var key = sodem.Keys;
            Console.Write("Danh sach key: ");
            foreach(var k in key)
            {
                Console.Write(k + " ");
            }
            Console.WriteLine();

            // Lấy danh sách các values
            var value = sodem.Values;
            Console.Write("Danh sach values: ");
            foreach (var k in value)
            {
                Console.Write(k + " ");
            }
            Console.WriteLine();

            // Thêm một phần tử
            sodem.Add("five", 5); // Hoặc sodem["five"] = 5;

            // Xóa một phần tử
            sodem.Remove("four");
            var key1 = sodem.Keys;
            Console.Write("Danh sach key sau khi xoa va them: ");
            foreach (var k in key1)
            {
                Console.Write(k + " ");
            }
            Console.WriteLine();

            //Loại bỏ tất cả các phần tử
            sodem.Clear();
            var key2 = sodem.Keys;
            Console.Write("Danh sach key sau khi xoa all: ");
            foreach (var k in key1)
            {
                Console.Write(k + " ");
            }
            Console.WriteLine();
            // PHASE 1

            // PHASE 2
            Console.WriteLine("TEST HASHSET");
            HashSet<int> hashset = new HashSet<int>()
            {
                10, 7, 8, 9, 6
            };
            Console.WriteLine($"So phan tu trong hashset la: {hashset.Count}");
            Console.Write("Danh sach phan tu trong hashset: ");
            foreach (var v in hashset)
            {
                Console.Write(v + " ");
            }
            Console.WriteLine();
            hashset.Add(11); // Thêm một phần tử
            hashset.Remove(7); // Xóa một phần tử
            Console.Write("Danh sach phan tu sau khi xoa va them: ");
            foreach (var v in hashset)
            {
                Console.Write(v + " ");
            }
            Console.WriteLine();

            //hashset.Clear();
            //Console.Write("Danh sach phan tu sau khi xoa all: ");
            //foreach (var v in hashset)
            //{
            //    Console.Write(v + " ");
            //}
            //Console.WriteLine();

            // Kiểm tra xem có chứa tập khác không
            HashSet<int> hashset1 = new HashSet<int>();
            hashset1.Add(8);
            hashset1.Add(6);
            if (hashset.IsSupersetOf(hashset1))
            {
                Console.WriteLine("hashset la tap chua hashset1");
            }
            else
            {
                Console.WriteLine("hashset khong chua hashset1");
            }

            HashSet<int> hashset2 = new HashSet<int>();
            hashset2.Add(3);
            hashset2.Add(4);
            if (hashset.IsSupersetOf(hashset2))
            {
                Console.WriteLine("hashset la tap chua hashset2");
            }
            else
            {
                Console.WriteLine("hashset khong chua hashset2");
            }
        }
    }
}