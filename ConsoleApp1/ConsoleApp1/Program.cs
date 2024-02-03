using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace ConsoleApp1
{
    public class Account
    {
        public string Email { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public IList<string> Roles { get; set; }
    }
    internal class Program
    {
        static   async Task Main(string[] args)
        {
            //Account account = new Account
            //{
            //    Email = "james@example.com",
            //    Active = true,
            //    CreatedDate = new DateTime(2013, 1, 20, 0, 0, 0, DateTimeKind.Utc),
            //    Roles = new List<string>
            //    {
            //        "User",
            //        "Admin"
            //    }
            //};
            //string json = JsonConvert.SerializeObject(account, Formatting.Indented);
            //Console.WriteLine(json);


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
            var i =await rootCommand.InvokeAsync(args);
            if (i != 0)
            {
                return;
            }
            Console.WriteLine(String.Format("输入的地址为：{0}", args[0]));

            var uri = new Uri(args[0]);
            var httpClient = new HttpClient();
            try
            {
                var result = await httpClient.GetStringAsync(uri);
                httpClient.Dispose();
                Console.WriteLine(result);

            }catch (Exception ex)
            {
                string msg = "Error "+ex.ToString();
                httpClient.Dispose() ;
                Console.WriteLine(msg);
            }
        }
    }
}
