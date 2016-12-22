using UnityEngine;
using System.Collections;

public class Boss_foot_triggerDetector : MonoBehaviour
{
    public bool BossWay;
    // Use this for initialization

    void OnTriggerEnter2D(Collider2D col)
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
