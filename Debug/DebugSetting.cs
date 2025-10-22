using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Debug_Setting")]
public class DebugSetting : ScriptableObject
{
    public bool isFileSave = false;
    public string fileName = string.Empty;
    public Color normalColor, warningColor, errorColor;    
}
