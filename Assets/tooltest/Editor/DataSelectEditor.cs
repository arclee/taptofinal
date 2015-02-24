using UnityEngine;
using System.Collections;
using UnityEditor;


[CustomEditor(typeof(DataSelect))]
public class DataSelectEditor : Editor
{

	override public void OnInspectorGUI()
	{
		DrawDefaultInspector();
	}

}
