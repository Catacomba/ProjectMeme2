using UnityEngine;
using System.Collections;

public class ConfessionBearScript : MonoBehaviour {

    public Sprite idle;
    public Sprite attack;

    public string textBeforeAttack; 
    public float attackTimer;
    public float attackRange;
    public float attackPrepTimer; //kdaj bo napadel, ne more prekinit napada

    public GameObject potato;

    private bool isAttacking; //da se napad ne prekine, ko gre player iz obmocja razdalje za napad
    private float timeLeft;

    private GameObject player;
    private Canvas canvas;



    // Use this for initialization
    void Start() {
        timeLeft = attackTimer;
        isAttacking = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (!isAttacking)
        {
            Debug.Log("Time left: " + timeLeft );
            if (timeLeft <= 0.0 && (attackRange > Vector2.Distance(player.transform.position, transform.position)))
            {
                Debug.Log("Vorks?");
                isAttacking = true;
                timeLeft = attackPrepTimer;
            }
        }
        else {
            //izpis napisa
            canvas.enabled = true;
            if (timeLeft < 1.0) {
                GetComponent<SpriteRenderer>().sprite = attack;
            }

            if (timeLeft <= 0.0) {
                //napad
                
                firePotato();
                GetComponent<SpriteRenderer>().sprite = idle;
                isAttacking = false;
                timeLeft = attackTimer;
            }
        }
        timeLeft -= Time.deltaTime;
    }

    void firePotato() {
        Vector2 potatoPoz = new Vector2(transform.position.x + (float)0.4, transform.position.y + (float)0.3);

        Instantiate(potato, potatoPoz, transform.rotation);
    }
}
