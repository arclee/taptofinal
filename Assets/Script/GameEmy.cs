using UnityEngine;
using System.Collections;

public class GameEmy : MonoBehaviour {
	
	public int MaxHP = 100;
	public int HP = 0;

	public TextMesh hpText;
	// Use this for initialization
	void Start ()
	{		
		HP = MaxHP;
		hpText.text = HP.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Hurt(int damage)
	{
		HP -= damage;
		if (HP <= 0)
		{
			HP = 0;
			Dead();
		}
		hpText.text = HP.ToString();
	}

	public void Dead()
	{
		HP = MaxHP;
	}


}
