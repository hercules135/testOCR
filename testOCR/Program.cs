using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System.Runtime.InteropServices;

namespace testOCR
{
    public class Program
    {
        [DllImport("lib/FScan.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void InitPara();

        [DllImport("lib/FScan.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int FileOCR(string imgBase64,
            [MarshalAs(UnmanagedType.LPWStr)] string ASource,
            [MarshalAs(UnmanagedType.LPWStr)] string ADest, int ADestSize,
            double x1, double y1, double x2, double y2);
        public static void Main(string[] args)
        {
            InitPara();
            String imgBase64 = "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";
            string vDest = "";
            //0.1=图像宽度*0.1； 0=图像高度*0； 识别区域左上开始位置
            //0.5=图像宽度*0.5； 0=图像高度*1； 识别区域右下结束位置
            int ocr = FileOCR(imgBase64, "", vDest, 2048, 0.1, 0, 0.5, 1);
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
