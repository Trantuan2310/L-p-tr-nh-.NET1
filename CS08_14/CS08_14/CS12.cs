namespace CS12
{
    class Program12
    {
        public static void Run()
        {
            int a = 100;
            int b = a; // b copy giá trị của a
            Console.WriteLine($"a = {a}, b = {b}");

            b = 200; // b gán giá trị mới, a không thay đổi - vì chúng không cùng tham
            Console.WriteLine($"a = {a}, b = {b}");

            Stutent x = new Stutent("Nguyen Van A");
            Console.WriteLine(x.Name);
            Stutent y;
            // Khi gán, tham chiếu không sao chép giá trị mà tham chiếu địa chỉ
            // nên có thể có x là y, y là x, y thay đổi nghĩa là x thay đổi
            y = x;
            y.Name = "Nguyen Van B";
            Console.WriteLine(x.Name);
        }
        // Kiểu tham chiếu
        public class Stutent
        {
            public string Name;
            public Stutent(string name)
            {
                this.Name = name;
            }
        }
    }
}