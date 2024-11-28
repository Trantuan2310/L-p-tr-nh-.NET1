using System.Net;
using System.Text;

namespace CS46
{
    class Program46
    {
        public static async Task Run()
        {
// RUN PHASE 1
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("RUN PHASE 1 HttpMessageHandler");
            Console.ResetColor();

            var url = "https://postman-echo.com/post";
            using HttpClientHandler handler = new HttpClientHandler();

            CookieContainer cookies = new CookieContainer();

            handler.CookieContainer = cookies;

            using var httpClient = new HttpClient(handler);

            using var httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Method = HttpMethod.Post;
            httpRequestMessage.RequestUri = new Uri(url);
            httpRequestMessage.Headers.Add("User-Agent", "Mozilla/5.0");
            var parameters = new List<KeyValuePair<string, string>>()
    {
        new KeyValuePair<string, string>("key1", "value1"),
        new KeyValuePair<string, string>("key2", "value2")

    };
            httpRequestMessage.Content = new FormUrlEncodedContent(parameters);

            var response = await httpClient.SendAsync(httpRequestMessage);

            cookies.GetCookies(new Uri(url)).ToList().ForEach(cookie =>
            {
                Console.WriteLine($"{cookie.Name} = {cookie.Value}");
            });

            var result = await response.Content.ReadAsStringAsync();
            Console.WriteLine(result);
// RUN PHASE 1

// RUN PHASE 2
            string url1 = "https://www.facebook.com/";

            CookieContainer cookies1 = new CookieContainer();

            // thay thế cookie mặc định của HttpClient bằng cookies1
            var bottomHandler = new MyHttpClientHandler(cookies1);             
            var changeUriHandler = new ChangeUri(bottomHandler);
            var denyAccessFacebook = new DenyAccessFacebook(changeUriHandler); 

            var httpClient1 = new HttpClient(denyAccessFacebook);

            httpClient1.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml+json");
            httpClient1.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
            HttpResponseMessage response1 = await httpClient1.GetAsync(url1);
            response1.EnsureSuccessStatusCode();
            string htmltext = await response1.Content.ReadAsStringAsync();

            Console.WriteLine(htmltext);
// RUN PHASE 2
        }
    }
// PHASE 2
    public class MyHttpClientHandler : HttpClientHandler
    {
        public MyHttpClientHandler(CookieContainer cookie_container)
        {

            CookieContainer = cookie_container;     
            AllowAutoRedirect = false;
            // Đặt chế độ giải nén tự động cho Deflate và GZip
            AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            UseCookies = true;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                                                                     CancellationToken cancellationToken)
        {
            Console.WriteLine("Start connecting " + request.RequestUri.ToString());
            // Gửi yêu cầu đến máy chủ và chờ phản hồi.
            var response = await base.SendAsync(request, cancellationToken);
            Console.WriteLine("Data download complete");
            return response;
        }
    }

    public class ChangeUri : DelegatingHandler
    {
        public ChangeUri(HttpMessageHandler innerHandler) : base(innerHandler) { }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                                                               CancellationToken cancellationToken)
        {
            var host = request.RequestUri.Host.ToLower();
            Console.WriteLine($"Check in  ChangeUri - {host}");
            if (host.Contains("google.com"))
            {
                // Đổi địa chỉ truy cập từ google.com sang github
                request.RequestUri = new Uri("https://github.com/");
            }
            // Chuyển truy vấn cho base (thi hành InnerHandler)
            return base.SendAsync(request, cancellationToken);
        }
    }


    public class DenyAccessFacebook : DelegatingHandler
    {
        public DenyAccessFacebook(HttpMessageHandler innerHandler) : base(innerHandler) { }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                                                                     CancellationToken cancellationToken)
        {

            var host = request.RequestUri.Host.ToLower();
            Console.WriteLine($"Check in DenyAccessFacebook - {host}");
            if (host.Contains("facebook.com"))
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new ByteArrayContent(Encoding.UTF8.GetBytes("Not accessible"));
                return await Task.FromResult<HttpResponseMessage>(response);
            }
            // Chuyển truy vấn cho base (thi hành InnerHandler)
            return await base.SendAsync(request, cancellationToken);
        }
    }
// PHASE 2
}