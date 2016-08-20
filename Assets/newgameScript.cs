using UnityEngine;
using System.Collections;

public class newgameScript : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
    public void retry()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
