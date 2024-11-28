using System.Diagnostics;

namespace CS17
{
    public partial class Product
    {
        public float Price;
        public void ShowPrice()
        {
            Console.WriteLine($"Price: {Price}");
        }
    }
}
