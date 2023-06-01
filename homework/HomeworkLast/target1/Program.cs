using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace WebCrawler
{
    class Crawler
    {
        private ConcurrentDictionary<string, bool> urls = new ConcurrentDictionary<string, bool>();
        private int count = 0;
        private string currentUrl = "";
        private string targetDomain = "www.cnblogs.com";

        static async Task Main(string[] args)
        {
            DateTime startTime = DateTime.Now;

            Crawler myCrawler = new Crawler();
            string startUrl = "http://www.cnblogs.com/dstang2000/";
            if (args.Length >= 1) startUrl = args[0];
            myCrawler.urls.TryAdd(startUrl, false);
            await myCrawler.Crawl();

            DateTime endTime = DateTime.Now;
            TimeSpan elapsedTime = endTime - startTime;

            Console.WriteLine("开始时间: " + startTime);
            Console.WriteLine("结束时间: " + endTime);
            Console.WriteLine("总用时: " + elapsedTime);
        }

        private async Task Crawl()
        {
            Console.WriteLine("开始爬行了......");

            // 使用 CancellationTokenSource 控制任务取消
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;

            while (true)
            {
                // 获取未爬取的url
                var urlToCrawl = urls.FirstOrDefault(url => !url.Value);
                if (urlToCrawl.Key == null || count >= 10)
                    break;

                urls[urlToCrawl.Key] = true;
                Interlocked.Increment(ref count);

                Console.WriteLine("爬行" + urlToCrawl.Key + "页面！");

                // 并行处理
                await Task.Run(() => Parallel.ForEach(urls, new ParallelOptions { MaxDegreeOfParallelism = 4 }, async (url) =>
                {
                    if (!url.Value)
                    {
                        urls[url.Key] = true;
                        Interlocked.Increment(ref count);

                        Console.WriteLine("爬行" + url.Key + "页面！");

                        await Parse(url.Key);
                    }
                }));
            }
        }

        private async Task Parse(string url)
        {
            currentUrl = url;

            try
            {
                HttpClient httpClient = new HttpClient();
                HttpResponseMessage response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string html = await response.Content.ReadAsStringAsync();

                // 解析页面中的链接
                var links = GetLinks(html);
                foreach (var link in links)
                {
                    if (link.Contains(targetDomain) && !urls.ContainsKey(link))
                    {
                        urls.TryAdd(link, false);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                urls[currentUrl] = true;
                Interlocked.Decrement(ref count);
            }
        }

        private string[] GetLinks(string html)
        {
            string pattern = @"<a\s+(?:[^>]*?\s+)?href=""([^""]*)""";
            MatchCollection matches = Regex.Matches(html, pattern, RegexOptions.IgnoreCase);

            string[] links = new string[matches.Count];
            for (int i = 0; i < matches.Count; i++)
            {
                links[i] = matches[i].Groups[1].Value;
            }

            return links;
        }
    }
} 