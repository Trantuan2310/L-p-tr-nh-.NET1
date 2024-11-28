namespace CS34
{
    class Program34
    {
        public static void Run()
        {
            // Khai báo - khởi tạo một LinkedList
            LinkedList<string> cacbaihoc = new LinkedList<string>();

            // AddFirst(T)	Chèn một nút có dữ liệu T vào đầu danh sách
            // AddLast(T)	Chèn một nút có dữ liệu T vào cuối danh sách
            cacbaihoc.AddFirst("Bai hoc 3");   // thêm vào đầu danh sach
            cacbaihoc.AddLast("Bai hoc 4");    // thêm vào cuối
            cacbaihoc.AddFirst("Bai hoc 2");
            cacbaihoc.AddFirst("Bai hoc 1");


            // Lấy phần tử đầu tiên, sau đó duyệt đến cuối
            Console.WriteLine("Nut tu dau ve cuoi: ");
            LinkedListNode<string> node = cacbaihoc.First;
            while (node != null)
            {
                Console.WriteLine(node.Value);
                node = node.Next;   // node gán bằng nút sau nó
            }


            // Lấy phần tử cuối cùng, sau đó duyệt về phần tử đầu  tiên
            Console.WriteLine("Nut tu cuoi len dau: ");
            node = cacbaihoc.Last;
            while (node != null)
            {
                Console.WriteLine(node.Value);
                node = node.Previous;   // node gán bằng nút phía trước nó
            }
        }
    }
}
// List	Thuộc tính - tham chiếu (trỏ) đến LinkedList
// Value Thuộc tính - là dữ liệu của Node
// Next	Thuộc tính - tham chiếu (trỏ) đến NÚT tiếp theo (phía sau) - null thì nó là nút cuối
// Previous	Thuộc tính - tham chiếu (trỏ) đến NÚT phía trước - null thì nó là nút đầu tiên
// MỘT SỐ THUỘC TÍNH TRONG LINKEDLIST
// Count Số nút trong danh sách
// First	Nút đầu tiên của danh sách
// Last	Nút đầu tiên của danh sách
// AddFirst(T)	Chèn một nút có dữ liệu T vào đầu danh sách
// AddLast(T)	Chèn một nút có dữ liệu T vào cuối danh sách
// AddAfter(Node, T)	Chèn nút với dữ liệu T, vào sau nút Node (kiểu LinkedListNode)
// AddBefore(Node, T)	Chèn nút với dữ liệu T, vào trước nút Node (kiểu LinkedListNode)
// Clear()	Xóa toàn bộ danh sách
// Contains(T)	Kiểm tra xem có nút với giá trị dữ liệu bằng T
// Remove(T)	Xóa nút có dữ liệu bằng T
// RemoveFirst()	Xóa nút đầu tiên
// RemoveLast()	Xóa nút cuối cùng
// Find(T)	Tìm một nút