using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System;

[CustomPropertyDrawer(typeof( DataA ))]
public class DataAEditor : PropertyDrawer
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
		ShowOnEnum(prop, "showData", "SHOW_DATA_ENUM_1", "intA");
		ShowOnEnum(prop, "showData", "SHOW_DATA_ENUM_1", "strA");
		ShowOnEnum(prop, "showData", "SHOW_DATA_ENUM_1", "floatA");
		ShowOnEnum(prop, "showData", "SHOW_DATA_ENUM_1", "fooEnum");
		ShowOnEnum(prop, "showData", "SHOW_DATA_ENUM_2", "intA");
		ShowOnEnum(prop, "showData", "SHOW_DATA_ENUM_2", "strA");
		ShowOnEnum(prop, "showData", "SHOW_DATA_ENUM_2", "floatA");
		ShowOnEnum(prop, "showData", "SHOW_DATA_ENUM_3", "intA");
		ShowOnEnum(prop, "showData", "SHOW_DATA_ENUM_3", "strA");
		//ShowOnEnum(prop, "showData", "SHOW_DATA_ENUM_3", "dataClassB");
		EditorGUI.indentLevel = idv;
	}
}
