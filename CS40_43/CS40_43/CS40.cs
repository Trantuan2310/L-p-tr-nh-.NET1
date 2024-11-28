using System.ComponentModel.DataAnnotations;

namespace CS40
{
    class Program40
    {
        public static void Run()
        {
// RUN PHASE 1
             var a = new Class01 ();
      // Đọc các Attribute của lớp
      // Trả về kdl của a và danh sách các attribute được gán cho lớp
      foreach (Attribute lop in a.GetType ().GetCustomAttributes (false)) {
      // Chuyển đổi kiểu dữ liệu của "lop" thanh ViDu
        ViDu mota = lop as ViDu;
        if (mota != null) {
          Console.WriteLine ($"{a.GetType().Name,10} : {mota.Example}");
        }
      }

      // Đọc Attribute của từng thuộc tính lớp
      // Trả về danh sách các thuộc tính của lớp
      foreach (var thuoctinh in a.GetType ().GetProperties ()) {
      // Trả về các attribute của thuộc tính 
        foreach (Attribute tt in thuoctinh.GetCustomAttributes (false)) {
          ViDu mota = tt as ViDu;
          if (mota != null) {
            Console.WriteLine ($"{thuoctinh.Name,10} : {mota.Example}");
          }
        }
      }

      // Đọc Attribute của phương thức
      // Trả về danh sách các phương thức của lớp
      foreach (var phuongthuc in a.GetType ().GetMethods ()) {
       // Trả về danh sách các attribute của phương thức
        foreach (Attribute pt in phuongthuc.GetCustomAttributes (false)) {
          ViDu mota = pt as ViDu;
          if (mota != null) {
            Console.WriteLine ($"{phuongthuc.Name,10} : {mota.Example}");
          }
        }
      }
// RUN PHASE 1
// RUN PHASE 2
            Class02 user = new Class02();
            user.Name = "Nguyen Van A";
            user.Age = 50;
            user.PhoneNumber = "1234as";
            user.Email = "abc@gmail.com";

            // Cung cấp thông tin về đối tượng kiểm tra
            ValidationContext context = new ValidationContext(user, null, null);
            // lưu kết quả kiểm tra
            List<ValidationResult> results = new List<ValidationResult>();
            // kiểm tra dựa trên data annotations (PHASE 2)
            bool valid = Validator.TryValidateObject(user, context, results, true);

            if (!valid)
            {
                foreach (ValidationResult vr in results)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    // In ra tên thuộc tính gây lỗi
                    Console.Write($"{vr.MemberNames.First(),12}");
                    // In ra thông báo lỗi
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($":{vr.ErrorMessage}");

                    Console.ForegroundColor= ConsoleColor.White;
                }
            }
// RUN PHASE 2
        }
    }
// PHASE 1
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Method)]
    public class ViDu : Attribute 
    {
        public ViDu(string v) => Example = v;

        public string Example { set; get; }
    }

    [ViDu("Day la vi du ve lop")]
    public class Class01
    {
        [ViDu("Day la vi du ve thuoc tinh")]
        public string ThuocTinh { set; get; }
        [ViDu("Day la vi du ve phuong thuc")]
        public void PhuongThuc()
        {
            Console.WriteLine();
        }
    }
// PHASE 1

// PHASE 2
    public class Class02
    {
        // Thuộc tính "name" phải cung cấp giá trị không được để trống
        [Required(ErrorMessage = "{0} la ten loi")]
        // Xác định độ dài của "name"
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Ten tu 3 đen  100 ky tu")]
        // Dữ liệu phải là kiểu văn bản
        [DataType(DataType.Text)]
        public string Name { get; set; }

        // Xác định vùng tuổi
        [Range(1, 45, ErrorMessage = "Qua tuoi quy dinh")]
        public int Age { get; set; }

        // Dữ liệu phải là kiểu số điện thoại
        [DataType(DataType.PhoneNumber)]
        // Kiểm tra giá trị nhập vào có phải số điện thoại
        [Phone]
        public string PhoneNumber { set; get; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
    }
// PHASE 2
}