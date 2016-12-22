using UnityEngine;
using System.Collections;

public class DamageTheBastard : MonoBehaviour {

    public float damage;

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Tigger: "+other.tag);
        if (this.tag == "Orozje" && other.tag == "Enemy")
        {
            Debug.Log("Triggered... attack");
            other.GetComponentInChildren<HealthBarTriggerScript>().dmgTaken = damage;
            other.GetComponentInChildren<HealthBarTriggerScript>().gotDamaged=true;
        }
    }
}
