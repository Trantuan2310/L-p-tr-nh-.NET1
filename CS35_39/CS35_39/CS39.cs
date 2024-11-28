using System.Reflection;

namespace CS39
{
    class Program39
    {
        public static void Run()
        {
            A a = new A
            {
                Name = "HoTen",
                ID = 10
            };
            // Lấy kiểu đối tượng của a và danh sách thuộc tính của lớp A
            foreach (PropertyInfo property in a.GetType().GetProperties())
            {
                string property_name = property.Name; // Lấy tên của thuộc tính
                object property_value = property.GetValue(a); // Lấy giá trị thuộc tính
                Console.WriteLine($"Thuoc tinh {property_name} co gia tri la {property_value}");
            }
        }
        public class A
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
    }
}