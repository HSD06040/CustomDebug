using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine;

public static class Debug
{
    private enum MessageType { Normal, Warning, Error }
    static DebugSetting debugSetting;
    static DebugSaveHandler saveHandler;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Inject()
    {
        debugSetting = Resources.Load<DebugSetting>("DebugSetting");
        saveHandler = new DebugSaveHandler($"{Application.streamingAssetsPath}/{debugSetting.fileName}", debugSetting.isFileSave);
    }

    [HideInCallstack]
    public static void Log(string message,
        [CallerMemberName] string member = "",
        [CallerFilePath] string file = "",
        [CallerLineNumber] int line = 0) => ShowLog(message, MessageType.Normal, member, file, line);

    [HideInCallstack]
    public static void LogWarning(string message,
        [CallerMemberName] string member = "",
        [CallerFilePath] string file = "",
        [CallerLineNumber] int line = 0) => ShowLog(message, MessageType.Warning, member, file, line);

    [HideInCallstack]
    public static void LogError(string message,
        [CallerMemberName] string member = "",
        [CallerFilePath] string file = "",
        [CallerLineNumber] int line = 0) => ShowLog(message, MessageType.Error, member, file, line);

    [HideInCallstack]
    static void ShowLog(string message, MessageType messageType,
    string member,
    string file,
    int line)
    {
        string fileName = Path.GetFileName(file);

        UnityEngine.Color logColor;

        switch (messageType)
        {
            case MessageType.Normal:
                logColor = debugSetting.normalColor;
                break;
            case MessageType.Warning:
                logColor = debugSetting.warningColor;
                break;
            case MessageType.Error:
                logColor = debugSetting.errorColor;
                break;
            default:
                logColor = UnityEngine.Color.white;
                break;
        }

        string colorTag = $"<color=#{ColorUtility.ToHtmlStringRGB(logColor)}>";
        string closeColorTag = "</color>";
        string contextPrefix = $"[{fileName}:{line} - {member}]";
        string formattedMessage = $"{colorTag}{contextPrefix} {message}{closeColorTag}";

        switch (messageType)
        {
            case MessageType.Normal:
                UnityEngine.Debug.Log(formattedMessage);
                break;
            case MessageType.Warning:
                UnityEngine.Debug.LogWarning(formattedMessage);
                break;
            case MessageType.Error:
                UnityEngine.Debug.LogError(formattedMessage);
                break;
        }

        if(debugSetting.isFileSave)
            saveHandler.Apeend($"[{messageType.ToString()}]\t{contextPrefix} {message}");
    }

    public static void Save() => saveHandler.Save();
}
