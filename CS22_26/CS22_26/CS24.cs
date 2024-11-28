namespace CS24
{
    class Program24
    {
        public static void Run()
        {
            Publisher p = new Publisher();
            SubscriberA sa = new SubscriberA();
            SubscriberB sb = new SubscriberB();

            sa.Sub(p);
            sb.Sub(p);

            p.Send();
        }
        
        public class Publisher
        {
            public delegate void NotifyNews(object data);

            // thêm từ khóa event vào định nghĩa event_news
            // public event NotifyNews event_news;
            // chỉ có thể đăng ký nhận sự kiện với toán tử +=
            // hoặc hủy nhận sự kiện với toán tử -=
            // chứ không thể thực hiện gán p.event_news = null
            public NotifyNews event_news; 

            public void Send()
            {
                event_news?.Invoke("Co tin moi");
            }
        }

        public class SubscriberA
        {
            public void Sub(Publisher p)
            {
                p.event_news += ReceiverFromPublisher;
            }
            void ReceiverFromPublisher(object data)
            {
                Console.WriteLine("SubscriberA: " + data.ToString());
            }
        }

        public class SubscriberB
        {
            public void Sub(Publisher p)
            {
                p.event_news = null;
                p.event_news += ReceiverFromPublisher;
            }
            void ReceiverFromPublisher(object data)
            {
                Console.WriteLine("SubscriberB: " + data.ToString());
            }
        }
    }
}