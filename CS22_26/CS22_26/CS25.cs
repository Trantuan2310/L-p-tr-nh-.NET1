using System.Linq;

namespace CS25
{
    class Program25
    {
        public static void Run()
        {
            List<int> ds = new List<int>() { 1, 2, 3, 4 };
            var vs = ds.Where(i => i >= 3); // Nếu không có thư viện Linq thì sẽ bị lỗi
                                            // vì List không có trong phương thức Where

            foreach (var number in vs)
            {
                Console.WriteLine(number);
            }
        }
    }
}