using UnityEngine;
using System.Collections;

public class GamePlayer : MonoBehaviour {

	public int damage = 1;
	
	public int MaxHp = 100;
	public int hp = 100;
	public int MaxSp = 100;
	public int sp = 100;

	//set
	public BoxCollider2D bc2d;
	public Camera tartegCamera;
	public GameEmy targetEmySC;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if (Input.touchCount > 0)
		{
			for (int i = 0; i < Input.touchCount; i++)
			{
				Touch t = Input.GetTouch(i);

				if (t.phase == TouchPhase.Began)
				{
					//touch pos.
					Vector2 touchWorldPos = tartegCamera.ScreenToWorldPoint(new Vector2 (t.position.x, t.position.y));

					if (bc2d.OverlapPoint(touchWorldPos))
					{
						//if (targetEmySC != null)
						{
							targetEmySC.Hurt(damage);
						}
					}
				}
			}
		}
	
	}



}
