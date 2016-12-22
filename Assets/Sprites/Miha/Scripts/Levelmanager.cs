using UnityEngine;
using System.Collections;

public class Levelmanager : MonoBehaviour {

	float s = 1.0F;
	AudioListener main;

    public Transform mainMenu, optionMenu, volslider;
    public GameObject fgm, fbm;

	void Start ()
	{
        fgm.SetActive(false);
        fbm.SetActive(true);
        main = Camera.main.GetComponent<AudioListener> ();
	}

	void Update ()
	{
		//main.audio.volume = 5;
	}


	public void LoadScene(string name)
	{
		Application.LoadLevel (name);
	}

	public void ExitGame(bool confirmBox)
	{
		Application.Quit();
	}

	public void OptionsMenu(bool clicked)
	{
		if (clicked == true) 
		{
			optionMenu.gameObject.SetActive (clicked);
			mainMenu.gameObject.SetActive (false);
		}

		else 
		{
			optionMenu.gameObject.SetActive (clicked);
			mainMenu.gameObject.SetActive (true);
		}
	}

	public void DoConfirmQuitYes()
	{
		Application.Quit();
	}

	public void OnGUI()
	{
		s = GUI.HorizontalSlider (new Rect (0, 0, 256, 32), s, 0.0F, 1.0F);
	}

    public void OnMouseEnter()
    {
        fbm.SetActive(false);
        fgm.SetActive(true);
    }

    public void OnMouseExit()
    {
        fbm.SetActive(true);
        fgm.SetActive(false);
    }

}