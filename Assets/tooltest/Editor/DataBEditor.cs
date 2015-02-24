using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System;
using System.Reflection;

[CustomPropertyDrawer(typeof(DataB))]
public class DataBEditor : PropertyDrawer
{
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void ShowOnEnum(SerializedProperty prop, string enumFieldName, string enumValue,string fieldName)
	{		 
		SerializedProperty enumField = prop.FindPropertyRelative(enumFieldName);
		if (enumField != null)
		{
			if (enumField.propertyType == SerializedPropertyType.Enum)
			{
				if(enumField.enumNames[enumField.enumValueIndex] == enumValue)
				{					
					SerializedProperty pr = prop.FindPropertyRelative(fieldName);
					EditorGUILayout.PropertyField(pr, true);
				}
			}
		}
	}

	//public override void OnInspectorGUI ()
	public override void OnGUI(Rect position, SerializedProperty prop, GUIContent label)
	{
		EditorGUILayout.LabelField(prop.type.ToString());
		
		SerializedProperty showData = prop.FindPropertyRelative ("showData");
		EditorGUILayout.PropertyField(showData, true);
		
		int idv = EditorGUI.indentLevel;
		EditorGUI.indentLevel++;
		ShowOnEnum(prop, "showData", "BTN_TYPE_DEFAULT", "intA");
		ShowOnEnum(prop, "showData", "BTN_TYPE_DEFAULT", "intA");
		ShowOnEnum(prop, "showData", "BTN_TYPE_GRID", "intB");
		ShowOnEnum(prop, "showData", "BTN_TYPE_GRID", "strB");
		EditorGUI.indentLevel = idv;
	}	

}
