using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace FileUtility
{
    public static class File
    {
        public static string GetDataPath()
        {
#if UNITY_EDITOR
            return "Assets/Resources/";
#elif UNITY_STANDALONE_WIN
            return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments).Replace("\\", "/"), "/Dont Walk By/");
#else
            return Application.persistentDataPath + "/Dont Walk By/";
#endif
        }
    }
}