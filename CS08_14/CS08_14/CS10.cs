namespace CS10
{
    class Program10
    {
        public static void Run()
        {
            var sungluc = new VuKhi(); // khai báo và sử dụng đối tượng    
            sungluc.name = "SUNG LUC";
            sungluc.SetDoSatThuong(5);

            VuKhi sungtruong = new VuKhi();
            sungtruong.name = "SUNG TRUONG";
            sungtruong.SetDoSatThuong(10);

            VuKhi sungmay = new VuKhi(name: "SUNG MAY", dosatthuong: 15);

            sungluc.TanCong();
            sungtruong.TanCong();
            sungmay.TanCong();
        }

        public class VuKhi // Khai báo lớp
        {
            public string name = "Tên vũ khí";
            int dosatthuong = 0;
            public VuKhi() // Constructor
            {
                this.dosatthuong = 1;
            }
            public VuKhi(string name, int dosatthuong) // Constructor
            {
                this.name = name;
                SetDoSatThuong(dosatthuong);
            }
            public void SetDoSatThuong(int mucdo)
            {
                this.dosatthuong = mucdo;
            }
            public void TanCong()
            {
                Console.Write(name + ": \t");
                for (int i = 0; i < dosatthuong; i++)
                {
                    Console.Write(" * ");
                }
                Console.WriteLine();
            }            
        }
        // Quá tải phương thức - Method Overloading
        // Các phương thức có cùng tên nhưng tham số khác nhau (trả về kiểu dữ liệu khác nhau)
    }
}