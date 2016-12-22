using UnityEngine;
using System.Collections;

public class AMS : MonoBehaviour {

	Animator anim;
	Rigidbody2D rb2d;

	public float premik;
	Vector2 lokacija;
	Vector2 move;


	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		Vector2 player = GameObject.FindGameObjectWithTag ("Player").transform.position;
		lokacija = transform.position;
		if ( Mathf.Abs(lokacija.x - player.x)<0.1) 
		{
            move = new Vector2(0, 0);
            rb2d.velocity = move;
            gameObject.tag = "EnemyAttack";
            anim.SetTrigger("Attack");

        }
        else 
		{
			if (player.x > lokacija.x)
			{
				move = new Vector2 (premik, 0);
			}
			else
			{
				move = new Vector2 (premik*(-1), 0);
			}
		}
		rb2d.velocity = move;
	}
 

}
