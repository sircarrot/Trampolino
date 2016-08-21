using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pause : MonoBehaviour {

    public GameObject PauseCanvas;
    public Text CountdownScreen;
    public bool paused;

	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void pause()
    {
        if(paused)
        {
            PauseCanvas.SetActive(false);
            Time.timeScale = 1.0f;
            paused = false;
        }
        
        else
        {
            PauseCanvas.SetActive(true);
            Time.timeScale = 0.0f;
            paused = true;
        }

    }
    public void unPause()
    {
        PauseCanvas.SetActive(false);;
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        for(int i = 3; i>0; i--)
        {

            CountdownScreen.text = i.ToString();
            CountdownScreen.CrossFadeAlpha(1, 0f, true);
            CountdownScreen.CrossFadeAlpha(0,1f,true);
            float pausedtime = Time.realtimeSinceStartup;
            while (Time.realtimeSinceStartup - pausedtime <= 1)
            { yield return null; }
        }
        CountdownScreen.text = "Start!";
        CountdownScreen.CrossFadeAlpha(1, 0f, true);
        pause();
        CountdownScreen.CrossFadeAlpha(0, 1f, true);
        yield return new WaitForSeconds(1f);
        CountdownScreen.text = "";
    }

    public void MainMenu()
    {
        //Main Menu
        Application.LoadLevel(0);
    }

}
