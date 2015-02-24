using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class DataA //: ScriptableObject
{
	public enum ShowDataEnum
	{
		SHOW_DATA_ENUM_1 = 0,
		SHOW_DATA_ENUM_2,
		SHOW_DATA_ENUM_3,
	}
	
	public enum FooEnum
	{
		FOO_ENUM_1 = 0,
		FOO_ENUM_2,
		FOO_ENUM_3,
	}

	public ShowDataEnum showData = ShowDataEnum.SHOW_DATA_ENUM_1;
	public FooEnum fooEnum = FooEnum.FOO_ENUM_1;

	public int intA;
	public int intB;
	public string strA;
	public string strB;
	public float floatA;
	//public DataB dataClassB;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
