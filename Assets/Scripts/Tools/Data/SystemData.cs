using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public enum VersionType
{
	Chinese,
	Japanese,
	English
}

public static class ConfigTableData
{
	static Dictionary<string, ConfigTable> m_ConfigTableDict = new Dictionary<string, ConfigTable>();
	public static Dictionary<string, ConfigTable> ConfigTableDict
	{
		get {return m_ConfigTableDict; }
	}
}