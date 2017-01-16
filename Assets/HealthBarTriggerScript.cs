using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HealthBarTriggerScript : MonoBehaviour {
    public HealthBarScript hpScript;
    public DMG_Detector detector;
    public GameObject selectedObject;
    public float dmgTaken = 0;
    public bool gotDamaged = false;
    public float hp = 2000;
    public float hp_3secBack;
    public float delayBuffer = 1f;
    public bool dropDelay=false;
    public int delayer = 0;
    public bool stopMakingRutines=false;
    public string sceneName;
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
        if (hp <= 0)
        {
            if (sceneName != "")
            {
                SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
            }
            else {
                Destroy(selectedObject.gameObject);
            }
        }
        dmgTaken = (float)detector.Entry_Dmg;
        gotDamaged = detector.gotDmged;
        if(!stopMakingRutines)
            StartCoroutine(delayDroper());
    }
}
