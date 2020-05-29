using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JW.UHF;
using System.Threading;
namespace TcpDiscovery
{
    class Program
    {

        private static bool Searching = false;
        static void Main(string[] args)
        {
            
            //启动TCP跨网段搜索
            TcpDiscoveryFactory.StartAllDiscovery();

            Searching = true;

            Thread searchThread = new Thread(SearchDevice);
            searchThread.Start();

            Console.WriteLine("按压回车键停止扫描");
            Console.ReadLine();

            Searching = false;
            //禁用TCP跨网段搜索
            TcpDiscoveryFactory.StopAllDiscovery();

            Console.WriteLine("按压回车键退出程序");
            Console.ReadLine();
        }

        /// <summary>
        /// 搜索设备
        /// </summary>
        static void SearchDevice()
        {
            while (Searching)
            {
                Console.WriteLine("Searching Device...");
                List<TcpInfo> tcpInfos = TcpDiscoveryFactory.GetAllTcpDevices();
                foreach (TcpInfo tcpInfo in tcpInfos)
                {
                    Console.WriteLine(String.Format("MAC=[{0}],IP=[{1}]",tcpInfo.ModelMacAddress,tcpInfo.ModelIP));
                }
                Thread.Sleep(1000);
            }
        }
    }
}
