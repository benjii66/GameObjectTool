using System;
using UnityEditor;
using UnityEngine;

public static class GUILayoutTool
{
    public static void Space(int _number = 1)
    {
        for (int i = 0; i < _number; i++)
            EditorGUILayout.Space();
    }

	public static void Fold(ref bool _value, string _label, bool _toggle = true)
	{
		_value = EditorGUILayout.Foldout(_value, _label, _toggle);
	}


}
