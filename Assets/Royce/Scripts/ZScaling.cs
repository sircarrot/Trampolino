using UnityEngine;
using System.Collections;

public class ZScaling : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //Default aspect ratio = 9:16
        Debug.Log(Camera.main.aspect);
        Debug.Log(Camera.main.aspect/ (9f/16f));
        Camera.main.orthographicSize /=  (Camera.main.aspect / (9f/16f));

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
