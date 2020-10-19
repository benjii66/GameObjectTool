using UnityEngine;

public static class GUIStyleTool
{
    #region Style
    /// <summary>
    /// Change button style
    /// </summary>
    /// <param name="_textColor"></param>
    /// <param name="_align"></param>
    /// <param name="_fontStyle"></param>
    /// <param name="_buttonColor"></param>
    /// <param name="_size"></param>
    /// <returns></returns>
    public static GUIStyle SetButtonStyle(Color _textColor, TextAnchor _align, FontStyle _fontStyle, Color _buttonColor, int _size = 12)
    {
        GUIStyle _style = new GUIStyle(GUI.skin.button);
        _style.normal.textColor = _textColor;
        _style.normal.background = GetPixelColor(_buttonColor);
        _style.alignment = _align;
        _style.fontStyle = _fontStyle;
        _style.fontSize = _size;
        return _style;
    }
    static Texture2D GetPixelColor(Color _color)
    {
        Texture2D _t = new Texture2D(1, 1);
        _t.SetPixel(1, 1, _color);
        _t.Apply();
        return _t;
    }
    /// <summary>
    /// Change label style on GUI
    /// </summary>
    public static GUIStyle SetLabelStyle(Color _textColor, TextAnchor _alignement, FontStyle _fontStyle, int _size = 12)
    {
        GUIStyle _style = new GUIStyle(GUI.skin.label);
        _style.normal.textColor = _textColor;
        _style.alignment = _alignement;
        _style.fontStyle = _fontStyle;
        _style.fontSize = _size;
        return _style;
    }
    #endregion
}
