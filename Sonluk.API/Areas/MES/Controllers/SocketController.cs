using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Web.Http;

namespace Sonluk.API.Areas.MES.Controllers
{
    public class SocketController : ApiController
    {
        [HttpGet]
        public string PushCommand()
        {
            TcpClient tcp = new TcpClient();
            NetworkStream streamToServer;           
            tcp.Connect("192.168.9.4", 2001);
            if (!tcp.Connected)
            {
                tcp.Close();
                return "tcp连接不通";
            }
            streamToServer = tcp.GetStream();
            byte[] buffer = new byte[] { (int)10 };
            try
            {

                lock (streamToServer)
                {
                    streamToServer.Write(buffer, 0, buffer.Length);     // 发往服务器
                }             
                //接收字符串
                buffer = new byte[10];
                //for (int i = 0; i < 5; i++)
                //{
                lock (streamToServer)
                {

                    int bytesRead = streamToServer.Read(buffer, 0, 10);
                    //streamToServer.
                    //listBox1.Items.Add(bytesRead);
                    StringBuilder content = new StringBuilder();
                    foreach (byte b in buffer)
                    {
                        content.AppendFormat(" {0:x2}", b);
                    }
                    
                    tcp.Close();
                    return content.ToString();
                }
            }
            catch (Exception error)
            {
                tcp.Close();
                return error.Message;
            }

        }
    }
}
