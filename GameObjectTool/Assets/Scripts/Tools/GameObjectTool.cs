using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor;


public class GameObjectTool
{

	[MenuItem("Fake GameObject/Create Empty")]
	static void CreateEmpty()
	{
		GameObject _truc = new GameObject("Empty");
		Selection.activeGameObject = _truc.gameObject;
	}

	[MenuItem("Fake GameObject/3D Object/Cube")]
	static void CreateSth()
	{
		GameObject _truc = new GameObject("Cube");
		Selection.activeGameObject = _truc.gameObject;
	}
	[MenuItem("Fake GameObject/3D Object/Quad")]
	static void CreateQuad()
	{
		GameObject _truc = new GameObject("Quad");
		Selection.activeGameObject = _truc.gameObject;
	}



}

