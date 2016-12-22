using UnityEngine;
using System.Collections;

public class HPbar_adjuster : MonoBehaviour
{
    public HealthBarScript hpscript;
    public HealthBarTriggerScript hptrigger;
    public Vector3 adjust_Vector;
    public Vector3 initialVector;
  //  public bool delay_go;
    // Use this for initialization
    void Start() 
    {
        initialVector = hpscript.transform.localScale;
        adjust_Vector = hpscript.transform.localScale;
    }
    IEnumerator adjustDelay()
    {
        float scaler= 1f;//Scaler za vektor zamika
            while (adjust_Vector.x < initialVector.x)//loop za spremembe
            {
                yield return new WaitForSeconds(0.0001f);
                scaler -= 0.0001f;
                this.transform.localScale = new Vector3(initialVector.x * scaler, initialVector.y, initialVector.z);
                initialVector = new Vector3(initialVector.x * scaler, initialVector.y, initialVector.z);
            }
        initialVector = adjust_Vector;
        adjust_Vector = hpscript.transform.localScale;
        scaler = 1f;
        
    }
    void Update()
    {
        if(hptrigger.dropDelay)
            StartCoroutine(adjustDelay());//Klicemo podrutino
    }
}