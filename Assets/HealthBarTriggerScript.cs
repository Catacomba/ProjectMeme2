using UnityEngine;
using System.Collections;

public class HealthBarTriggerScript : MonoBehaviour {
    public HealthBarScript hpScript;
    public float dmgTaken = 0;
    public bool gotDamaged = false;
    public float hp = 2000;
    public float hp_3secBack;
    public float delayBuffer = 1f;
    public bool dropDelay=false;
    public int delayer = 0;
    public bool stopMakingRutines=false;
    // Use this for initialization
    void Start () {
        hp_3secBack = hp;
    }
	
    IEnumerator delayDroper()
    {
        if(hp < hp_3secBack)
        {
            stopMakingRutines = true;
            dropDelay = false;
            hp_3secBack = hp;
            yield return new WaitForSeconds(delayBuffer);
        }
        else if(hp==hp_3secBack)
            dropDelay = true;
        stopMakingRutines = false;

    }
	// Update is called once per frame
	void Update () {
        hp = hpScript.hp;
        if(!stopMakingRutines)
            StartCoroutine(delayDroper());
	}
}
