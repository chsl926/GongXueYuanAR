using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Net;
using System.IO;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Runtime.Remoting.Messaging;
using UnityEngine.UI;
//
//using System.Collections;
using UnityEngine;
//using DownLoad;
using System.Threading;

public enum ALI_STATE : int
{
    TIMEOUT=-2,//超时
    ERR = -1, //错误
    FREE = 0, //闲置
    DOWNLOAD = 1, //下载
    UPLOAD = 2,  //上传
    DONE = 3,    //完成
    DEL=4//移除
}
public enum ALI_TYPE : int
{
    DOWNLOAD_LEVEL,
    DOWNLOAD_ASSET,
    DOWNLOAD_FILE,
    DOWNLOAD_IMAGE,
    DOWNLOAD_TEXT,
    DOWNLOAD_SPEAK,
    UPLOAD_IMAGE,
    UPLOAD_SPEAK
}

public class SomeState
{
    public int Cookie;
    public string remoteName;
    public string localName;
    public string strSign;
    public bool bAvar;
    public ALI_STATE state;
    public ALI_TYPE type;
    public byte[] btTotalByte;
    public bool bExists;//是否存在
    public List<string> listSame;
    public int nSpeed;//每秒下载/上传速度
    public int nTimeOut;//超时次数
    public System.Action<string> Tcallback;//下载的是文本返回路径
    public System.Action<Sprite> Icallback;//下载的是图像返回路径
    public System.Action<bool> Lcallback;//下载成功返回路径
    public SomeState(int iCookie, string iRemoteName, string iLocalName, string iSign, bool iBAvar, ALI_TYPE iType)
    {
        Cookie = iCookie;
        remoteName = iRemoteName;
        localName = iLocalName;
        strSign = iSign;
        bAvar = iBAvar;
        type = iType;
        bExists = false;
        state = ALI_STATE.FREE;
        listSame = new List<string>();
        nSpeed = 0;
        nTimeOut = 0;
    }
}

public class Aliyun
{
    //public string strAccessId = "KKbQdUBXcPMRcdZu";
    //public string strAccessKey = "xj4Lh6T9BRHLDAZUfzaTJLMKn0D5UG";
    //public string iBuckName = "chsl926";   //资源bucket
    //public string iBuckUpdate = "avatarsources";//上传bucket
    //public string strArea = "oss-cn-shenzhen.aliyuncs.com";		//阿里云服务器地址
    //oss-cn-qingdao-a.aliyuncs.com   //oss.aliyuncs.com

    public string err = "suc";//测试错误信息
    //public long totalDownloadedByte = 0;//已经下载的资源
    //public long totalByte = 0;//当前资源总长度
    //public float progress = 0;//进度
    //public byte[] byTotal;//下载的场景资源
    //public string strPath = "";//下载资源的全地址
    //public Dictionary<int, int> _timeOutDic = new Dictionary<int,int>();//超时异常处理
    //private int _idTimeOut = 0;//id线程
    //public Dictionary<string, string> headerPut = new Dictionary<string, string>();

    //请求有效
    private double EXPIR = 10;//有效期 分钟
    //private DateTime lastInterval;
    //private bool bFirst = true;
    //异步
    //public delegate ALI_STATE DownLoadDelegate(string URL, string filename);
    public delegate ALI_STATE UpLoadDelegate(string URL, string filename);

    public int nCookie = 0;//当前线程cookie
    public Dictionary<string, SomeState> HashCount = new Dictionary<string, SomeState>();//保存每个线程 数据
    public List<SomeState> waitList = new List<SomeState>();//等待下载队列
    public List<string> listDone = new List<string>();//已经执行完毕的线程
    public List<string> CancelList = new List<string>();//取消的下载
    public bool bShutdown = false;//中断
    

    //进度处理
    public int nCurSpeed = 0;//当前下载速率
    public long lHaveDownLoad = 0;//已经下载的总量
    public long lTotalDownLoad = 0;//需要下载的总量
    public long lHaveUpLoad = 0;//已经上传的总量
    public long lTotalUpLoad = 0;//需要上传的总量
    public Aliyun()
    {

    }


    #region 阿里云处理

