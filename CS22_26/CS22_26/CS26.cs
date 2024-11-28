namespace CS26
{
    class Program26
    {
        public static void Run()
        {
            TestConstructor();
            GC.Collect();

            MyVector v1 = new MyVector(2, 3);
            MyVector v2 = new MyVector(3, 4);

            MyVector v3 = v1 + v2;
            v3.ShowXY();

            int ketqua = MethodStatic.Sum(1, 2); // gọi phương thức mà không cần tạo đối tượng
            Console.WriteLine($"Ket qua cua phuong thuc tinh: {ketqua}");

            Student s = new Student("Abc");
            string n = s.name;
            //s.name = "AA";
            // Lỗi vì không thể gán chỉ có thể đọc

            IndexerExam obj = new IndexerExam();

            Console.WriteLine(obj[0] + " " + obj[1]);      
            obj[0] = "Pham";                              
            obj[1] = "B";                        
            Console.WriteLine(obj[0] + " " + obj[1]);      
        }

        class Product
        {
            public string product_name;
            public Product(string name)
            {
                this.product_name = name;
                Console.WriteLine("Tao - " + product_name);
            }
            ~Product() // Hàm hủy
            {
                Console.WriteLine("Huy - " + product_name);
            }
        }

        static void TestConstructor()
        {
            Product p = new Product("ABC");
            p = null; // Nếu không gán p = null thì hàm hủy sẽ không chạy
        }

        class MyVector
        {
            double x;
            double y;
            public MyVector(double x, double y)
            {
                this.x = x;
                this.y = y;
            }
            public void ShowXY()
            {
                Console.WriteLine("x = " + x);
                Console.WriteLine("y = " + y);
            }

            public static MyVector operator +(MyVector a, MyVector b) // Quá tải 
            {
                double sx = a.x + b.x;
                double sy = a.y + b.y;
                MyVector v = new MyVector(sx, sy);
                return v;
            }
        }

        class MethodStatic // Phương thức tĩnh
        {
            public static int Sum(int a, int b)
            {
                return a + b;
            }         
        }

        class Student
        {
            // khai báo biến readonly - chỉ đọc
            public readonly string name;
            public Student(string name)
            {
                this.name = name;
            }
        }

        class IndexerExam
        {
            string ho = "Nguyen";
            string ten = "A";
            public string this[int index]
            {
                get
                {
                    if (index == 0) return ho;
                    else if (index == 1) return ten;
                    else throw new Exception("Chi so khong ton tai");
                }
                set
                {
                    if (index == 0) ho = value;
                    else if (index == 1) ten = value;
                    else throw new Exception("Chi so khong ton tai");
                }
            }

        }

    }
}