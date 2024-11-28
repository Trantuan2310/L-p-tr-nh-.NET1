using System.Linq;
using TT.Utils;
namespace CS43
{
    public class Program43
    {
        public static void Run()
        {
            double a = 23102024;
            var kq = CovertMoneyToText.NumberToText(a);
            Console.WriteLine(kq);
        }
    }
}