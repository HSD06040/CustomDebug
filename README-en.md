<div align="center">
  <img src="https://capsule-render.vercel.app/api?type=wave&color=timeGradient&height=250&section=header&text=Custom%20Debug&fontSize=70" />
</div>

A custom debug system designed to make the debugging process more efficient and visual. Take your log tracking and management to the next level!

## Benefits

1. **Debug messages include script name, line number, and function name!**
2. **Customize debug message colors!**
3. **Save debug logs for easier bug tracking!**

<br>

# Key Features
## 🔍 Enhanced Debug Messages & Color Customization
>Added essential context information to log messages and applied status-specific colors to maximize log readability.

<br>

- 🎨 Default Settings
  
  <img width="366" height="82" alt="image" src="https://github.com/user-attachments/assets/bd529df3-5345-46ff-b9be-16832925d112" />
  
  Current default color settings. Can be changed anytime in the Resources/DebugSetting file.

<br>

- ✨ Example Output

  <img width="401" height="127" alt="image" src="https://github.com/user-attachments/assets/0cf6a33d-b029-4faa-877f-5aef0ec3b499" />

---

## 📁 Log File Saving

> Save all console logs to files for persistent recording and analysis.

<br>

- ✅ Save Settings

  <img width="366" height="134" alt="image" src="https://github.com/user-attachments/assets/6d788880-9bd0-432f-ac24-7ef91b27d763" />

  Enable/disable log file saving in the DebugSetting file.


<br>

- 📄 Saved Log File

  <img width="536" height="71" alt="image" src="https://github.com/user-attachments/assets/fdc4f6d3-d32f-4208-ab39-960bbedc55c7" />

  Example of a saved log file.

<br>

- 💾 Modify Save Path

  The log file save path can be modified in the Init() method within the Debug.cs file.

```cs
  static void Init()
  {
      debugSetting = Resources.Load<DebugSetting>("DebugSetting");
      // Default save path: Saved under Application.streamingAssetsPath with the configured file name
      saveHandler = new DebugSaveHandler($"{Application.streamingAssetsPath}/{debugSetting.fileName}", debugSetting.isFileSave);
  }
```
⚙️ Usage

Example: Debugging
```cs
csprivate void Start()
{
    Debug.Log("Log");
    Debug.LogWarning("Log Warning");
    Debug.LogError("Log Error");
}
```
Example: Saving
> Logs will not be saved unless this method is called.
```cs
csprivate void Save() => Debug.Save();
```
