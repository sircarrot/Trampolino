using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

    public bool paused;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void pause()
    {
        if(paused)
        {
            Time.timeScale = 1.0f;
            paused = false;
        }
        
        else
        {
            Time.timeScale = 0.0f;
            paused = true;
        }

    }
    public void unPause()
    {
        
    }

}
