using System.Text.RegularExpressions;
using System.Text;

namespace CS13
{
    class Program13
    {
        public static void Run()
        {

            string sExample = "Xin chao";       // Khai báo và khởi tạo chuỗi
            sExample += " cac ban";             // Nối chuỗi +=, trả về "Xin chào các bạn"
            sExample = sExample + "!";          // Nối chuỗi +, trả về "Xin chào các bạn!"
            Console.WriteLine(sExample);

            string s = @"Da den voi ""Ngon ngu lap trinh C#"""; // Viết chuỗi nguyên bản với ký hiệu @
            Console.WriteLine(s);

            int a = 2, b = 3;
            Console.WriteLine($"Ket qua {a} + {b} la: {a + b}"); // Chèn thêm biểu thức vào chuỗi với ký hiệu $

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Xin chao cac ban");
            stringBuilder.Replace("Xin chao", "XIN CHAO");
            Console.WriteLine(stringBuilder);

            String text = @"Đay la dia chi email abc@gmail.com và 
              xyz@gmail.com can trich xuat";
            String pattern = @"(([^\s.]+)@((.[^\s]+)(\..[^\s]+)))";

            Regex rx = new Regex(pattern);

            // Tìm kiếm.
            MatchCollection matches = rx.Matches(text);

            Console.WriteLine("Tim thay {0} email trong:\n\n  {1}\n\n",
                            matches.Count,
                            text);
            // Xuất kết quả email tìm được
            foreach (Match match in matches)
            {
                GroupCollection groups = match.Groups;
                Console.WriteLine("{0}", groups[0].Value);
            }

        }
    }
}