using CS46;
using System.Net.Http.Headers;
using System.Text;

namespace CS45
{
    class Program45
    {
        public static async Task Run()
        {          
// RUN PHASE 1
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("RUN PHASE 1 GET WITH HTTPCLIENT");
            Console.ResetColor();

            var htmltask = GetWebContent("https://google.com.vn");
            htmltask.Wait();

            var html = htmltask.Result;
            Console.WriteLine("First 255 characters:");
            Console.WriteLine(html != null ? html.Substring(0, 255) : "Error");
// RUN PHASE 1

// RUN PHASE 2
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("RUN PHASE 2 ReadAsStreamAsync AND ReadAsByteArrayAsync");
            Console.ResetColor();

            var httpclient = new ExHttpClient();
            var url1 = "https://cafebiz.cafebizcdn.vn/2019/1/9/photo-2-1547004128934984544374.jpg";
            var task1 = httpclient.DownloadDataBytes(url1);
            await task1;
            byte[] dataimg = task1.Result;
            string filepath = "anh1.png";
            using (var stream = new FileStream(filepath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                stream.Write(dataimg, 0, dataimg.Length);
                Console.WriteLine("save " + filepath);
            }

            string url2 = "https://th.bing.com/th/id/OIP.W-GlTwP6rVTwmTbpDzWN0gHaIR?w=1044&h=1166&rs=1&pid=ImgDetMain";
            var task2 = httpclient.DownloadDataStream(url2);
            await task2;
            int SIZEBUFFER = 500;
            string filepath2 = "anh2.png";
            using (var streamwrite = File.OpenWrite(filepath2))
            using (var streamread = task2.Result)
            {
                byte[] buffer = new byte[SIZEBUFFER]; 
                bool endread = false;
                do
                {
                    int numberRead = streamread.Read(buffer, 0, SIZEBUFFER);
                    if (numberRead == 0) endread = true;
                    else
                    {
                        streamwrite.Write(buffer, 0, numberRead);
                    }

                } while (!endread);

            }
            Console.WriteLine("save " + filepath2);
// RUN PHASE 2

// RUN PHASE 3
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("RUN PHASE 3 SendAsync");
            Console.ResetColor();

            var url = "https://xuanthulab.net/api/";
            var json = @"
                {
                    ""id"":""1"", 
                    ""method"":""timestampToDate"", 
                    ""params"": {""routin"":""UnixTime"", ""timestamp"":""1483228800""}
                }";
            ExHttpClient01 Ex = new ExHttpClient01();
            var task = Ex.SendAsyncJson(url, json);
            task.Wait();
            Console.WriteLine(task.Result);
// RUN PHASE 3
        }
// PHASE 1
        public static void ShowHeaders(HttpHeaders headers)
        {
            Console.WriteLine("List Header:");
            foreach (var header in headers)
            {
                string value = string.Join(" ", header.Value);
                Console.WriteLine($"{header.Key,20} : {value}");
            }
            Console.WriteLine();
        }

        public static async Task<string> GetWebContent(string url)
        {
            // Giải phóng tài nguyên khi không cần thiết
            using (var httpClient = new HttpClient())
            {
                Console.WriteLine($"Starting connect {url}");
                try
                {
                    // Thêm header vào yêu cầu, chỉ định các định dạng mà có thể xử lý
                    httpClient.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml+json");
                    HttpResponseMessage response = await httpClient.GetAsync(url);

                    // Kiểm tra trạng thái của response nếu thành công thì tiếp túc ngược lại chạy catch
                    response.EnsureSuccessStatusCode();

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Download successful - statusCode {(int)response.StatusCode} {response.ReasonPhrase}");
                        ShowHeaders(response.Headers);

                        Console.WriteLine("Starting read data");

                        string htmltext = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"Get {htmltext.Length} characters");
                        Console.WriteLine();
                        return htmltext;
                    }
                    else
                    {
                        Console.WriteLine($"Error - statusCode {response.StatusCode} {response.ReasonPhrase}");
                        return null;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
        }
// PHASE 1

// PHASE 2     
        public class ExHttpClient : IDisposable
        {
            public HttpClient httpClient;
            public ExHttpClient()
            {
                httpClient = new HttpClient();
            }
            // Giải phóng tài nguyên
            public void Dispose()
            {
                if (httpClient != null)
                {
                    httpClient.Dispose();
                    httpClient = null;
                }
            }
            // ReadAsByteArrayAsync
            public async Task<byte[]> DownloadDataBytes(string url)
            {
                Console.WriteLine($"Starting connect {url}");
                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsByteArrayAsync();
                    Console.WriteLine("Received data success");
                    return data;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw e;
                }
            }
            // ReadAsStreamAsync
            public async Task<Stream> DownloadDataStream(string url)
            {
                Console.WriteLine($"Starting connect {url}");
                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    var stream = await response.Content.ReadAsStreamAsync();
                    Console.WriteLine("Stream for read data OK");
                    return stream;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw e;
                }
            }
        }
// PHASE 2

// PHASE 3
        public class ExHttpClient01
        {
            HttpClient _httpClient = null;
            public HttpClient httpClient => _httpClient ?? (new HttpClient());
            public async Task<string> SendAsyncJson(string url, string json)
            {
                Console.WriteLine($"Starting connect {url}");
                try
                {
                    var request = new HttpRequestMessage(HttpMethod.Post, url);
                    HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                    request.Content = httpContent;
                    var response = await httpClient.SendAsync(request);
                    var rcontent = await response.Content.ReadAsStringAsync();
                    return rcontent;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw e;
                }
            }
        }
// PHASE 3
    }
}