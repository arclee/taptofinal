using UnityEngine;
using System.Collections;

//using UnityEditor;

[ExecuteInEditMode]
public class GameRain : MonoBehaviour {

	Vector3[] vertices = new Vector3[]
	{
		new Vector3( 1, 1,  1),
		new Vector3( 1, -1, 1),
		new Vector3(-1, 1, 1),
		new Vector3(-1, -1, 1),
	};
	Vector2[] uv = new Vector2[]
	{
		new Vector2(1, 1),
		new Vector2(1, 0),
		new Vector2(0, 1),
		new Vector2(0, 0),
	};

	int[] triangles = new int[]
	{
		0, 1, 2,
		2, 1, 3,
	};

	public Texture[] textures;
	public MeshRenderer meshRender;
	public bool startRain = false;
	public float ticktime = 0.1f;
	public float currentTicktime = 0;
	public int currentTextureIndex = 0;

	void Start() 
	{
		Mesh mesh = new Mesh();
		GetComponent<MeshFilter>().mesh = mesh;
		mesh.vertices = vertices;
		mesh.uv = uv;
		mesh.triangles = triangles;
//		mesh.RecalculateNormals();
//		AssetDatabase.CreateAsset( mesh, "Assets/myQuad.asset");
//		AssetDatabase.SaveAssets();
	}

	void Update()
	{
		if (startRain)
		{
			currentTicktime -= Time.deltaTime;
			if (currentTicktime <= 0)
			{
				currentTicktime = ticktime - currentTicktime;
				currentTextureIndex++;
				currentTextureIndex = currentTextureIndex%textures.Length;
#if UNITY_EDITOR
				meshRender.sharedMaterial.SetTexture("_MainTex", textures[currentTextureIndex]);
#else
				meshRender.material.SetTexture("_MainTex", textures[currentTextureIndex]);
#endif
			}
		}
	}
}
