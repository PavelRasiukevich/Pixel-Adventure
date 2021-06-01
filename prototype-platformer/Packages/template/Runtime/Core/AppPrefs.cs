using System.IO;
using UnityEngine;

public class AppPrefs
{
    public static void SetObject(string _key, object _obj)
    {
        bool _flag;

#if UNITY_EDITOR
        _flag = true;
#else
        _flag = false;
#endif
        SaveToFile(_key, JsonUtility.ToJson(_obj, _flag));
    }

    public static T GetObject<T>(string _key)
    {
        return JsonUtility.FromJson<T>(ReadFromFile(_key));
    }

    public static void SetBool(string _key, bool _value)
    {
        PlayerPrefs.SetInt(_key, _value ? 1 : 0);
    }

    public static bool GetBool(string _key)
    {
        return PlayerPrefs.GetInt(_key) == 1;
    }

    public static void SetInt(string _key, int _value)
    {
        PlayerPrefs.SetInt(_key, _value);
    }

    public static int GetInt(string _key)
    {
        return PlayerPrefs.GetInt(_key);
    }

    public static void SetFloat(string _key, float _value)
    {
        PlayerPrefs.SetFloat(_key, _value);
    }

    public static float GetFloat(string _key)
    {
        return PlayerPrefs.GetFloat(_key);
    }

    public static void SetString(string _key, string _value)
    {
        PlayerPrefs.SetString(_key, _value);
    }

    public static string GetString(string _key)
    {
        return PlayerPrefs.GetString(_key);
    }

    public static void Save()
    {
        PlayerPrefs.Save();
    }

    public static void DeleteAll()
    {
        PlayerPrefs.DeleteAll();
    }

    public static void DeleleKey(string _key)
    {
        PlayerPrefs.DeleteKey(_key);
    }

    public static bool HasKey(string _key)
    {
        return PlayerPrefs.HasKey(_key);
    }

    public static bool HasObject(string _key)
    {
        return File.Exists(GetFilePath(_key));
    }

    public static void DeleteObject(string _key)
    {
        File.Delete(GetFilePath(_key));
    }

    private static void SaveToFile(string _fileName, string _fileContent)
    {
        File.WriteAllText(GetFilePath(_fileName), _fileContent);
    }

    private static string ReadFromFile(string _fileName)
    {
        string _content;

        if (File.Exists(GetFilePath(_fileName)))
            _content = File.ReadAllText(GetFilePath(_fileName));
        else
            _content = string.Empty;

        return _content;
    }

    private static string GetFilePath(string _fileName)
    {
        return Path.Combine(Application.persistentDataPath, _fileName);
    }
}