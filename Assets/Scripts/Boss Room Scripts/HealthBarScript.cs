using UnityEngine;
using System.Collections;

public class HealthBarScript : MonoBehaviour {
    public HealthBarTriggerScript parentScript;
    public DMG_Detector detector;
    public float healthPercentage = 100;
    public float scale_x;
    public float scale_y;
    public float scale_z;
    public float dmgTaken;
    public float healthScaler;
    public float healthScaler_changer;
    public float hp = 2000;
    public bool gotDamaged;
    public bool overlapPreventer;
    // Use this for initialization
    void Start () {
        overlapPreventer = true;
        parentScript = this.GetComponentInParent<HealthBarTriggerScript>();
        dmgTaken = 0;
        scale_y = this.transform.localScale.y;
        scale_z = this.transform.localScale.z;
        healthScaler_changer = healthScaler;
        healthScaler = hp / (hp - dmgTaken);
        scale_x = (float)this.transform.localScale.x * healthScaler;
    }
	
	// Update is called once per frame
	void Update () {
        gotDamaged = parentScript.gotDamaged;
        dmgTaken = parentScript.dmgTaken;
        if (gotDamaged == false)
        {
            overlapPreventer = true;
        }
        if (gotDamaged && overlapPreventer)
        {
            healthScaler = (hp - dmgTaken) / hp;
            hp = hp - dmgTaken;
            if (hp < 0)
                hp = 0.01f;
            scale_x = (float)this.transform.localScale.x * healthScaler;
            if (scale_x < 0)
                scale_x = 0;
            overlapPreventer = false;
            parentScript.gotDamaged = false;
            detector.gotDmged = false;
        }
        this.transform.localScale = new Vector3(scale_x, scale_y, scale_z);
    }
}
