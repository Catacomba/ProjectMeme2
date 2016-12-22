using UnityEngine;
using System.Collections;

public class Placeholder_Trigger_Script : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
    public bool hasAlreadyEntered = false;
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        hasAlreadyEntered = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasAlreadyEntered == true)
        {
            foreach (GameObject kocka in GameObject.FindGameObjectsWithTag("HiddenOverlay"))
            {
                Destroy(kocka.gameObject);
            }
        }
    }
}
