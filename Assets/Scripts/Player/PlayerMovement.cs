using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float speed;
	public float jumpHeigth;
    bool desnoObrnjen = true;

	public Transform groundPoint;
	public float radius;
	public LayerMask groundMask;

    //Sound
    public AudioClip clipAttack;
    public AudioClip clipUpvote;
    public AudioClip clipJump;
    public AudioClip clipUlti;
    public AudioClip clipGetHit;
    public AudioClip clipPickHP;
    public AudioClip clipPickMP;
    private AudioSource src;
    //end Sound

    bool isGrounded;

	Rigidbody2D rb2d;
	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rb2d = GetComponent<Rigidbody2D> ();      
    }

    void Awake()
    {
        src = GetComponent<AudioSource>(); //Dobimo AudioSource component
    }

	void Update(){

	}

	// Update is called once per frame
	void FixedUpdate () {
		
		float move = Input.GetAxis ("Horizontal"); //prebere v katero smer gre (1/0/-1)
		anim.SetFloat ("Move", Mathf.Abs (move*speed)); //nastavitev animacije k premiku
		Vector2 moveDir = new Vector2 (move*speed, rb2d.velocity.y); //nastavi premik
		rb2d.velocity = moveDir;

		isGrounded = Physics2D.OverlapCircle (groundPoint.position, radius, groundMask); //pogleda če je igralec na tleh
		anim.SetBool("InAir", !isGrounded);

		if (Input.GetKeyDown (KeyCode.Space) && isGrounded){
            src.PlayOneShot(clipJump, 0.5f);
            rb2d.AddForce (new Vector2 (0, jumpHeigth)); //skok igralca
		}

		//ATTACK ANIMATION
		if (Input.GetKeyDown (KeyCode.E)) {   
            src.PlayOneShot(clipAttack, 0.3f);
			anim.SetTrigger ("Attack");
		}

		if (Input.GetKeyDown (KeyCode.Alpha1)) {
            src.PlayOneShot(clipUpvote, 0.5f);
            anim.SetTrigger ("Like");
		}

		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			anim.SetTrigger ("Dislike");
		}

		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			anim.SetTrigger ("RainbowSwipe");
		}

		if (Input.GetKeyDown (KeyCode.Alpha4)) {         
            src.PlayOneShot(clipUlti, 0.5f);
            anim.SetTrigger ("Ulti");
		}



		//OBRACANJE z FLIP()
		if (move > 0 && !desnoObrnjen) 
			Flip ();
		else if (move < 0 && desnoObrnjen)
			Flip ();
	}

	//Funkcija za obracanje
	void Flip(){
		desnoObrnjen = !desnoObrnjen;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnDrawGizmos(){
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere (groundPoint.position,radius);

	}
}
