using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

public class DebugSaveHandler
{
    private readonly string path;
    private readonly StringBuilder sb;
    private readonly bool isFileSave;

    public DebugSaveHandler(string path, bool isFileSave)
    {
        this.path = path;
        this.isFileSave = isFileSave;
        sb = new StringBuilder();
    }

    public void Apeend(string message)
    {
        string timestampedMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] {message}";
        sb.AppendLine(timestampedMessage);
    }

    public void Save()
    {
        if (!isFileSave)
            return;

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        string fileName = $"DebugLog_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
        string fullPath = Path.Combine(path, fileName);

        try
        {
            File.WriteAllText(fullPath, sb.ToString(), Encoding.UTF8);

            sb.Clear();

            Debug.Log($"로그 저장 완료: {fullPath}");
        }
        catch (Exception e)
        {
            Debug.LogError($"로그 파일 저장 중 오류 발생: {e.Message}");
        }

#if UNITY_EDITOR
        AssetDatabase.Refresh();
#endif
    }    
}
