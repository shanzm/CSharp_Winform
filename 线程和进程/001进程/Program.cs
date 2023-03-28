using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace _001进程
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ////获取计算机所有进程
            //Process[] pros = Process.GetProcesses();
            //foreach (Process item in pros)
            //{
            //    Console.WriteLine(item);
            //}

            ////打开程序
            //Process.Start("notepad");//打开记事本程序
            //Process.Start("mspaint");//打开画图
            Process.Start("calc");//打开计算器
            //Process.Start("iexplore", "http://www.baidu.com");//打开ie浏览器，显示网页http://www.baidu.com
            //Process.Start("msedge", "http://www.baidu.com");//打开ie浏览器，显示网页http://www.baidu.com

            ////通过一个进程打开文件

            //Process pro = new Process();

            //ProcessStartInfo psi = new ProcessStartInfo(@"D:\Documents\收藏20150209-212620.html");
            //pro.StartInfo = psi;

            //pro.Start();

            Console.ReadKey();
        }
    }
}
