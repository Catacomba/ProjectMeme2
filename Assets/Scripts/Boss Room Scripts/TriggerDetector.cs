using UnityEngine;
using System.Collections;

public class TriggerDetector : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponentInParent<movement>().way == true) //Prever WAY v scripti Movement,
        {
            Debug.Log("Zaznal way");
            other.GetComponentInParent<movement>().way = false; //Poišče scripto movement, ter v njej nastavi Way, ki je smer
        }
        else
        {
            Debug.Log("False way");
            other.GetComponentInParent<movement>().way = true;
        }
    }
    // Update is called once per frame
    void Update () {
	
	}
}
