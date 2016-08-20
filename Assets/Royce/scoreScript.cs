using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class scoreScript : MonoBehaviour {

    public GameObject mainCamera;
    float score = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        score = 20*(mainCamera.transform.position.y);
        gameObject.GetComponent<Text>().text = score.ToString("00000000");
	}
}
