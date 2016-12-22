using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{

    //nastavi tag igralcevega orozja na Orozje, katerega bodo enemy-ji zaznavali za damage

    public double attackDamage;
    public string animationName;
    private GameObject orozje;
    private Animator anim;


    // Use this for initialization
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        orozje = GameObject.Find("Sword");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (anim.GetCurrentAnimatorStateInfo(0).IsName(animationName))
        {
            orozje.tag = "Orozje";
        }
        else {
            orozje.tag = "Untagged";
        }
    }
}