    //private void Sign(long len, string key)
    //{
    //    headerPut["Date"] = FormatRfc822Date(DateTime.UtcNow);
    //    headerPut["Content-Length"] = len.ToString();
    //    headerPut["Content-Type"] = "application/octet-stream";
    //    string accessId = strAccessId;
    //    string accessKey = strAccessKey;
    //    string method = "PUT";
    //    string resourcePath = "/" + iBuckName2 + "/" + key;
    //    string data = method + "\n\napplication/octet-stream\n" + headerPut["Date"] + "\n" + resourcePath;
    //    string str6 = ComputeSignatureCore(accessKey, data);
    //    headerPut.Add("Authorization", "OSS " + accessId + ":" + str6);
    //}
    private string FormatRfc822Date(DateTime dt)
    {
        return dt.ToUniversalTime().ToString(@"ddd, dd MMM yyyy HH:mm:ss \G\M\T", CultureInfo.CreateSpecificCulture("en-US"));
    }

    private string ReadString(string key, string bucketName)
    {
        //if (!bFirst)
        //{
        //    DateTime timeNow = DateTime.Now;
        //    if (timeNow < lastInterval.AddMinutes(EXPIR))
        //    {
        //        //Debug.Log("<");
        //        string imgurl = string.Format("http://{0}.{1}/{2}", iBuckName2, strArea, key);
        //        Debug.Log(imgurl);
        //        return imgurl;
        //    }
        //}
        ////Debug.Log(">");
        //bFirst = false;
        //lastInterval = DateTime.Now;
        DateTime expiration = DateTime.Now.AddMinutes(EXPIR);
        string accessId = SimpleFramework.AppConst.strAccessId;
        string accessKey = SimpleFramework.AppConst.strAccessKey;

        //string key = "9.data";
        long num = 0x89f7ff5f7b58000L;
        string str5 = ((expiration.ToUniversalTime().Ticks - num) / 0x989680L).ToString();
        string str6 = key;
        //string imgurl = string.Format("http://{0}.oss.aliyuncs.com/{1}", iBuckName2,key);

        //request.Headers.Add("Date", str5);

        string resourcePath = "/" + ((bucketName != null) ? bucketName : "") + ((key != null) ? ("/" + key) : "");
        //"GET\n\n\n1416972871\n/recoding/123.txt"
        string data = "GET\n\n\n" + str5 + "\n" + resourcePath;//SignUtils.BuildCanonicalString(generatePresignedUriRequest.Method.ToString().ToUpperInvariant(), resourcePath, request);
        string str10 = ComputeSignatureCore(accessKey, data);
        IDictionary<string, string> parameters = new Dictionary<string, string>();
        parameters.Add("Expires", str5);
        parameters.Add("OSSAccessKeyId", accessId);
        parameters.Add("Signature", str10);
        string requestParameterString = GetRequestParameterString(parameters);
        //{http://recoding.oss.aliyuncs.com/}
        string str12 = string.Format("http://{1}.{0}/", SimpleFramework.AppConst.strArea, bucketName);
        if (!str12.EndsWith("/"))
        {
            str12 = str12 + "/";
        }
        parameters.Clear();
        return str12 + str6 + "?" + requestParameterString;

    }

    protected string ComputeSignatureCore(string key, string data)
    {
        //Debug.Assert(!string.IsNullOrEmpty(data));
        using (KeyedHashAlgorithm algorithm = KeyedHashAlgorithm.Create("HmacSHA1".ToUpperInvariant()))
        {
            algorithm.Key = Encoding.UTF8.GetBytes(key.ToCharArray());
            return Convert.ToBase64String(algorithm.ComputeHash(Encoding.UTF8.GetBytes(data.ToCharArray())));
        }
    }

    private string GetRequestParameterString(IEnumerable<KeyValuePair<string, string>> parameters)
    {
        StringBuilder builder = new StringBuilder();
        bool flag = true;
        foreach (KeyValuePair<string, string> pair in parameters)
        {
            //Debug.Assert(!string.IsNullOrEmpty(pair.Key), "Null Or empty key is not allowed.");
            if (!flag)
            {
                builder.Append("&");
            }
            flag = false;
            builder.Append(pair.Key);
            if (pair.Value != null)
            {
                builder.Append("=").Append(UrlEncode(pair.Value, "utf-8"));
            }
        }
        return builder.ToString();
    }

