using UnityEngine;
using System.Collections;
using System.Timers;

public class Trigger : MonoBehaviour {

    public bool hasAlreadyEntered = false;
	// Use this for initialization
    void Start()
    {
    }
    /* void DestroyWhiteBlock()
     {
         Destroy(GameObject.FindGameObjectWithTag("HiddenDoorBlack"));
     }
 */

    //Rutina, ki deleta kocke, stevec pomeni koliko kock naenkrat, kocke imajo isti tag, deleta kocke v intervalu (sekundah) ki pise v waitforsecond
    IEnumerator TestCoroutine()
    {
        int stevec = 3;
        int i = 0;
        foreach (GameObject kocka in GameObject.FindGameObjectsWithTag("HiddenDoorWhite"))
        {
            if(i%stevec == 0)
                yield return new WaitForSeconds(1);
            Destroy(kocka.gameObject);
            i++;
        }
    }
    void OnTriggerEnter2D(Collider2D other) {
		hasAlreadyEntered = true;
	}
    
    // Update is called once per frame
    void Update () {
        if(hasAlreadyEntered == true)
        {
            foreach (GameObject kocka in GameObject.FindGameObjectsWithTag("HiddenDoorBlack"))
			{
					Destroy(kocka.gameObject);
			}
			foreach(GameObject kocka in GameObject.FindGameObjectsWithTag("HiddenDoorWhite"))
			{
				
				Rigidbody2D gameObjectsRigidBody = kocka.gameObject.AddComponent<Rigidbody2D> ();
				gameObjectsRigidBody.mass = 5;
            }
            StartCoroutine(TestCoroutine());
        }
    }
}
