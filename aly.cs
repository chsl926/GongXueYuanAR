using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Security.Cryptography;
using Aliyun.OSS.Common;
using Aliyun.OSS;
using System.Timers;


namespace Aliyun.OSS.Samples
{
    public class aly : MonoBehaviour
    {


           // endpoint以杭州为例，其它region请按实际情况填写
    static String endpoint = Config.Endpoint;
    // accessKey请登录https://ak-console.aliyun.com/#/查看
    static  String accessKeyId = Config.AccessKeyId;
    static String accessKeySecret = Config.AccessKeySecret;
    static string  bucketName =Config.BacketName;
    // 创建OSSClient实例
        
    static OssClient ossClient = new OssClient(endpoint, accessKeyId, accessKeySecret);
   

        //  static Bucket bucket = client.CreateBucket(bucketName);
        // Use this for initialization
        void Start()
        {
            // 下载object到文件
           // ossClient.GetObject(new GetObjectRequest(bucketName, "LevelData.txt"), new System.IO.File(Config.DirToDownload + "/aa"));
            // 关闭client
        }
      
        void Update()
        {

        }

       


      

        IEnumerator DownLoad(string url)
        {
            WWW w = new WWW(url);
            yield return w;
            if (w.isDone)
            {
                Debug.Log(w.text);
            }

        }
    }

}