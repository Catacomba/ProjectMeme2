using UnityEngine;
using System.Collections;
using System.Threading;

public class LevelOneScript : MonoBehaviour {
    string message = "";
    string DialogueMessage = "";
    bool msg = false;
    bool dialogue = false;
    public GameObject[] Mexicans;
    private Vector3 A;
    private Vector3 B;
    //Use this for initialization
    void Start () {
        GameObject.FindGameObjectWithTag("BridgeParts").GetComponent<Rigidbody2D>().isKinematic = true;
        Mexicans = GameObject.FindGameObjectsWithTag("Mexican");
        for(int i = 0; i < 3; i++)
        {
            Mexicans[i].transform.localScale = new Vector3(0, 0, 0);
        }
        DialogueMessage = "We no pay for that wall, ese!";
        //Bridge = GameObject.FindGameObjectsWithTag("BridgeParts");
    }
	
	// Update is called once per frame
	void Update () {
        OnGUI();
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
       // Debug.Log("collde");
        if (this.tag == "SecretMSG1")
        {
            msg = true;
            //Debug.Log("Collidede with trigger.");
            message = "To the Land of the Free...";
        }

        else if (this.tag == "SecretMSG2")
        {
            msg = true;
            message = "...where eagles fly and immigrants flee...";
        }

        else if (this.tag == "SecretMSG3")
        {
            msg = true;
            message = "...to become what they could never be.";
        }

        else if(this.tag == "BridgeTrap")
        {
            GameObject.FindGameObjectWithTag("BridgeParts").GetComponent<Rigidbody2D>().isKinematic = false;
            //foreach(GameObject part in Bridge)
            //{
            //    Destroy(part);
            //}
        }

        else if(this.tag == "SecretTriggerMEX")
        {
            Mexicans = GameObject.FindGameObjectsWithTag("Mexican");
            for(int i = 0; i < 3; i++)
            {
                //Debug.Log("Collidede with trigger.");
                Mexicans[i].transform.localScale = new Vector3((float)0.25, (float)0.25, (float)0.25);
                Mexicans[i].GetComponent<Rigidbody2D>().velocity = new Vector2((float)2.4, 0);
            }      
        }

        for (int i = 0; i < 3; i++)
        {
            if(other.tag == "Mexican")
            {
                GameObject trig = GameObject.FindGameObjectWithTag("SecretTriggerMEX");
                trig.GetComponent<BoxCollider2D>().enabled = false;
                Mexicans[i].GetComponent<Rigidbody2D>().velocity = new Vector2((float)0, 0);
                dialogue = true;            
            }
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        message = "";     
        msg = false;
    }

    public void OnGUI()
    {
        if(msg == true)
        {
            GUI.color = Color.cyan;
            GUI.Button(new Rect(490, 230, 245, 38), message);
        }

        if(dialogue == true)
        {
            StartCoroutine(DisapearBoxAfter((float)2.5));
            GUI.color = Color.cyan;
            GUI.Button(new Rect(450, 230, 245, 38), DialogueMessage);
            
            //GUI.Label(new Rect(Screen.width / 3, Screen.height / 3, 100, 100), DialogueMessage);
        }
    }

    IEnumerator DisapearBoxAfter(float wait)
    {
        // suspend execution for waitTime seconds
        yield return new WaitForSeconds(wait);
        dialogue = false;
    }
}