    private string UrlEncode(string data, string charset)
    {
        //Debug.Assert((data != null) && !string.IsNullOrEmpty(charset));
        StringBuilder builder = new StringBuilder(data.Length * 2);
        string str = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~";
        byte[] bytes = Encoding.GetEncoding(charset).GetBytes(data);
        foreach (char ch in bytes)
        {
            if (str.IndexOf(ch) != -1)
            {
                builder.Append(ch);
            }
            else
            {
                builder.Append("%").Append(string.Format("{0:X2}", new object[] { (int)ch }));
            }
        }
        return builder.ToString();
    }
    #endregion
    #region 上传
    //long WriteTo(Stream orignStream, Stream destStream, long maxLength, out float progress2)
    //{
    //    byte[] buffer = new byte[0x1000];
    //    long num = 0L;
    //    int count = 0;
    //    while (num < maxLength)
    //    {
    //        count = orignStream.Read(buffer, 0, 0x1000);
    //        if (count <= 0)
    //        {
    //            break;
    //        }
    //        if ((num + count) > maxLength)
    //        {
    //            count = (int)(maxLength - num);
    //        }
    //        num += count;
    //        destStream.Write(buffer, 0, count);
    //        progress2 = (float)num / maxLength;
    //    }
    //    destStream.Flush();
    //    progress2 = (float)num / maxLength;
    //    return num;
    //}
    public void UpLoad(System.Object state)
    {
        //Interlocked.Increment(ref nCookie);//原子操作递增cookie 线程总数
        SomeState sta = (SomeState)state;
        sta.state = ALI_STATE.UPLOAD;
        sta.Cookie = nCookie;
        string key = sta.remoteName;
        string strFileName = sta.localName;
        if (!HashCount.ContainsKey(sta.remoteName))
        {
            lock(HashCount)
            {
                HashCount.Add(sta.remoteName, sta);
            }           
        }
        try
        {
            //strFileName = "E:/Aliyun/test/test.data";
            //FileInfo fi = new FileInfo(strFileName);
            //OssClient ossClient = new OssClient("http://oss.aliyuncs.com", strAccessKeyId, strAccessSecret);
            using (var fs = File.Open(strFileName, FileMode.Open))
            {
                //ObjectMetadata metadata = new ObjectMetadata();
                //metadata.ContentLength = fs.Length;
                Stream content = fs;
                //Sign(fs.Length,key);
                //key = "9.data";//远程文件名
                //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebRequest webRequest = WebRequest.Create(string.Format("http://{0}.{1}/{2}", SimpleFramework.AppConst.iBuckUpdate, SimpleFramework.AppConst.strArea, key)) as HttpWebRequest;
                //webRequest.Timeout = 20000;//20秒超时
                webRequest.Method = "PUT";
                webRequest.ServicePoint.ConnectionLimit = 50;//设置请求最大同时连接数
                // 键值对存储 
                //headers.Add("Contend-Type", "application/x-www-form-urlencoded"); 
                //foreach (KeyValuePair<string, string> pair in headerPut)
                //{
                //    //webRequest.Headers.AddInternal(pair.Key, pair.Value);

                //    Debug.Log(pair.Key);
                //    //webRequest.Headers.
                //    //Debug.Log(webRequest.Headers.Count);
                //    //webRequest.Headers.Add(pair.Key, pair.Value);

                //}
                //HTTPRequest request = new HTTPRequest(new Uri("https://google.com"),onRequestFinished);
                //webRequest.Headers = (WebHeaderCollection)headers;headers.
                webRequest.UserAgent = "aliyun-openservices-sdk-dotnet_1.0.4903.31558";
                webRequest.ContentLength = fs.Length;
                lTotalUpLoad += fs.Length;
                //long totalUploadedByte = 0;		
                //byte[] by = new byte[10240];//每次写入10K

                Stream data = content;
                using (Stream stream = webRequest.GetRequestStream())
                {
                    using (data)
                    {
                        //while(totalUploadedByte<fs.Length)
                        //{
                        //WriteTo(data, stream, webRequest.ContentLength, out progress);
                        //progress = 0;
                        //}

                        //long WriteTo(Stream orignStream, Stream destStream, long maxLength, out float progress2)

                        byte[] buffer = new byte[0x1000];
                        long num = 0L;
                        int count = 0;
                        while (num < webRequest.ContentLength && !bShutdown)
                        {
                            count = data.Read(buffer, 0, 0x1000);
                            if (count <= 0)
                            {
                                break;
                            }
                            if ((num + count) > webRequest.ContentLength)
                            {
                                count = (int)(webRequest.ContentLength - num);
                            }
                            num += count;
                            stream.Write(buffer, 0, count);
                            lHaveUpLoad += count;
                            //progress = (float)num / webRequest.ContentLength;
                        }
                        stream.Flush();
                        //progress = (float)num / webRequest.ContentLength;
                        //return num;

                    }
                }
                //获取服务器端的响应
                webRequest.GetResponse();

                if (bShutdown)//强制结束
                {
                    lock (HashCount[sta.remoteName])
                    {
                        HashCount[sta.remoteName].state = ALI_STATE.FREE;
                    }                  
                    listDone.Add(sta.remoteName);
                    return;
                }
                sta.state = ALI_STATE.DONE;
                listDone.Add(sta.remoteName);
            }
        }
        catch (System.Exception e)
        {
            err = strFileName + e.ToString();
            Debug.Log(err.ToString());
            sta.state = ALI_STATE.ERR;
            listDone.Add(sta.remoteName);
        }
        finally
        {
            lock (HashCount[sta.remoteName])
            {
                HashCount[sta.remoteName] = sta;
            }        
            GC.Collect();
            GC.Collect(1);
        }

        //Interlocked.Increment(ref nDone);
    }
    //public void UploadFile(string strFileName, string key)
    //{
    //    //if (nState != ALI_STATE.UPLOAD) //如果正在上传 返回
    //    //{
    //    //    nState = ALI_STATE.UPLOAD;
    //    //    UpLoadDelegate d = UpLoad;
    //    //    d.BeginInvoke(strFileName, key, GetUpResultCallBack, null);
    //    //}
    //}
    //private void GetUpResultCallBack(IAsyncResult asyncResult)
    //{
    //    AsyncResult result = (AsyncResult)asyncResult;
    //    UpLoadDelegate salDel = (UpLoadDelegate)result.AsyncDelegate;
    //    //nState = salDel.EndInvoke(asyncResult);
    //}
    #endregion
    #region 下载
    public void down(System.Object state)
    {
        //Interlocked.Increment(ref nCookie);//原子操作递增cookie 线程总数
        //nState = ALI_STATE.DOWNLOAD;
        //bShutdown = false;
        SomeState sta = (SomeState)state;
        sta.state = ALI_STATE.DOWNLOAD;
        //sta.Cookie = nCookie;
        string URL = sta.remoteName;
        string filename = sta.localName + ".pp";
        if (!HashCount.ContainsKey(sta.remoteName))
        {
            lock(HashCount)
            {
                HashCount.Add(sta.remoteName, sta);
            }          
        }

        //断点续传
        System.IO.Stream so = null;
        System.IO.Stream st = null;
        System.Net.HttpWebRequest Myrq=null;
        System.Net.HttpWebResponse myrp=null;
        long totalByte = 0;
        try
        {
            long lStartPos = 0;
            byte[] byOld = new byte[0];
            using (so = new System.IO.FileStream(filename, System.IO.FileMode.Create))
            {
                if (System.IO.File.Exists(filename))
                {
                    //so = System.IO.File.Open(filename, FileMode.Open, FileAccess.ReadWrite);
                    lStartPos = so.Length;
                    byOld = new byte[lStartPos];
                    so.Read(byOld, 0, (int)lStartPos);

                    //转码
                    //for(int i=0;i<byOld.Length;i++)
                    //{
                    //    if(byOld[i]==32)
                    //    {
                    //        byOld[i] = 0;
                    //    }
                    //}
                    //so.Seek(0, System.IO.SeekOrigin.Begin);
                    //so.Write(byOld, 0, (int)lStartPos);
                    //so.Seek(lStartPos, System.IO.SeekOrigin.Current); //移动文件流中的当前指针 
                }
                else
                {
                    //so = new System.IO.FileStream(filename, System.IO.FileMode.Create);
                    lStartPos = 0;
                }

                //请求连接
                string iBuckName2;
                if (sta.bAvar)
                    iBuckName2 = SimpleFramework.AppConst.iBuckUpdate;
                else
                    iBuckName2 = SimpleFramework.AppConst.iBuckName;
                URL = ReadString(URL, iBuckName2);
                Myrq = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(URL);
                Myrq.CookieContainer = new CookieContainer();
                string strDir = URL.Substring(0, URL.LastIndexOf("/"));
                Myrq.Referer = strDir;
                if (lStartPos > 0)//设置Range
                {
                    Myrq.AddRange((int)lStartPos);
                }
                Myrq.Timeout = 10 * 1000;//设置超时10秒
                Myrq.ServicePoint.ConnectionLimit = 50;//设置请求最大同时连接数
                myrp = (System.Net.HttpWebResponse)Myrq.GetResponse();
                st = myrp.GetResponseStream();


                //开始下载
                long totalDownloadedByte = 0;//清空下载总长度
                totalByte = myrp.ContentLength;//需要下载的长度
                lTotalDownLoad += totalByte;
                byte[] by = new byte[1024];//每次读取分包的长度          
                sta.btTotalByte = new byte[totalByte + lStartPos];//单个资源总byte数据
                byte[] byDownLoad = new byte[totalByte];//需下载的临时存储数组
                DateTime startTime = DateTime.Now;//开始下载时间
                //int nSpeed=0;//kb/s                
                int osize = st.Read(by, 0, (int)by.Length);//开始读取
                while (osize > 0 && !bShutdown)
                {
                    TimeSpan span = DateTime.Now - startTime;
                    //nSpeed+=osize;
                    lock (HashCount[sta.remoteName])
                    {
                        HashCount[sta.remoteName].nSpeed += osize;
                    }                   
                    Array.Copy(by, 0, byDownLoad, totalDownloadedByte, osize);

                    totalDownloadedByte = osize + totalDownloadedByte;

                    so.Write(by, 0, osize);

                    osize = st.Read(by, 0, (int)by.Length);
                    lHaveDownLoad += osize;
                    //progress = (float)totalDownloadedByte / totalByte;
                }


                //下载完毕 组合处理
                if (lStartPos > 0)//添加本地断点续传前的已下载数据
                {
                    //byte[] b = ReadFile((FileStream)so);
                    Array.Copy(byOld, 0, sta.btTotalByte, 0, lStartPos);
                }
                Array.Copy(byDownLoad, 0, sta.btTotalByte, lStartPos, totalByte);
                //// 保存为文件
                //File.WriteAllBytes(filename+"2", byTotal);
                so.Close();
                st.Close();
                if (bShutdown)//强制结束
                {
                    lock (HashCount[sta.remoteName])
                    {
                        HashCount[sta.remoteName].state = ALI_STATE.FREE;
                    }
                    listDone.Add(sta.remoteName);
                    return;
                }
                ReNameFile(filename, filename.Substring(0, filename.Length - 3));
                sta.state = ALI_STATE.DONE;
                listDone.Add(sta.remoteName);
            }
        }
        catch (WebException e)
        {
            if (e.Status == WebExceptionStatus.Timeout)
            {
                err = sta.remoteName + e.Message;
                Debug.Log(err);
                sta.state = ALI_STATE.TIMEOUT;
                lTotalDownLoad -= totalByte;
                listDone.Add(sta.remoteName);
                myrp.Close();
                lock (HashCount[sta.remoteName])
                {
                    HashCount[sta.remoteName] = sta;
                }              
                if (so != null)
                    so.Close();
                if (st != null)
                    st.Close();
                GC.Collect();
                GC.Collect(1);
                return;
            }
        }
        catch (Exception e)
        {
            err = sta.remoteName + e.Message;
			Debug.Log(err);
            sta.state = ALI_STATE.ERR;
            lTotalDownLoad -= totalByte;
            listDone.Add(sta.remoteName);
            myrp.Close();
        }
        finally
        {
            lock (HashCount[sta.remoteName])
            {
                HashCount[sta.remoteName] = sta;
            }        
            if (so != null)
                so.Close();
            if (st != null)
                st.Close();
            GC.Collect();
            GC.Collect(1);         
        }
    }
 
    public void ReNameFile(string oldStr, string newStr)
    {
        // 改名方法
        FileInfo fi = new FileInfo(oldStr);
        fi.MoveTo(newStr);
    }
    #endregion
}