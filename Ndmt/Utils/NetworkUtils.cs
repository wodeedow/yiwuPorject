using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Net.NetworkInformation;
using Ndmt.Model;

namespace Ndmt.Utils
{
    public class NetworkUtils
    {
        [DllImport("Iphlpapi.dll")]
        private static extern int SendARP(Int32 dest, Int32 host, ref Int64 mac, ref Int32 length);
        [DllImport("Ws2_32.dll")]
        private static extern Int32 inet_addr(string ip);

        public static IPAddress GetLocalIPAddress()
        {
            string strHostName = Dns.GetHostName();                 //得到本机的主机名
            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);    //取得本机IP
            foreach (IPAddress strAddr in ipEntry.AddressList)
            {
                if (strAddr.AddressFamily == AddressFamily.InterNetwork)
                    return strAddr;
            }
            return IPAddress.Parse("127.0.0.1");
        }

        private const string BIG_ENDIAN_PATTERN = @"(\w{2})(\w{2})(\w{2})(\w{2})(\w{2})(\w{2})";
        private static Regex PHY_ADDR_PARSER = new Regex(BIG_ENDIAN_PATTERN);
        private const string LITTLE_ENDIAN_FORMAT = @"{5}-{4}-{3}-{2}-{1}-{0}";

        /// <summary>
        /// 获得远程MAC地址
        /// </summary>
        /// <param name="localIP"></param>
        /// <param name="remoteIP"></param>
        /// <returns></returns>
        public static string GetRemoteMacAddress(string localIP, string remoteIP)
        {
            Int32 ldest = inet_addr(remoteIP);  //目的ip 
            Int32 lhost = inet_addr(localIP);   //本地ip 
            try
            {
                Int64 macinfo = new Int64();
                Int32 len = 6;
                int res = SendARP(ldest, 0, ref macinfo, ref len);
                string bigEndian = Convert.ToString(macinfo, 16);
                return ParseMacAddress(bigEndian);
            }
            catch (Exception err)
            {
                LogHelper.LogHere("GeneralException", err.Message);
            }
            return 0.ToString();
        }

        /// <summary>
        /// 从高字节序到低字节序
        /// </summary>
        /// <param name="bigEndian"></param>
        /// <returns></returns>
        private static string ParseMacAddress(string bigEndian)
        {
            MatchCollection matches = PHY_ADDR_PARSER.Matches(bigEndian);
            Match match = matches[0];
            return String.Format(LITTLE_ENDIAN_FORMAT, 
                match.Groups[1].Value,match.Groups[2].Value,
                match.Groups[3].Value,match.Groups[4].Value,
                match.Groups[5].Value,match.Groups[6].Value);
        }

        /// <summary>
        /// 获得与描述相符的网卡信息
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        public static NetworkInterface GetNicByDescription(string description)
        {
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface nic in interfaces)
            {
                if (nic.Description == description)
                    return nic;
            }
            return null;
        }

        /// <summary>
        /// 根据选定的网卡获得当前本地IP
        /// </summary>
        /// <param name="nic"></param>
        /// <returns></returns>
        public static IPAddress GetLocalIPAddressByNetworkInterface(NetworkInterface nic)
        {
            IPInterfaceProperties IPInterfaceProperties = nic.GetIPProperties();
            UnicastIPAddressInformationCollection uipic = IPInterfaceProperties.UnicastAddresses;
            foreach (UnicastIPAddressInformation uipi in uipic)
            {
                if (uipi.Address.AddressFamily == AddressFamily.InterNetwork)
                    return uipi.Address;
            }
            return IPAddress.None;
        }
    }
}
