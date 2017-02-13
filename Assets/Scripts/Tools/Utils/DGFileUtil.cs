using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class DGFileUtil
{

	public static List<string> GetAllFiles(DirectoryInfo dir, string except=null)
	{
		List<string> fileList = new List<string>();
		if(!Directory.Exists(dir.FullName) && !File.Exists(dir.FullName))
		{
			Debuger.LogError("Directory not exists : "+dir.FullName);
			return fileList;
		}
		
		FileInfo[] allFile = dir.GetFiles();
		for(int i=0; i<allFile.Length; i++)
		{
            FileInfo fi = allFile[i];
            if (except != null && fi.Name.IndexOf(except) != -1)
			{
				continue;
			}
			fileList.Add(fi.FullName);
		}
		
		DirectoryInfo[] allDir= dir.GetDirectories();
		foreach (DirectoryInfo d in allDir)
		{
			if(d.FullName == dir.FullName)
			{
				continue;
			}
			fileList.AddRange(GetAllFiles(d, except));
		}
		return fileList;
	}

	public static List<string> GetChildrenDirectory(DirectoryInfo dir)
	{
		List<string> fileList = new List<string>();
		if(!Directory.Exists(dir.FullName) && !File.Exists(dir.FullName))
		{
			Debuger.LogError("Directory not exists : "+dir.FullName);
			return fileList;
		}
		
		DirectoryInfo[] allDir= dir.GetDirectories();
		foreach (DirectoryInfo d in allDir)
		{
			if(d.FullName == dir.FullName)
			{
				continue;
			}
			fileList.Add(d.FullName);
		}
		return fileList;
	}

	public static void CreateDirectoryWhenNotExists(string destination)
	{
		destination = destination.Replace("\\", "/");
		string dir = destination.Substring(0, destination.LastIndexOf("/"));
		if(!Directory.Exists(dir))
		{
			Directory.CreateDirectory(dir);
		}
	}

	public static void CopyFile(string source, string destination)
	{
		CreateDirectoryWhenNotExists(destination);
		File.Copy(source, destination);
	}

	public static void CopyFileOrDirectory(string source, string destination, string except=null)
	{
		List<string> list = DGFileUtil.GetAllFiles(new DirectoryInfo(source), except);
		for(int i=0; i<list.Count; i++)
		{
			string path = list[i];
			string destPath = destination + path.Substring(source.Length);
			DGFileUtil.CopyFile(path, destPath);
		}
	}


	public static string GetFileNameByPath(string path)
	{
		path = path.Replace("\\", "/");
		return path.Substring(path.LastIndexOf("/")+1);
	}
}

