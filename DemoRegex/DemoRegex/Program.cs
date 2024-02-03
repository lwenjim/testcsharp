using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DemoRegex
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string text = "<a>abc</a><a>123</a>";
            //string pat = @"<a>(.*?)<\/a>";

            //Regex r = new Regex(pat, RegexOptions.IgnoreCase);

            //Match m = r.Match(text);
            //int matchCount = 0;
            //while (m.Success)
            //{
            //    Console.WriteLine("Match" + (++matchCount));
            //    for (int i = 1; i <= 2; i++)
            //    {
            //        Group g = m.Groups[i];
            //        Console.WriteLine("Group" + i + "='" + g + "'");
            //        CaptureCollection cc = g.Captures;
            //        for (int j = 0; j < cc.Count; j++)
            //        {
            //            Capture c = cc[j];
            //            System.Console.WriteLine("Capture" + j + "='" + c + "', Position=" + c.Index);
            //        }
            //    }
            //    m = m.NextMatch();
            //}

            string input = "<span class=gbtb2></span><span id=gbgs5 class=gbts><span id=gbi5></span></span>";
            string pattern = @"<[^>]+>";
            string replacement = " ";
            string result = Regex.Replace(input, pattern, replacement);

            Console.WriteLine("Original String: {0}", input);
            Console.WriteLine("Replacement String: {0}", result);
        }
    }
}
