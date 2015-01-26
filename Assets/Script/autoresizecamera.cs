﻿using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class autoresizecamera : MonoBehaviour {

	public float width = 16.0f;
	public float height = 9.0f;
	public ScreenOrientation lastOri;
	public bool autoSwitchOrientation = false;
	void Autosize()
	{
		lastOri = Screen.orientation;
		// set the desired aspect ratio (the values in this example are
		// hard-coded for 16:9, but you could make them into public
		// variables instead so you can set them at design time)
		float targetaspect = 1;
		if (autoSwitchOrientation)
		{
			if (lastOri == ScreenOrientation.Landscape)
			{
				targetaspect = width / height;
			}
			else
			{
				targetaspect = height / width;
			}
		}
		else
		{
			targetaspect = width / height;
		}
		
		// determine the game window's current aspect ratio
		float windowaspect = (float)Screen.width / (float)Screen.height;
		
		// current viewport height should be scaled by this amount
		float scaleheight = windowaspect / targetaspect;
		
		// obtain camera component so we can modify its viewport
		Camera camera = GetComponent<Camera>();
		
		// if scaled height is less than current height, add letterbox
		if (scaleheight < 1.0f)
		{  
			Rect rect = camera.rect;
			
			rect.width = 1.0f;
			rect.height = scaleheight;
			rect.x = 0;
			rect.y = (1.0f - scaleheight) / 2.0f;
			
			camera.rect = rect;
		}
		else // add pillarbox
		{
			float scalewidth = 1.0f / scaleheight;
			
			Rect rect = camera.rect;
			
			rect.width = scalewidth;
			rect.height = 1.0f;
			rect.x = (1.0f - scalewidth) / 2.0f;
			rect.y = 0;
			
			camera.rect = rect;
		}

	}

	// Use this for initialization
	void Start ()
	{
		Autosize();
	}
	
	// Update is called once per frame
	void Update ()
	{
#if UNITY_EDITOR
		Autosize();
#endif
		if (Screen.orientation != lastOri)
		{
			Autosize();
		}
	}

}