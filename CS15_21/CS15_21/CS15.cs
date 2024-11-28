namespace CS15
{
    class Program15
    {
        public static void Run()
        {
            var Human = new Animal(); // Sử dụng Class Animal
            Human.Legs = 2;
            Human.ShowLegs();
            var Cat = new Cat(); // Sử dụng Class Cat : Animal
            Cat.ShowLegs();
            Cat.Eat();
        } 
    }
    // Tính kế thừa
    class Animal
    {
        public int Legs { get; set; }
        public float Weight { get; set; }
        public void ShowLegs()
        {
            Console.WriteLine($"Legs:{Legs}");
        }
    }
    class Cat : Animal
    {
        public string Food { get; set; }
        public Cat()
        {
            Legs = 4;
            Food = "Fish";
        }
        public void Eat()
        {
            Console.WriteLine(Food);
        }
    }
    // Protected chỉ có thể truy cập cùng lớp hoặc lớp kế thừa
    // Sealed đánh dấu một lớp không bao giờ có lớp kế thừa
}