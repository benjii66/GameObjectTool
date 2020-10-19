using System;
using UnityEngine;
using UnityEditor;

public static class GUIButtonTool
{
    public static void CreateButton(string _label, Color _colorText, Color _colorBackground, Action _callback, int _fontSize = 12, TextAnchor _align = TextAnchor.MiddleCenter, FontStyle _fontStyle = FontStyle.Bold)
    {
        if (GUILayout.Button(_label, GUIStyleTool.SetButtonStyle(_colorText, _align, _fontStyle, _colorBackground, _fontSize)))
            _callback?.Invoke();
    }
    public static void CreateButtonConfirmation(string _label, string _confirmationMsg, Color _colorText, Color _colorBackground, Action _callback, int _fontSize = 12, TextAnchor _align = TextAnchor.MiddleCenter, FontStyle _fontStyle = FontStyle.Bold)
    {
        if (GUILayout.Button(_label, GUIStyleTool.SetButtonStyle(_colorText, _align, _fontStyle, _colorBackground, _fontSize)))
        {
            bool _isReady = EditorUtility.DisplayDialog(_confirmationMsg, _confirmationMsg, "Yes", "No");
            if (_isReady)
                _callback?.Invoke();
        }
    }
    public static void CreateButtonConfirmation(string _label, string _confirmationMsg, string _okMsg, string _cancelMsg, Color _colorText, Color _colorBackground, Action _callback, int _fontSize = 12, TextAnchor _align = TextAnchor.MiddleCenter, FontStyle _fontStyle = FontStyle.Bold)
    {
        if (GUILayout.Button(_label, GUIStyleTool.SetButtonStyle(_colorText, _align, _fontStyle, _colorBackground, _fontSize)))
        {
            bool _isReady = EditorUtility.DisplayDialog(_confirmationMsg, _confirmationMsg, _okMsg, _cancelMsg);
            if (_isReady)
                _callback?.Invoke();
        }
    }
}
