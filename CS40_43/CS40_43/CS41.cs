using Microsoft.Extensions.DependencyInjection;
namespace CS41
{
    class Program41
    {
        public static void Run()
        {
// RUN PHASE 1
            ClassC objectC = new ClassC();
            ClassB objectB = new ClassB(objectC);
            ClassA objectA = new ClassA(objectB);

            objectA.ActionA();          

            Car car1 = new Car(new HeavyHorn());
            car1.Beep();                            

            Car car2 = new Car(new LightHorn());
            car2.Beep();
// RUN PHASE 1

// RUN PHASE 2 Ví dụ vể service collection
            var services = new ServiceCollection();
             // Chỉ một dịch vụ được thực hiện 
            services.AddSingleton<IClassC, ClassC>();

            var provider = services.BuildServiceProvider();

            for (int i = 0; i < 5; i++)
            {
                var service = provider.GetService<IClassC>();
                Console.WriteLine(service.GetHashCode());
            }
// RUN PHASE 2

        }
    }
// PHASE 1
    class ClassC : IClassC
    {
        public void ActionC() => Console.WriteLine("Action in ClassC");
    }
    class ClassB
    {
        // ClassB phụ thuộc vào ClassC
        ClassC c_dependency;
        public ClassB(ClassC classc) => c_dependency = classc;
        public void ActionB()
        {
            Console.WriteLine("Action in ClassB");
            c_dependency.ActionC();
        }
    }

    class ClassA
    {
        // ClassA phụ thuộc vào ClassB
        ClassB b_dependency;
        public ClassA(ClassB classb) => b_dependency = classb;
        public void ActionA()
        {
            Console.WriteLine("Action in ClassA");
            b_dependency.ActionB();
        }
    }
// 
    public interface IHorn
    {
        void Beep();
    }
    public class Car
    {
        IHorn horn;
        public Car(IHorn horn) => this.horn = horn; 
        public void Beep() => horn.Beep();
    }
    public class HeavyHorn : IHorn
    {
        public void Beep() => Console.WriteLine("BEEP BEEP BEEP BEEP BEEP BEEP...");
    }

    public class LightHorn : IHorn
    {
        public void Beep() => Console.WriteLine("beep  beep  beep beep beep beep...");
    }
// PHASE 1

// PHASE 2
    interface IClassC
    {
        public void ActionC();
    }
// PHASE 2
}