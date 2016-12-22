using UnityEngine;
using System.Collections;

public class DMG_Detector : MonoBehaviour {
    public double Entry_Dmg;
    public bool gotDmged;    
    public HealthBarScript hpScript;
	// Use this for initialization
	void Start () {
	
	}
    // Update is called once per frame
    void Update () {
        if (gotDmged)
        {
            hpScript.dmgTaken = (float)Entry_Dmg;
            hpScript.gotDamaged = gotDmged;
        }
        
	}
}
