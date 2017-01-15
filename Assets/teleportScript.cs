using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class teleportScript : MonoBehaviour {
    public string sceneName;
    // Use this for initialization
    void Start () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("LOwdam sceno");
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
