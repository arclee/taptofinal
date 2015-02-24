using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System;
using System.Reflection;

[CustomPropertyDrawer(typeof(DataC))]
public class DataCEditor : PropertyDrawer
{
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
	public void ShowOnEnum(SerializedProperty prop, string enumFieldName,string fieldName , string []enumValue)
	{		 
		SerializedProperty enumField = prop.FindPropertyRelative(enumFieldName);
		if (enumField != null && (enumField.propertyType == SerializedPropertyType.Enum))
		{
			for (int i = 0; i < enumValue.Length; i++)
			{
				if(enumField.enumNames[enumField.enumValueIndex] == enumValue[i])
				{					
					SerializedProperty pr = prop.FindPropertyRelative(fieldName);
					EditorGUILayout.PropertyField(pr, true);
					break;
				}

			}

		}
	}

	//public override void OnInspectorGUI ()
	public override void OnGUI(Rect position, SerializedProperty prop, GUIContent label)
	{
		EditorGUILayout.LabelField(prop.type.ToString());
		
		SerializedProperty showData1 = prop.FindPropertyRelative ("showData1");
		EditorGUILayout.PropertyField(showData1, true);
		SerializedProperty showData2 = prop.FindPropertyRelative ("showData2");
		EditorGUILayout.PropertyField(showData2, true);
		SerializedProperty showData3 = prop.FindPropertyRelative ("showData3");
		EditorGUILayout.PropertyField(showData3, true);
		
		int idv = EditorGUI.indentLevel;
		EditorGUI.indentLevel++;
		ShowOnEnum(prop, "showData1", "intA", new string[]{"BTN_TYPE_DEFAULT"});
		ShowOnEnum(prop, "showData1", "strA", new string[]{"BTN_TYPE_DEFAULT"});
		ShowOnEnum(prop, "showData1", "intB", new string[]{"BTN_TYPE_GRID"});
		ShowOnEnum(prop, "showData1", "strB", new string[]{"BTN_TYPE_GRID"});
		EditorGUI.indentLevel = idv;
	}	

}
