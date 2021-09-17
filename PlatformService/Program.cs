using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace PlatformService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new Test().Split();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
    public class Test
    {
        public void Split()
        {
            var str = "{1:F01AINBEGC0XXXX          }{2:I202BCDEEGC0XXXXN}{3:{103:PEG}{108:sami}}{4::20:test/SAMI:21:TEST:32A:040124USD1,00:58A:BCDEEGCAXXX-}";
            var requiredStr = GetSubString(str);
            if(requiredStr.Length > 0)
            {
                var stringArr = requiredStr.ToString().ToArray();

                //IDictionary<string, string> valueMap = new Dictionary<string, string>();
                //int key = 0;
                //while(key< stringArr.Length)
                //{
                //    valueMap[stringArr[key]] = stringArr[key + 1];
                //    key += 2;
                //}
                //var result = valueMap;
            }
        }
        public ReadOnlySpan<char> GetSubString(ReadOnlySpan<char> str)
        {
            var index = str.LastIndexOf("4::");
            var requiredString = str.Slice(index + 3);
            var slice = requiredString.Slice(0, requiredString.Length - 2);
            return index == -1 ? ReadOnlySpan<char>.Empty : str.Slice(index + 3);
        }
    }
}
