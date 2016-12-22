using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public float speed;
    public float destroyDistance;
    GameObject player;
    Vector2 travel;
    Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        travel = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
        rb2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        rb2d.AddForce(travel * speed);
        if (Mathf.Abs(Vector2.Distance(player.transform.position, transform.position))>destroyDistance)
        {
            Destroy(this.gameObject);
        }
	}

}
