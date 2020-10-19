using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor;


public class GameObjectTool
{

	[MenuItem("Fake GameObject/Create Empty")]
	static void CreateEmpty()
	{
		GameObject _empty = new GameObject("Empty");
		Selection.activeGameObject = _empty.gameObject;
	}

	[MenuItem("Fake GameObject/3D Object/Cube")]
	static void CreateCube()
	{
		GameObject _cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		_cube.transform.position = new Vector3(0, 0.5f, 0);
		Selection.activeGameObject = _cube.gameObject;
	}
	[MenuItem("Fake GameObject/3D Object/Quad")]
	static void CreateQuad()
	{

		GameObject _quad = GameObject.CreatePrimitive(PrimitiveType.Quad);

		Selection.activeGameObject = _quad.gameObject;
	}



}

