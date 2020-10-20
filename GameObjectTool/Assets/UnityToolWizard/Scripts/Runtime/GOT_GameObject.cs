using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GOT_GameObject : MonoBehaviour
{
	[SerializeField] string[] primitivesNames, lightsNames = null;
	[SerializeField] List<GameObject> allObjects = new List<GameObject>();


	public void Init()
	{
		primitivesNames = GetEnumDatas<PrimitiveType>();
		lightsNames = GetEnumDatas<LightType>();
		CheckForObject();
	}


	void CheckForObject()
	{
		for (int i = 0; i < allObjects.Count; i++)
		{
			if (!allObjects[i])
				allObjects.RemoveAt(i);
		}
	}

	//pour l'instant on fait en deux fois, TODO <T> pour lights et primitives en une méthode
	string[] GetEnumDatas<T>() => Enum.GetNames(typeof(T));

	public void CreatePrimitve(int _i)
	{
		PrimitiveType _type = (PrimitiveType)_i;
		GameObject _object = GameObject.CreatePrimitive(_type);
		allObjects.Add(_object);
	}

	public void CreateLight(int _i)
	{
		if (_i > lightsNames.Length - 2) return;
		LightType _lightType = (LightType)_i;
		GameObject _lightObject = new GameObject($"{_lightType}");
		Light _light = _lightObject.AddComponent<Light>();
		_light.type = _lightType;
		allObjects.Add(_lightObject);
	}

	public void DestroyObject(int _i)
	{
		DestroyImmediate(allObjects[_i]);
		allObjects.RemoveAt(_i);
	}



}
