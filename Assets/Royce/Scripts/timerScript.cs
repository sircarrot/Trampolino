using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class timerScript : MonoBehaviour {

    public GameObject poweruptimer;
    public float timer;

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Text>().text = timer.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        if (timer <= 0)
        { poweruptimer.SetActive(false); }
        timer -= Time.deltaTime;
        gameObject.GetComponent<Text>().text = (timer).ToString("0");

	}
}
