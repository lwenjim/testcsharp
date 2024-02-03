using System;
using System.CommandLine;
using System.Net.Http;
using System.Threading.Tasks;

namespace DemoCommandLine
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // CTRL + R + G 清除无用包导入
            var rootCommand = new RootCommand
            {
                new Argument<string>("url","web site url"),
                new Option<bool>(new string[]{ "--gethtml" ,"-html"},"Get html source"),
                new Option<bool>(new string[]{ "--getimage" ,"-image"},"Get images"),
                new Option<bool>(new string[]{ "--regex-option" ,"-regex"},"Use regex"),
                new Option<bool>(new string[]{ "--htmlagilitypack-option", "-agpack"},"Use HtmlAgilityPack"),
                new Option<bool>(new string[]{ "--anglesharp-option", "-agsharp"},"Use AngleSharp"),
                new Option<string>(new string[]{ "--download-path" ,"-path"},"Designate download path"),
            };
            var i = await rootCommand.InvokeAsync(args);
            if (i != 0)
            {
                return;
            }
            Console.WriteLine(String.Format("正在获取: {0} 的内容", args[0]));

            var uri = new Uri(args[0]);
            var httpClient = new HttpClient();
            try
            {
                var result = await httpClient.GetStringAsync(uri);
                httpClient.Dispose();
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                string msg = "Error " + ex.ToString();
                httpClient.Dispose();
                Console.WriteLine(msg);
            }
        }
    }
}
