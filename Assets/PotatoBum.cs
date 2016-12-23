using UnityEngine;
using System.Collections;

public class PotatoBum : MonoBehaviour {

    private float timeBeforeDestruction;

    
    public float speed;
    public float destroyTime;
    public float explodeDistance;
    public AnimationClip animExp;

    float lastAnimation;

    GameObject player;
    Vector2 travel;
    Rigidbody2D rb2d;
    Animator anim;
    bool eksplozija;

    // Use this for initialization
    void Start()
    {
        eksplozija = false;
        player = GameObject.FindGameObjectWithTag("Player");
        travel = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        lastAnimation = animExp.length;
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.AddForce(travel * speed);
        if (Mathf.Abs(Vector2.Distance(player.transform.position, transform.position)) < explodeDistance || destroyTime < 0.0)
        {
            anim.SetTrigger("Explosion");
            eksplozija = true;
            rb2d.AddForce(travel);
        }
        Debug.Log(lastAnimation);
        if (eksplozija) {
            if (lastAnimation < 0.0) {
                Destroy(this.gameObject);
            }
            lastAnimation -= Time.deltaTime;
        }
        destroyTime -= Time.deltaTime;
        
    }
}
