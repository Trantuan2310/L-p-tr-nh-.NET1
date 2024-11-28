namespace CS19
{
    class Program19
    {
        public static void Run()
        {
            var myProfile = new // Kiểu vô danh
            {
                name = "A",
                age = 20,
            };
            Console.WriteLine(myProfile.name);

            //Dynamic biến được xác định bằng đối tượng gán vào ở thời điểm chạy
        }
    }
}