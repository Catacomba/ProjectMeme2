using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {
    public bool way = true; //true = desno, false = desno
    public float mySpeed = 3.0f;
    public bool isMoving = true;
    public bool seJePremikal = false;
    public int rand;
    Animator anim;
    // Use this for initialization
    void Start () {
        anim = GetComponentInChildren<Animator>();
        StartCoroutine(WalkDecider());
    }
    IEnumerator WalkDecider()
    {
        while (true)
        {
            rand = Random.Range(0, 1000);
            if (isMoving && rand < 100)
                isMoving = false;
            else
                isMoving = true;
            if (isMoving)
                yield return new WaitForSeconds(1);
            else
                yield return new WaitForSeconds(Random.Range(3,8));
        }
    }
    // Update is called once per frame
    void Update () {
        if (isMoving)
        {
            seJePremikal = true;
            this.GetComponent<Rigidbody2D>().isKinematic = false;
            
            anim.SetBool("isWalking", true);
        }
        else
        {
            if (seJePremikal)
            {
                this.GetComponent<Rigidbody2D>().isKinematic = true;
                seJePremikal = false;
                this.GetComponent<Rigidbody2D>().isKinematic = false;
            }
            anim.SetBool("isWalking", false);
        }
        if (isMoving && way == true)
        {     
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-mySpeed, 0);
        }
        else if (isMoving && way == false)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(mySpeed, 0);
        }
        switch(way)
        {
            case true:
              this.GetComponent<Transform>().localScale = new Vector3(-1,1,1);
                break;
            case false:
              this.GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
                break;
        }
      //    this.GetComponent<ConstantForce2D>().force = new Vector2(0.1f, 0);*/
    }
}
