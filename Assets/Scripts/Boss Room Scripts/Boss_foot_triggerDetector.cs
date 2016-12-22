using UnityEngine;
using System.Collections;

public class Boss_collision_turner : MonoBehaviour {
    public bool BossWay;
	// Use this for initialization
	
    void OnTriggerEnter(Collider col)
    {
        BossWay = GetComponentInParent<movement>().way;
        Debug.Log("Zaznal Trigger");
        if (BossWay)
            GetComponentInParent<movement>().way = false;
        else
            GetComponentInParent<movement>().way = true;
    }
	
	// Update is called once per frame
	
}
