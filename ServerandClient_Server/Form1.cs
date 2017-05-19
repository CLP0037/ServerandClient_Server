using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Collections;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Diagnostics;
using System.Deployment.Application;

namespace ServerandClient_Server
{
    [StructLayout(LayoutKind.Sequential)]
    unsafe public struct TIMESTR
    {
        public UInt32 Year;
        public UInt32 Month;
        public UInt32 Date;
        public UInt32 Hour;
        public UInt32 Min;
        public UInt32 Second;
        public UInt32 Ms;
    }

    [StructLayout(LayoutKind.Sequential)]
    unsafe public struct FILEMENUSTR
    {
        public byte Oper_ID;
        public Int32 Menu_ID;//********long(c)=Int32(c#)
        public byte Menu_Len;
        public fixed byte Menu[4351];//
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4433)]
        //public byte[] Menu;
        public byte Call_Flag;
        public TIMESTR StartTime;
        public TIMESTR EndTime;
        public byte alignment;
    }

    [StructLayout(LayoutKind.Sequential)]
    unsafe public struct FILEREADSTR
    {
        public byte File_Oper_ID;
        public byte FileName_Len;
        public fixed byte FileName[4351];
        public fixed byte alignment[2];
    }

    [StructLayout(LayoutKind.Sequential)]
    unsafe public struct FILEOPERATE
    {
        public byte File_Oper;// 1- 召目录 2-召文件
        public FILEMENUSTR FileMenu;
        public FILEREADSTR FileRead;
        public fixed byte alignment[3];
    }


    [StructLayout(LayoutKind.Sequential)]
    unsafe public struct FILESTR
    {
        public Int32 FileMenuOper;
        public Int32 MenuID;
        public Int32 FileNum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        FILEBASICSTR[] File;
    }

    [StructLayout(LayoutKind.Sequential)]
    unsafe public struct FILEBASICSTR
    {
        public byte FileName_Len;
        public fixed byte FileName[4351];
        public byte File_Property;
        public Int32 FileSize;//********long(c)=Int32(c#)
        public TIMESTR Time;
        public fixed byte alignment[2];
    }

    [StructLayout(LayoutKind.Sequential)]
    unsafe public struct FILESTRUP
    {
        public UInt32 File_Oper;
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4433)]
        public FILESTR DevFileMenu;
        public fixed byte FilePath[4351];
    }

    unsafe public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;
            //关闭对文本框的非线程操作检查
            TextBox.CheckForIllegalCrossThreadCalls = false;
        }

        /*****************************参数定义**********************************/
        #region

        [StructLayout(LayoutKind.Sequential)]
        unsafe public struct Balance101VariousFlag
        {
            public fixed byte occupior[19760*2];
        }

        [StructLayout(LayoutKind.Sequential)]
        unsafe public struct _SOE
        {
            public UInt32 CurPot;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 336)]//*32
            public SOE__[] SOE_;
        }

        [StructLayout(LayoutKind.Sequential)]
        unsafe public struct SOE__
        {
            public UInt32 addr;

            public UInt32 Channel;// Handle...
            public byte State;
            public byte BL;

            public byte SB;
            public byte NT;
            public byte IV;
            public byte alignment;

            public UInt32 Year;
            public UInt32 Month;
            public UInt32 Date;
            public UInt32 Hour;
            public UInt32 Min;
            public UInt32 Second;
            public UInt32 Ms;
        }

        [StructLayout(LayoutKind.Sequential)]
        unsafe public struct _YX
        {
            public UInt32 Yx_Num;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)] //112*32
            public YXDATA[] Yx_Data;
        }

        [StructLayout(LayoutKind.Sequential)]
        unsafe public struct YXDATA
        {
            public UInt32 addr;
            public byte State;
            public byte BL;
            public byte SB;
            public byte NT;
            public byte IV;
            public UInt32 alignment_2;
            public byte alignment_1;
        }

        [StructLayout(LayoutKind.Sequential)]
        unsafe public struct _YC
        {
            public UInt32 Yc_Num;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]//*34
            public YCDATA[] Yc_Data;
        }

        [StructLayout(LayoutKind.Sequential)]
        unsafe public struct YCDATA
        {
            public UInt32 addr;
            public float Yc_Value;//32
            public byte OV;
            public byte BL;
            public byte SB;
            public byte NT;
            public byte IV;
        }

        [StructLayout(LayoutKind.Sequential)]
        unsafe public struct _YK
        {
            public UInt32 YkFlag;
            public UInt32 YkPot;
            public UInt32 YkState;
        }

        [StructLayout(LayoutKind.Sequential)]
        unsafe public struct S_CALL
        {
            public UInt32 CallFlag;
            public UInt32 CallPot;
            public UInt32 CallState;
        }

        [StructLayout(LayoutKind.Sequential)]
        unsafe public struct S_TIMESYN
        {
            public UInt32 TimeSynFlag;
	        public UInt32 TimeSynPot;
	        public UInt32 TimeSynState;
            //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
            //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 224)]
            public TIMESTR Time;//[]
        }

        #endregion
        /*****************************参数定义**********************************/

        /*****************************DLL_Import**********************************/
        #region
        //public const String path = @"D:\GitDownLoad\fes\lib\101protocol.dll";
        //[DllImport(path)]
        //初始化Flag标志位
        [DllImport(@"D:\GitDownLoad\fes\lib\101protocol.dll", CallingConvention = CallingConvention.Cdecl)]
        unsafe public static extern int win_init_RTEFlag_101(Balance101VariousFlag** rte);

        //登陆帧处理
        [DllImport(@"D:\GitDownLoad\fes\lib\101protocol.dll", CallingConvention = CallingConvention.Cdecl)]
        //unsafe public static extern int win_login_Proc_101(Balance101VariousFlag* rte,  [In , Out]byte[] buf, [In,Out]uint *len);//ref ref 
        unsafe public static extern int win_login_Proc_101(Balance101VariousFlag* rte, byte[] buf, ref int len);

        //断开连接
        [DllImport(@"D:\GitDownLoad\fes\lib\101protocol.dll", CallingConvention = CallingConvention.Cdecl)]
        unsafe public static extern void win_device_unregister_101(Balance101VariousFlag* rte);

        //总召
        [DllImport(@"D:\GitDownLoad\fes\lib\101protocol.dll", CallingConvention = CallingConvention.Cdecl)]
        unsafe public static extern int win_device_101act_call(Balance101VariousFlag* rte, byte[] buf, uint len);//ref byte[] [In , Out]

        //定时命令
        [DllImport(@"D:\GitDownLoad\fes\lib\101protocol.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        unsafe public static extern int win_device_101act_beat(Balance101VariousFlag* rte, byte[] buf, int size);//[In, Out]  [In, Out]

        //对时
        [DllImport(@"D:\GitDownLoad\fes\lib\101protocol.dll", CallingConvention = CallingConvention.Cdecl)]
        unsafe public static extern int win_device_101act_timesync(Balance101VariousFlag* rte, ref S_TIMESYN pTime, byte[] buf, int size);//ref 

        //遥控
        [DllImport(@"D:\GitDownLoad\fes\lib\101protocol.dll", CallingConvention = CallingConvention.Cdecl)]
        unsafe public static extern int win_device_101act_yk(Balance101VariousFlag* rte, ref _YK pYk, byte[] buf, int size);

        //召唤目录
        [DllImport(@"D:\GitDownLoad\fes\lib\101protocol.dll", CallingConvention = CallingConvention.Cdecl)]
        unsafe public static extern int win_device_101act_file(Balance101VariousFlag* rte, ref FILEOPERATE pOper, byte[] buf, int size);//ref 

        //打印Flag信息
        [DllImport(@"D:\GitDownLoad\fes\lib\101protocol.dll", CallingConvention = CallingConvention.Cdecl)]
        unsafe public static extern void win_print_flag(Balance101VariousFlag* rte, StringBuilder _sFlag);

        //解析101规约
        [DllImport(@"D:\GitDownLoad\fes\lib\101protocol.dll", CallingConvention = CallingConvention.Cdecl)]
        unsafe public static extern int win_device_parse_101(Balance101VariousFlag* rte, byte[] buf, int len);//ref   u

        //getSOE
        [DllImport(@"D:\GitDownLoad\fes\lib\101protocol.dll", CallingConvention = CallingConvention.Cdecl)]
        unsafe public static extern int getSOE(Balance101VariousFlag* rte, ref _SOE ptr);

        //getYX
        [DllImport(@"D:\GitDownLoad\fes\lib\101protocol.dll", CallingConvention = CallingConvention.Cdecl)]
        unsafe public static extern int getYX(Balance101VariousFlag* rte, ref _YX ptr);

        //getYC
        [DllImport(@"D:\GitDownLoad\fes\lib\101protocol.dll", CallingConvention = CallingConvention.Cdecl)]
        unsafe public static extern int getYC(Balance101VariousFlag* rte, ref _YC ptr);

        //getYK
        [DllImport(@"D:\GitDownLoad\fes\lib\101protocol.dll", CallingConvention = CallingConvention.Cdecl)]
        unsafe public static extern int getYK(Balance101VariousFlag* rte, ref _YK ptr);

        //getCALL
        [DllImport(@"D:\GitDownLoad\fes\lib\101protocol.dll", CallingConvention = CallingConvention.Cdecl)]
        unsafe public static extern int getCALL(Balance101VariousFlag* rte, ref S_CALL ptr);

        //getFILEMENU
        [DllImport(@"D:\GitDownLoad\fes\lib\101protocol.dll", CallingConvention = CallingConvention.Cdecl)]
        //unsafe public static extern int getFILEMENU(Balance101VariousFlag* rte, ref FILESTR menu);//ref 
        unsafe public static extern int getFILEMENU(Balance101VariousFlag* rte, IntPtr menu);

        //getFILE
        [DllImport(@"D:\GitDownLoad\fes\lib\101protocol.dll", CallingConvention = CallingConvention.Cdecl)]
        //unsafe public static extern int getFILE(Balance101VariousFlag* rte, ref FILESTRUP file);
        unsafe public static extern int getFILE(Balance101VariousFlag* rte, IntPtr file);

        #endregion
        /*****************************DLL_Import**********************************/

        /*****************************参数初始化赋值**********************************/
        #region
        int if_log = 0;//设备登录上线标志
        Balance101VariousFlag* flag = null;
        StringBuilder sFlag = new StringBuilder("");

        _YX ptr_YX;//
        YXDATA* pYxData = null;

        _YC ptr_YC;
        YCDATA* pYcData = null;

        _SOE ptr_SOE;
        SOE__* pSOE = null;

        _YK ptr_YK;//

        S_CALL ptr_CALL;//

        //FILEOPERATE pOper = new FILEOPERATE();

        FILEMENUSTR* FileMenu = null;
        //FileMenu* Menu;
        TIMESTR* StartTime = null;
        TIMESTR* EndTime = null;

        FILEREADSTR* FileRead = null;

        FILESTRUP file=new FILESTRUP();

        FILESTR DevFileMenu=new FILESTR();
        FILEBASICSTR* File = null;


        S_TIMESYN pTime;//=new S_TIMESYN()
        TIMESTR *Time=null;

        string RemoteEndPoint;     //客户端的网络结点
        Thread threadwatch = null;//负责监听客户端的线程
        Socket socketwatch = null;//负责监听客户端的套接字
        //创建一个和客户端通信的套接字
        Dictionary<string, Socket> dic = new Dictionary<string, Socket> { };   //定义一个集合，存储客户端信息

        ArrayList listenList = new ArrayList();
        //ArrayList WriteList = new ArrayList();
        Thread threadsend = null;//
        //string sendMsg = "";

        string selectClient = "";
        
        
        #endregion
        /*****************************参数初始化赋值**********************************/

        unsafe private void button1_Click(object sender, EventArgs e)//启动服务
        {

            this.button1.Enabled = false;
            //定义一个套接字用于监听客户端发来的消息，包含三个参数（IP4寻址协议，流式连接，Tcp协议）
            socketwatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //服务端发送信息需要一个IP地址和端口号
            IPAddress address = IPAddress.Parse(textBox_IP.Text.Trim());//获取文本框输入的IP地址

            //将IP地址和端口号绑定到网络节点point上
            IPEndPoint point = new IPEndPoint(address, int.Parse(textBox_Port.Text.Trim()));//获取文本框上输入的端口号
            //此端口专门用来监听的

            //监听绑定的网络节点
            socketwatch.Bind(point);

            //将套接字的监听队列长度限制为20
            socketwatch.Listen(20);

            //创建一个监听线程
            threadwatch = new Thread(watchconnecting);
            //将窗体线程设置为与后台同步，随着主线程结束而结束
            threadwatch.IsBackground = true;
            //启动线程   
            threadwatch.Start();
            //启动线程后 textBox3文本框显示相应提示
            textBox3.AppendText("开始监听客户端传来的信息!" + "\r\n");

            
        }

        void OnlineList_Disp(string Info)
        {
            listBoxOnlineList.Items.Add(Info);   //在线列表中显示连接的客户端套接字
        }

        //监听客户端发来的请求
        private void watchconnecting()
        {
            Socket connection = null;
            
            while (true)  //持续不断监听客户端发来的请求   
            {
                try
                {
                    //Socket.Select(listenList, null, null, 1000);//1s定时
                    connection = socketwatch.Accept();
                }
                catch (Exception ex)
                {
                    textBox3.AppendText(ex.Message); //提示套接字监听异常   
                    break;
                }
                //获取客户端的IP和端口号
                IPAddress clientIP = (connection.RemoteEndPoint as IPEndPoint).Address;
                int clientPort = (connection.RemoteEndPoint as IPEndPoint).Port;

                //显示"连接成功的"的信息       让客户
                string sendmsg = "连接服务端成功！\r\n" + "本地IP:" + clientIP + "，本地端口" + clientPort.ToString();
                //byte[] arrSendMsg = Encoding.UTF8.GetBytes(sendmsg);
                //connection.Send(arrSendMsg);
                textBox3.AppendText(sendmsg);

                RemoteEndPoint = connection.RemoteEndPoint.ToString(); //客户端网络结点号
                textBox3.AppendText("成功与" + RemoteEndPoint + "客户端建立连接！\t\n");     //显示与客户端连接情况
                dic.Add(RemoteEndPoint, connection);    //添加客户端信息

                OnlineList_Disp(RemoteEndPoint);    //显示在线客户端


                //IPEndPoint netpoint = new IPEndPoint(clientIP,clientPort);

                IPEndPoint netpoint = connection.RemoteEndPoint as IPEndPoint;

                //创建一个通信线程    
                ParameterizedThreadStart pts = new ParameterizedThreadStart(recv);
                Thread thread = new Thread(pts);
                thread.IsBackground = true;//设置为后台线程，随着主线程退出而退出   
                //启动线程   
                thread.Start(connection);

            }
        }

        ///   
        /// 接收客户端发来的信息    
        ///   
        ///客户端套接字对象  
        unsafe private void recv(object socketclientpara)
        {

            Socket socketServer = socketclientpara as Socket;
            
            socketServer.Blocking = false;
            while (true)
            {
                listenList.Add(socketServer);

                int n = listenList.Count;


                 byte[] buf = new byte[128];
                int l = 0;

                //创建一个内存缓冲区 其大小为1024*1024字节  即1M   
                byte[] arrServerRecMsg = new byte[1024 * 1024];
                //将接收到的信息存入到内存缓冲区,并返回其字节数组的长度  
                try
                {
                    ////listenList
                    try
                    {
                        Socket.Select(listenList, null, null, 1000 * 1000);//1s定时
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e);
                    }
                    //Socket.Select(listenList, null, null, 1000 * 1000);//1s定时
                    if (listenList.Count == 0)//没有可收的东西
                    {

                        //textBox1.AppendText();DateTime.Now.ToString() + "win_device_101act_beat调用异常" + "\r\n"
                        //BeginInvoke(new Action(() =>
                        //{
                        //    win_print_flag(flag, sFlag);
                        //    textBox1.AppendText(sFlag.ToString());
                        //    textBox1.AppendText(DateTime.Now.ToString() + "Socket.Select调用" + "\r\n");
                        //    Console.WriteLine(DateTime.Now.ToString() + "Socket.Select调用" + "\r\n");
                        //}));
                        //win_print_flag(flag, sFlag);
                        Console.WriteLine(DateTime.Now.ToString() + "Socket.Select调用" + "\r\n");

                        Ordersend(10);
                    }
                    else
                    {
                        int length = socketServer.Receive(arrServerRecMsg);

                        //将机器接受到的字节数组转换为人可以读懂的字符串   
                        //string strSRecMsg = Encoding.UTF8.GetString(arrServerRecMsg, 0, length);
                        string strSRecMsg = byteToHexStr(arrServerRecMsg, length);

                        //将发送的字符串信息附加到文本框txtMsg上   
                        textBox3.AppendText("客户端:" + socketServer.RemoteEndPoint + ",time:" + GetCurrentTime() + "\r\n" + strSRecMsg + "\r\n\n");

                        for (int i = 0; i < 128; i++)
                        {
                            if (arrServerRecMsg[i] != 0)
                            {
                                //(char) (((b[0] & 0xFF) << 8) | (b[1] & 0xFF));
                                buf[i] = arrServerRecMsg[i];//
                            }
                        }
                        l = length;


                        if (if_log == 0)//未登录
                        {
                            //Balance101VariousFlag* flag = null;
                            //int ret = win_init_RTEFlag_101(&flag);
                            //Console.WriteLine("win_init_RTEFlag_101 return " + ret);
                            int ret1 = win_login_Proc_101(flag, buf, ref l);//buf

                            Console.WriteLine(ret1);
                            if (ret1 == 0)//收到登录帧，设备上线，主站启动链路
                            {
                                if_log = 1;

                                //启动链路？？？
                                
                            }
                        }
                        else//登录上线后收到的内容
                        {
                            int data_type = win_device_parse_101(flag, buf, l);

                            //返回值类型
                            #region
                            //#define YX_TYPE         0x01 
                            //#define YC_TYPE         0x02 
                            //#define SOE_TYPE        0x04
                            //#define TIMESYNC_TYPE   0x08 
                            //#define CALL_TYPE       0x10
                            //#define FILEMENU_TYPE   0x20
                            //#define FILE_TYPE       0x40
                            //#define YK_TYPE         0x80
                            #endregion

                            if ((data_type & 0x01) == 0x01)//YX
                            {
                                #region
                                getYX(flag, ref ptr_YX);
                                uint yxnum = ptr_YX.Yx_Num;
                                uint[,] YXChange = new uint[2, yxnum];
                                for (int j = 0; j < yxnum; j++)
                                {
                                    YXChange[0, j] = ptr_YX.Yx_Data[j].addr;
                                    YXChange[1, j] = ptr_YX.Yx_Data[j].State;
                                }
                                int end = 0;
                                #endregion
                            }
                            else if ((data_type & 0x02) == 0x02)//YC
                            {
                                #region
                                getYC(flag, ref ptr_YC);

                                uint ycnum = ptr_YC.Yc_Num;
                                uint[,] YCChange = new uint[2, ycnum];
                                for (int j = 0; j < ycnum; j++)
                                {
                                    YCChange[0, j] = ptr_YC.Yc_Data[j].addr;
                                    YCChange[1, j] = (uint)ptr_YC.Yc_Data[j].Yc_Value;
                                }
                                int end = 0;
                                #endregion
                            }
                            else if ((data_type & 0x04) == 0x04)//SOE
                            {
                                #region
                                getSOE(flag, ref ptr_SOE);
                                uint curpot = ptr_SOE.CurPot;
                                #endregion
                            }
                            else if ((data_type & 0x08) == 0x08)//Time
                            {
                                #region


                                int aa = 8;
                                #endregion
                            }
                            else if ((data_type & 0x10) == 0x10)//CALL
                            {
                                #region
                                //getCALL(Balance101VariousFlag* rte, S_CALL* ptr);
                                getCALL(flag, ref ptr_CALL);
                                int aa = 8;
                                #endregion
                            }
                            else if ((data_type & 0x20) == 0x20)//Menu
                            {
                                #region
                                //getFILEMENU(Balance101VariousFlag* rte, FILESTR* menu);
                                //getFILEMENU(flag, ref DevFileMenu);

                                IntPtr ptr = IntPtr.Zero;
                                int size = Marshal.SizeOf(typeof(FILESTR));//CHCNetSDK.NET_DVR_SADPINFO_LIST
                                ptr = Marshal.AllocHGlobal(size); // 为指针分配空间    
                                getFILEMENU(flag, ptr);
                                // 强制转化成原类型    
                                DevFileMenu = (FILESTR)Marshal.PtrToStructure(ptr, typeof(FILESTR));

                                int aa = DevFileMenu.FileMenuOper;
                                int bb = DevFileMenu.FileNum;
                                int cc = DevFileMenu.MenuID;

                                #endregion
                            }
                            else if ((data_type & 0x40) == 0x40)//File
                            {
                                #region
                                //getFILE(Balance101VariousFlag* rte, FILESTRUP* file);
                                //getFILE(flag,ref file);

                                IntPtr ptr1 = IntPtr.Zero;
                                int size1 = Marshal.SizeOf(typeof(FILESTRUP));//CHCNetSDK.NET_DVR_SADPINFO_LIST
                                ptr1 = Marshal.AllocHGlobal(size1); // 为指针分配空间    
                                getFILE(flag, ptr1);
                                // 强制转化成原类型    
                                file = (FILESTRUP)Marshal.PtrToStructure(ptr1, typeof(FILESTRUP));

                                int aa1 = file.DevFileMenu.FileMenuOper;
                                int bb1 = file.DevFileMenu.FileNum;
                                int cc1 = file.DevFileMenu.MenuID;

                            
                                #endregion
                            }
                            else if ((data_type & 0x80) == 0x80)//YK
                            {
                                #region //getYK(Balance101VariousFlag* rte, ref _YK ptr);
                                getYK(flag, ref ptr_YK);

                                uint reYkFlag = ptr_YK.YkFlag;
                                uint reYkPot = ptr_YK.YkPot;
                                uint reYkState = ptr_YK.YkState;
            //                  
                                int aa = 8;
                                #endregion
                            }
                            else
                            {
                                int reply = 0;
                                //初始化链路短帧解包并回复

                                //总召确认帧回复
                                //总召结束回复
                            }


                        }
                        //int ret2 = win_device_101act_beat(flag, buf, ref l);
                        //int nnn = ret2;
                        //Ordersend(10);
                        //break;

                    }


                    //Ordersend(10);
                    int aaa = 1;
                
                }
                catch (Exception ex)
                {
                    textBox3.AppendText("客户端" + socketServer.RemoteEndPoint + "已经中断连接" + "\r\n"); //提示套接字监听异常 
                    listBoxOnlineList.Items.Remove(socketServer.RemoteEndPoint.ToString());//从listbox中移除断开连接的客户端
                    socketServer.Close();//关闭之前accept出来的和客户端进行通信的套接字

                    if_log = 0;
                    listenList.Clear();
                    break;
                }
            }
        }

        /// <summary>
        /// 字节数组转16进制字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string byteToHexStr(byte[] bytes,int len)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < len; i++)//bytes.Length
                {
                    returnStr += bytes[i].ToString("X2");
                    returnStr += " ";
                }
            }
            return returnStr;
        }

        ///    
        /// 获取当前系统时间的方法   
        ///    
        /// 当前时间   
        private DateTime GetCurrentTime()
        {
            DateTime currentTime = new DateTime();
            currentTime = DateTime.Now;
            return currentTime;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sendMsg = textBox4.Text.Trim();  //要发送的信息
            //byte[] bytes = System.Text.Encoding.UTF8.GetBytes(sendMsg);   //将要发送的信息转化为字节数组，因为Socket发送数据时是以字节的形式发送的

            byte[] bytes = strToToHexByte(sendMsg);

            if (listBoxOnlineList.SelectedIndex == -1)
            {
                MessageBox.Show("请选择要发送的客户端！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                string selectClient = listBoxOnlineList.Text;  //选择要发送的客户端
                dic[selectClient].Send(bytes);   //发送数据
                textBox4.Clear();
                //textBox4.AppendText(label4.Text + GetCurrentTime() + "\r\n" + sendMsg + "\r\n");
                textBox4.AppendText(sendMsg);
            }
        }

        /// <summary>
        /// 字符串转16进制字节数组
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        private static byte[] strToToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//如果用户按下了Enter键  
            {
                string sendMsg = textBox4.Text.Trim();  //要发送的信息
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(sendMsg);
                if (listBoxOnlineList.SelectedIndex == -1)
                {
                    MessageBox.Show("请选择要发送的客户端！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    string selectClient = listBoxOnlineList.Text;  //选择要发送的客户端
                    dic[selectClient].Send(bytes);   //发送数据
                    textBox4.Clear();
                    textBox1.AppendText("服务器：" + GetCurrentTime() + "\r\n" + sendMsg + "\r\n");//label4.Text
                    textBox4.AppendText(sendMsg);
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("是否退出？选否,最小化到托盘", "操作提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Dispose();
            }
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = true;
                this.WindowState = FormWindowState.Minimized;
                this.Visible = false;
                this.notifyIcon1.Visible = true;
                this.ShowInTaskbar = false;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            base.Visible = true;
            this.notifyIcon1.Visible = false;
            this.ShowInTaskbar = true;
            //base.Show();
            base.WindowState = FormWindowState.Normal;
        }

        unsafe private void Form1_Load(object sender, EventArgs e)
        {
            //flag初始化
            Console.WriteLine("hello 101protocol!");
            //Balance101VariousFlag* flag = null;
            int ret = 0;
            //赋初值
            Balance101VariousFlag* f;// = flag;
            ret = win_init_RTEFlag_101(&f);//&
            flag = f;
            Console.WriteLine("win_init_RTEFlag_101 return " + ret);
            win_print_flag(flag, sFlag);

            textBox1.AppendText(sFlag.ToString());//"flag"(string)(flag)    Convert.ToString(flag)
        }

        private void btn_call_Click(object sender, EventArgs e)//总召
        {
            Ordersend(1);
        }

        private void btn_time_Click(object sender, EventArgs e)//对时
        {
            Ordersend(2);
        }

        private void btn_menu_Click(object sender, EventArgs e)//召目录
        {
            Ordersend(3);
        }

        private void btn_file_Click(object sender, EventArgs e)//召文件
        {
            Ordersend(4);
        }


        unsafe public void Ordersend(int ordertype)
        {
            byte[] bytes = new byte[256];
            uint len = 256;//
            int size = 256;
            


            if (listBoxOnlineList.SelectedIndex == -1)
            {
                if (ordertype != 10)
                {
                    MessageBox.Show("请选择要发送的客户端！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                else
                {
                    if (ordertype == 10)
                    {
                        int n = listBoxOnlineList.Items.Count;
                        selectClient = listBoxOnlineList.Items[n - 1].ToString();////最后一次连接的客户端
                    }
                    //return;
                }
            }
            //else
            {
                try
                {
                    if (ordertype != 10)
                        selectClient = listBoxOnlineList.Text;  //选择要发送的客户端



                    int ret = 0;

                    switch (ordertype)
                    {
                        case 1://总召
                            #region
                            ret = win_device_101act_call(flag, bytes, len);
                            #endregion
                            break;

                        case 2://对时
                            #region
                            //ret = win_device_101act_call(flag, bytes, ref len);
                            //win_device_101act_timesync(Balance101VariousFlag* rte, ref S_TIMESYN pTime, byte[] buf, ref int size)
                            //时间赋值
                            pTime.Time.Year = (UInt32)(DateTime.Now.Year);//-2000
                            //pTime.Time.Year = 0;
                            pTime.Time.Month = (UInt32)DateTime.Now.Month;
                            pTime.Time.Date = (UInt32)DateTime.Now.Day;
                            pTime.Time.Hour = (UInt32)DateTime.Now.Hour;
                            pTime.Time.Min = (UInt32)DateTime.Now.Minute;
                            pTime.Time.Second = (UInt32)DateTime.Now.Second;
                            pTime.Time.Ms = (UInt32)DateTime.Now.Millisecond;

                            ret = win_device_101act_timesync(flag, ref pTime, bytes, size);//ref 
                            int aaa = 1;
                            #endregion
                            break;


                        case 3://召目录
                        case 4://召文件
                            #region  //win_device_101act_file(Balance101VariousFlag* rte, ref FILEOPERATE pOper, byte[] buf, int size)
                            //pOper.FileMenu.Call_Flag = 0;

                            FILEOPERATE pOper = new FILEOPERATE();

                            if (ordertype == 3)
                            {
                                #region
                                pOper.File_Oper = 1;
                                //public byte  Oper_ID;
                                //public long Menu_ID;
                                //public byte  Menu_Len;
                                //public fixed byte Menu[4351];
                                //public byte  Call_Flag;
                                //public TIMESTR StartTime;
                                //public TIMESTR EndTime;
                                //public byte alignment;
                                //pOper.FileMenu.Menu[0] = 51;
                                pOper.FileMenu.Oper_ID = 1;//操作标识：1-读目录
                                pOper.FileMenu.Menu_ID = 3;//目录ID
                                pOper.FileMenu.Menu_Len = 1;//目录名长度
                                pOper.FileMenu.Call_Flag = 0;//召唤标志：0-目录下所有文件；1-目录下满足搜索时间段的文件
                                pOper.FileMenu.StartTime.Year = (UInt32)DateTime.Now.Year;
                                pOper.FileMenu.StartTime.Month = (UInt32)DateTime.Now.Month;
                                pOper.FileMenu.StartTime.Date = (UInt32)DateTime.Now.Day;
                                pOper.FileMenu.StartTime.Hour = (UInt32)DateTime.Now.Hour;
                                pOper.FileMenu.StartTime.Min = (UInt32)DateTime.Now.Minute;
                                pOper.FileMenu.StartTime.Second = (UInt32)DateTime.Now.Second;
                                pOper.FileMenu.StartTime.Ms = (UInt32)DateTime.Now.Millisecond;
                                pOper.FileMenu.EndTime = pOper.FileMenu.StartTime;
                                string source = "3";
                                byte[] VerByte = System.Text.Encoding.ASCII.GetBytes(source);
                                
                                for (int i = 0; i < source.Length; i++)
                                {
                                    pOper.FileMenu.Menu[i] = VerByte[i];//
                                }
                                //int length = 4351;//Marshal.Copy();



                                //pOper.FileMenu.Call_Flag = 1;
                                #endregion
                            }
                            else if (ordertype == 4)
                            {
                                #region

                                pOper.File_Oper = 2;
                                //public byte File_Oper_ID;
                                // public byte FileName_Len;
                                // public fixed byte FileName[4351];
                                // public fixed byte alignment[2];
                                //pOper.FileRead.FileName[0] = 0;
                                //int length = 4351;
                                //Marshal.Copy();
                                pOper.FileRead.File_Oper_ID = 3;//操作标识：3-读文件激活
                                pOper.FileRead.FileName_Len = 29;//文件长度：29
                                string file_cfg = "BAY01_20170222_151530_351.cfg";//BAY01_20161109_133857_111.cfg
                                byte[] VerByte = System.Text.Encoding.ASCII.GetBytes(file_cfg);
                                for (int i = 0; i < file_cfg.Length; i++)
                                {
                                    pOper.FileRead.FileName[i] = VerByte[i];//
                                }

                                pOper.FileRead.alignment[0] = 0;

                                #endregion
                            }
                            
                            ret = win_device_101act_file(flag, ref pOper, bytes, size);//ref 
                            #endregion
                            //break;

                        
                            
                            break;

                        case 5://遥控选择
                            #region
                            //win_device_101act_yk(Balance101VariousFlag* rte, ref _YK pYk, byte[] buf, ref int size)
                            //ptr_YK.YkFlag;
                            ptr_YK.YkPot=0;//0x6001
                            ptr_YK.YkState=0;
                            ret = win_device_101act_yk(flag, ref ptr_YK,bytes, size);
                            #endregion
                            break;

                        case 6://遥控执行
                            #region
                            //ptr_YK.YkFlag;
                            ptr_YK.YkPot = 0;//0x6001
                            ptr_YK.YkState = 2;
                            ret = win_device_101act_yk(flag, ref ptr_YK, bytes, size);
                            #endregion
                            break;

                        case 7://遥控取消
                            #region
                            //ptr_YK.YkFlag;
                            ptr_YK.YkPot = 0;//0x6001
                            ptr_YK.YkState = 4;
                            ret = win_device_101act_yk(flag, ref ptr_YK, bytes, size);
                            #endregion
                            break;

                        case 10://定时触发式命令
                            #region
                            //win_device_101act_beat(Balance101VariousFlag *rte,byte[]buf, ref int size)
                            try
                            {
                                ret = win_device_101act_beat(flag, bytes, size);//
                                
                            }
                            catch
                            {
                                textBox1.AppendText(DateTime.Now.ToString() + "win_device_101act_beat调用异常" + "\r\n");
                            }
                            int aa = 1;
                            #endregion
                            break;
                    }

                    if (ret > 0)
                    {
                        string sendMsg = "";
                        byte[] sendbytes = null;
                        int sendlen = 0;
                        if (ret == 5 || ret == 6)
                        {
                            sendlen = ret;
                            sendbytes = new byte[ret];
                            for (int i = 0; i < ret; i++)
                            {
                                sendbytes[i] = bytes[i];
                            }

                        }
                        else if (ret > 6)//ret为返回报文长度
                        {
                            sendlen = bytes[1] + 6;
                            sendbytes = new byte[sendlen];
                            for (int i = 0; i < sendlen; i++)
                            {
                                sendbytes[i] = bytes[i];
                            }

                            //调试===接收文件最后一帧后确认
                            if (ret == 28)
                            {
                                int fileend = 0;
                            }


                        }
                        sendMsg = byteToHexStr(sendbytes, sendlen);
                        dic[selectClient].Send(sendbytes);   //发送数据

                        textBox4.Clear();
                        textBox1.AppendText("服务器：" + GetCurrentTime() + "\r\n" + sendMsg + "\r\n");//
                        textBox4.AppendText(sendMsg);
                    }

                }
                catch (Exception ee)
                {
                    int aa = 0;
                }

            }
            
            //else
            
            //////BeginInvoke(new Action(() =>
            //////{
                
            //////}));


            
        }

        private void btn_select_Click(object sender, EventArgs e)//遥控选择
        {
            Ordersend(5);
        }

        private void btn_excute_Click(object sender, EventArgs e)//遥控执行
        {
            Ordersend(6);
        }

        private void btn_cancel_Click(object sender, EventArgs e)//遥控取消
        {
            Ordersend(7);
        }







    }
}
