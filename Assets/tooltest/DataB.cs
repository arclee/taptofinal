using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class DataB //: ScriptableObject
{
	
	public enum BtnType
	{
		BTN_TYPE_DEFAULT = 0,
		BTN_TYPE_GRID,
	}
	
	public BtnType showData = BtnType.BTN_TYPE_DEFAULT;
	
	public int intA;
	public int intB;
	public string strA;
	public string strB;
	public float floatA;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
