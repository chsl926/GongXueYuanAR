using UnityEngine;
using System.Collections;
using UnityEditor;
//using YZL.Compress.GZip;
using YZL.Compress.LZMA;
using YZL.Compress.UPK;

public class CompressDir : EditorWindow
{
 
    [MenuItem("Tools/CompressDir/Compress")]
    public static  void Compress()
    {
        string path = EditorUtility.OpenFolderPanel("Select Resource Folder", " ", "");
        string[] name = path.Split('/');
       // Object[] selection = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);
       // for (int i = 0; i < selection.Length; i++)
       // {
           // string path=selection[i].
           UPKFolder.PackFolderAsync(path, Application.streamingAssetsPath + "/"+ name[name.Length-1] +".upk", ShowProgress);

       // }
        
    }
    [MenuItem("Tools/CompressDir/UnCompress")]
    public static void UnCompress()
    {
        string inpath = EditorUtility.OpenFilePanel("Select Target File ", "", "");

       string outpath = EditorUtility.OpenFolderPanel("Select Save Folder", " ", "");
       
        UPKFolder.UnPackFolderAsync(inpath, outpath+"/", ShowProgress);

    }
    static void ShowProgress(long all, long now)
    {
        double progress = (double)now / all;
        Debug.Log("当前进度为: " + progress);
    }
}
