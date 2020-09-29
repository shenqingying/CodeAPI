using Sonluk.DAFactory;
using Sonluk.Entities.EM;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.EM;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.EM
{
    public class FILE_PATH
    {
        private static readonly IFILE_PATH _DataAccess = RMSDataAccess.CreateEMFILE_PATH();
        private static readonly ISY_MANUAL _SY_MANUADataAccess = RMSDataAccess.CreateEMSY_MANUAL();
        private static readonly ISY_MANUALBB _SY_MANUALBBDataAccess = RMSDataAccess.CreateEMSY_MANUALBB();
        private static readonly ISY_MANUALPATH _SY_MANUALPATHDataAccess = RMSDataAccess.CreateEMSY_MANUALPATH();
        public MES_RETURN UploadService(string type, byte[] fileData, string fileName, string[] directorys)
        {
            MES_RETURN mr = new MES_RETURN();
            EM_FILE_PATH node = _DataAccess.Read(type);
            string filepath = node.PATH;
            string role = node.ROLE;
            string cflj = directorys[0];
            for (int i = 0; i < directorys.Length; i++)
            {
                //判断文件夹是否存在
                filepath = filepath + "\\" + directorys[i];//filepath路径加文件夹路径了
                if (i != 0)
                {
                    cflj += "\\" + directorys[i];
                }
                if (Directory.Exists(filepath))
                {
                    //fileName = filepath + "\\" + fileName;
                }
                else
                {
                    Directory.CreateDirectory(filepath);
                }                
            }
            switch (type)
            {
                case "包装作业指导书":
                    switch (role)
                    {
                        case "时间戳":
                            DirectoryInfo root = new DirectoryInfo(filepath);
                            FileInfo[] files = root.GetFiles();

                            fileName = DateTimeToStamp(System.DateTime.Now).ToString() + "-" + (files.Length + 1)  + '.' + fileName.Split('.').Last();
                            
                            break;
                        default:
                            break;
                    }

                    try
                    {
                        string createPath = filepath + "\\" + fileName;
                        cflj = cflj + "\\" + fileName;
                        Bytes2File(fileData, createPath);
                        mr.TYPE = "S";
                        mr.MESSAGE = cflj;
                    }
                    catch (Exception e)
                    {
                        
                        throw e;
                    }
                   
                    break;
                case "设备操作规程指导书":
                    switch (role)
                    {
                        case "时间戳":
                            DirectoryInfo root = new DirectoryInfo(filepath);
                            FileInfo[] files = root.GetFiles();

                            fileName = DateTimeToStamp(System.DateTime.Now).ToString() + "-" + (files.Length + 1) + '.' + fileName.Split('.').Last();

                            break;
                        default:
                            break;
                    }

                    try
                    {
                        string createPath = filepath + "\\" + fileName;
                        cflj = cflj + "\\" + fileName;
                        Bytes2File(fileData, createPath);
                        mr.TYPE = "S";
                        mr.MESSAGE = cflj;
                    }
                    catch (Exception e)
                    {

                        throw e;
                    }

                    break;
                

                default:
                    break;
            }
            
           


            return mr;
        }
        public MES_RETURN DeleteFileService(string[] filename)
        {
            MES_RETURN mr = new MES_RETURN();
            try
            {
                for (int i = 0; i < filename.Length; i++)
                {
                    //if (File.Exists(filename[i]))
                    //{
                    File.Delete(filename[i]);//可以不判断  是否没有存在文件也不引发异常信息
                    //}
                }
                mr.TYPE = "S";
                mr.MESSAGE = "删除成功";
            }
            catch (Exception e)
            {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
            }
            return mr;
           
        }
        public EM_FILE_PATH Read(string type)
        {
            return _DataAccess.Read(type);
        }
        public EM_FILE_PATH ReadByID(int pathid)
        {
            return _DataAccess.ReadByID(pathid);
        }
        
        public MES_RETURN GetURLByReadID(int SY_MANUALPATHID)
        {
            MES_RETURN rst = new MES_RETURN();
            EM_SY_MANUALPATH pathModel = new EM_SY_MANUALPATH();
            pathModel.ID = SY_MANUALPATHID;
            List<EM_SY_MANUALPATH> pathnodes = _SY_MANUALPATHDataAccess.Read(pathModel).ToList();
            if (pathnodes.Count != 1)
            {
                rst.TYPE = "E";
                rst.MESSAGE = "查询电子说明书路径异常，请联系管理员";
                return rst;
            }
            EM_SY_MANUALPATH pathnode = pathnodes[0];
            EM_SY_MANUALBB bbmodel = new EM_SY_MANUALBB();
            bbmodel.BBID = pathnode.BBID;
            List<EM_SY_MANUALBB> bbnodes = _SY_MANUALBBDataAccess.Read(bbmodel).ToList();
            if (bbnodes.Count != 1)
            {
                rst.TYPE = "E";
                rst.MESSAGE = "查询电子说明书版本异常，请联系管理员";
                return rst;
            }
            EM_SY_MANUAL manualmodel = new EM_SY_MANUAL();
            manualmodel.MANUALID = bbnodes[0].MANUALID;
            List<EM_SY_MANUAL> manualnodes = _SY_MANUADataAccess.Read(manualmodel).ToList();
            if (manualnodes.Count != 1)
            {
                rst.TYPE = "E";
                rst.MESSAGE = "查询电子说明书异常，请联系管理员";
                return rst;
            }
            rst.TYPE = "S";
            //rst.MESSAGE = manualnodes[0].TYPENAME;
            EM_FILE_PATH pathrst = _DataAccess.Read(manualnodes[0].TYPENAME);
            if (string.IsNullOrEmpty(pathrst.PATH))
            {
                  rst.TYPE = "E";
                rst.MESSAGE = "查询EM_FILE_PATH异常，请联系管理员";
                return rst;
            }
            string url = pathrst.VIRTUALPATH;
            string ipurl = pathrst.IPPATH;
            string[] buildstring =  pathnode.CFLJ.Split('\\');
            for (int i = 0; i < buildstring.Length; i++)
            {
                url += "/" + buildstring[i];
                ipurl += "/" + buildstring[i];
            }
            rst.BH = manualnodes[0].TM.Split('-')[0];
            rst.TM = pathnode.FILENAME;
            rst.MESSAGE = url;
            rst.TYPE = ipurl;
            return rst;
        }
        
        // DateTime时间格式转换为Unix时间戳格式
        private int DateTimeToStamp(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }

     
            /// <summary>
            /// 将文件转换为byte数组
            /// </summary>
            /// <param name="path">文件地址</param>
            /// <returns>转换后的byte数组</returns>
            public  byte[] File2Bytes(string path)
            {
                if (!System.IO.File.Exists(path))
                {
                    return new byte[0];
                }

                FileInfo fi = new FileInfo(path);
                byte[] buff = new byte[fi.Length];

                FileStream fs = fi.OpenRead();
                fs.Read(buff, 0, Convert.ToInt32(fs.Length));
                fs.Close();

                return buff;
            }

            /// <summary>
            /// 将byte数组转换为文件并保存到指定地址
            /// </summary>
            /// <param name="buff">byte数组</param>
            /// <param name="savepath">保存地址</param>
            public  void Bytes2File(byte[] buff, string savepath)
            {
                if (System.IO.File.Exists(savepath))
                {
                    System.IO.File.Delete(savepath);
                }

                FileStream fs = new FileStream(savepath, FileMode.CreateNew);
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(buff, 0, buff.Length);
                bw.Close();
                fs.Close();
            }
        

    }
}
