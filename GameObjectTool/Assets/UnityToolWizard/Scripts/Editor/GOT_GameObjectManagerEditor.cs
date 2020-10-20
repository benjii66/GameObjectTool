using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GOT_GameObject))]
public class GOT_GameObjectEditor : Editor
{
	GOT_GameObject tool = null;
	SerializedProperty primitivesArray, ligthArray, allObjects = null;

	#region Unity Methods
	void OnEnable() => InitTool();

	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		EditorGUILayout.HelpBox($"[Unity Tool Wizard]", MessageType.Info);
		DrawSectionUI("3D Primitives", primitivesArray, new Color(.16f, .4f, .2f), tool.CreatePrimitve);
		DrawSectionUI("3D Lights", ligthArray, new Color(1f, .4f, .2f), tool.CreateLight);
		DrawAllObjectsUI();
		//DrawPrimitivesUI();
		//DrawLightUI("3D Lights");
	}
	#endregion Unity Methods

	#region Custom Methods
	void InitTool()
	{
		tool = (GOT_GameObject)target;
		tool.Init();
		primitivesArray = serializedObject.FindProperty("primitivesNames");
		ligthArray = serializedObject.FindProperty("lightsNames");
		allObjects = serializedObject.FindProperty("allObjects");
	}

	/**
	void DrawPrimitivesUI(string _sectionName)
	{

		if (primitivesArray == null) return;
		EditorGUILayout.HelpBox($"{_sectionName}", MessageType.None);
		GUILayout.BeginHorizontal();
		for (int i = 0; i < primitivesArray.arraySize; i++)
		{
			string _name = primitivesArray.GetArrayElementAtIndex(i).stringValue;
			GUIButtonTool.CreateButton(_name, Color.white, new Color(.16f, .4f, .2f), null);
			GUILayoutTool.Space();
		}
		GUILayout.EndHorizontal();
	}



	void DrawLightUI(string _sectionName)
	{

		if (ligthArray == null) return;
		EditorGUILayout.HelpBox($"{_sectionName}", MessageType.None);
		GUILayout.BeginHorizontal();
		for (int i = 0; i < ligthArray.arraySize; i++)
		{
			string _name = ligthArray.GetArrayElementAtIndex(i).stringValue;
			GUIButtonTool.CreateButton(_name, Color.white, new Color(.1f, .6f, .2f), null);
			GUILayoutTool.Space();
		}
		GUILayout.EndHorizontal();
	}
	**/

	//new Color(.16f, .4f, .2f) vert
	//new Color(.1f, .6f, .2f) jaune
	void DrawSectionUI(string _sectionName, SerializedProperty _array, Color _buttonColor, Action<int> _callback)
	{

		if (_array == null) return;
		GUILayoutTool.Space();
		EditorGUILayout.HelpBox($"{_sectionName}", MessageType.None);
		GUILayoutTool.Space();
		GUILayout.BeginHorizontal();
		for (int i = 0; i < _array.arraySize; i++)
		{
			string _name = _array.GetArrayElementAtIndex(i).stringValue;
			GUIButtonTool.CreateButton(_name, Color.white, _buttonColor, _callback, i);
			GUILayoutTool.Space();
		}
		GUILayout.EndHorizontal();
		GUILayoutTool.Space();
	}

	void DrawAllObjectsUI()
	{
		if (allObjects == null) return;
		GUILayoutTool.Space(2);
		EditorGUILayout.HelpBox("All objects List : ", MessageType.Info);
		for (int i = 0; i < allObjects.arraySize; i++)
		{

			GameObject _object = (GameObject)allObjects.GetArrayElementAtIndex(i).objectReferenceValue;
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.HelpBox(_object.name, MessageType.None);
			GUILayoutTool.Space();
			GUIButtonTool.CreateButton("Select", Color.white, new Color(.16f, .4f, .2f), () => SelectObject(_object));
			GUIButtonTool.CreateButtonConfirmation("X", $"Delete this {_object.name} ?", "Yes", "No", Color.white, new Color(.6f, .1f, .1f), () => tool.DestroyObject(i));
			EditorGUILayout.EndHorizontal();
			GUILayoutTool.Space();

		}
	}

	void SelectObject(GameObject _object) => Selection.activeObject = _object;

	#endregion Custom Methods

}
 