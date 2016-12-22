using UnityEngine;
using System.Collections;

public class SAP : MonoBehaviour {

    public float razlika;
    public float slidingSpeed;
    public float moveSpeed;
    public float attackRange;
    public GameObject banana;
    public float bananaTimer;

    bool desnoObrnjen=true;
    int move;
    bool isSliding;
    float hitrost;
    float timeLeftBanana;
    Vector2 sliding;

    GameObject player;
    Rigidbody2D rb2d;
    Animator anim;


	// Use this for initialization
	void Start () {
        timeLeftBanana = bananaTimer;
        isSliding = false;
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
	

    void FixedUpdate()
    {
        if (rb2d.transform.position.x - player.transform.position.x < 0)
        {
            move = 1;
        }
        else
        {
            move = -1;
        }

        if (Mathf.Abs(rb2d.transform.position.y - player.transform.position.y) < razlika && !isSliding)
        {
            //slide attack
            isSliding = true;
            anim.SetTrigger("SlideAttack");
            hitrost = slidingSpeed * move;
        }
        else
        {
            if (isSliding)
            {
                gameObject.tag = "SlidingAttack";
                anim.SetBool("IsSliding", true);
                if (Mathf.Abs(rb2d.transform.position.x - player.transform.position.x) > 1)
                {
                    sliding = new Vector2(hitrost, rb2d.velocity.y);
                    rb2d.velocity = sliding;
                }
                else
                {
                    
                    sliding = new Vector2(0, rb2d.velocity.y);
                    isSliding = false;
                    anim.SetBool("IsSliding", false);
                }
                
            }
            else
            {
                
                sliding = new Vector2(moveSpeed * move, rb2d.velocity.y);
                if (attackRange < Vector2.Distance(player.transform.position, transform.position))
                {
                    rb2d.velocity = sliding;

                    //OBRACANJE z FLIP()
                    if (move > 0 && !desnoObrnjen)
                        Flip();
                    else if (move < 0 && desnoObrnjen)
                        Flip();
                }
                else
                {
                    if(timeLeftBanana <= 0.0)
                    {
                        FireBanana();
                        timeLeftBanana = bananaTimer;
                    }
                    
                }

            }

        }

        timeLeftBanana -= Time.deltaTime;


    }

    //Funkcija za obracanje
    void Flip()
    {
        desnoObrnjen = !desnoObrnjen;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void FireBanana() {
        Vector2 bananaPoz = new Vector2(transform.position.x + (float)0.4, transform.position.y + (float)0.3);
        
        Instantiate(banana, bananaPoz, transform.rotation);
    }
}
