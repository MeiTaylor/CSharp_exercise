

using System;
using static System.Net.WebRequestMethods;
using System.Collections;



using System.Collections.Generic;

using System.Text;

using System.IO;

using System.Net;

using System.Collections;

using System.Text.RegularExpressions;

using System.Threading;



namespace target2
{
    internal class Program
    {


        public class Crawler

        {


            private Hashtable urls = new Hashtable();

            private int count = 0;
            private string currentUrl = "";


            static void Main(string[] args)

            {
                Crawler myCrawler = new Crawler();

                string startUrl = "http://www.cnblogs.com/dstang2000/";

                if (args.Length >= 1) startUrl = args[0];

                myCrawler.urls.Add(startUrl, false);
                //加入初始页面 
                new Thread(myCrawler.Crawl).Start();
                //开始爬行
            }

            private void Crawl()
            {
                Console.WriteLine("开始爬行了......");
                while (true)
                {
                    string current = null;
                    foreach (string url in urls.Keys)
                    {
                        if ((bool)urls[url]) continue;
                        current = url;
                    }
                    if (current == null || count > 10)
                    {
                        break;
                    }
                    Console.WriteLine("爬行" + current + "页面！");

                    string html = DownLoad(current);

                    urls[current] = true;
                    count++;

                    currentUrl = current; // 添加这一行
                    Parse(html);
                }
            }


            public string DownLoad(string url)
            {
                try
                {
                    WebClient webClient = new WebClient();
                    webClient.Encoding = Encoding.UTF8;
                    string html = webClient.DownloadString(url);

                    string fileName = count.ToString();
                    System.IO.File.WriteAllText(fileName, html, Encoding.UTF8);
                    return html;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return " ";
                }
            }

            public void Parse(string html)
            {
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
                    strRef = ToAbsoluteUrl(currentUrl, strRef);

                    // 检查链接是否是有效的页面 URL，只有有效的页面才添加到 urls
                    if (IsValidPageUrl(strRef) && urls[strRef] == null)
                    {
                        urls[strRef] = false;
                    }
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