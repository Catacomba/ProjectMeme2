using UnityEngine;
using System.Collections;

public class HealthBarPositioner : MonoBehaviour {

    public Rigidbody2D bossbody;
    public Vector3 bossVector;
    public Vector3 healthVector = new Vector3((float)-0.36, (float)4.25, 0);
    // Use this for initialization
    void Start()
    {
        healthVector = new Vector3((float)-0.36, (float)4.25, 0);
    
    }

    // Update is called once per frame
    void Update()
    {
        bossVector = bossbody.transform.position;//vector za premikanje healthbara
        this.transform.position = bossVector + healthVector;//Premik healthbara, tako da sledi bossu
    }
}
