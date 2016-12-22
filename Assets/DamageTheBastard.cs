using UnityEngine;
using System.Collections;

public class DamageTheBastard : MonoBehaviour {

    public float damage;

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Tigger: "+other.tag);
        if (this.tag == "Orozje" /*&& other.tag == "Enemy"*/)
        {
            Debug.Log("Triggered... attack");
            other.GetComponent<DMG_Detector>().Entry_Dmg = damage;
            other.GetComponent<DMG_Detector>().gotDmged = true;
        }
    }
}
