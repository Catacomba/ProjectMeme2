using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PortalRotate : MonoBehaviour {

    public int hitrost;
    public string sceneName;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }
    

    // Update is called once per frame
    void Update () {
        transform.Rotate(Vector3.back, Time.deltaTime * hitrost );
    }
}
