using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace target3
{
    internal class Program
    {
        public class Crawler
        {
            private Dictionary<string, bool> urls = new Dictionary<string, bool>();
            private int count = 0;
            private string currentUrl = "";

            static void Main(string[] args)
            {
                Crawler myCrawler = new Crawler();
                string startUrl = "http://www.cnblogs.com/dstang2000/";
                if (args.Length >= 1) startUrl = args[0];
                myCrawler.urls.Add(startUrl, false);
                //加入初始页面 
                myCrawler.Crawl().Wait();
                //开始爬行
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

            public async Task Parse(string url)
            {
                try
                {
                    WebClient webClient = new WebClient();
                    webClient.Encoding = Encoding.UTF8;
                    string html = await webClient.DownloadStringTaskAsync(url);

                    string fileName = count.ToString();
                    File.WriteAllText(fileName, html, Encoding.UTF8);

                    string strRef = @"(href|HREF)\s*=\s*[""'][^""'#>]+[""']";
                    MatchCollection matches = new Regex(strRef).Matches(html);

                    foreach (Match match in matches)
                    {
                        strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"', '\\', '#', ',', '>');

                        if (strRef.Length == 0)
                        {
                            continue;
                        }

                        // 将相对 URL 转换为绝对 URL
                        strRef = ToAbsoluteUrl(url, strRef);

                        // 检查链接是否是有效的页面 URL，只有有效的页面才添加到 urls
                        if (IsValidPageUrl(strRef) && !urls.ContainsKey(strRef))
                        {
                            urls.Add(strRef, false);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            //爬虫程序没有正确处理绝对 URL 和相对 URL,可以添加一个方法来将相对 URL 转换为绝对 URL
            public string ToAbsoluteUrl(string baseUrl, string relativeUrl)
            {
                if (string.IsNullOrEmpty(baseUrl) || string.IsNullOrEmpty(relativeUrl))
                    return relativeUrl;

                Uri baseUri = new Uri(baseUrl);
                Uri absoluteUri = new Uri(baseUri, relativeUrl);
                return absoluteUri.ToString();
            }

            private bool IsValidPageUrl(string url)
            {
                return url.EndsWith(".htm") || url.EndsWith(".html") || url.EndsWith(".aspx") || url.EndsWith(".php") || url.EndsWith(".jsp");
            }
        }
    }
}