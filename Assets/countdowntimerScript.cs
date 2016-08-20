using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class countdowntimerScript : MonoBehaviour {

    public Text LargeCountdownTime;
    public float timer;
    public bool ingame = true;

    private bool isCoroutineExecuting = false;


    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (ingame)
        {
            timer -= Time.deltaTime;
            int minutes = (int)timer / 60;
            int seconds = (int)(timer - minutes * 60);

            gameObject.GetComponent<Text>().text = minutes.ToString() + ":" + ((int)(seconds)).ToString("00");

            if (timer <= 4f)
            {
                StartCoroutine(TimeUpCountdown());
            }
        }
    }
    IEnumerator TimeUpCountdown()
    {
        if (isCoroutineExecuting) { yield break; }

        isCoroutineExecuting = true;

        for (int i = 3; i > 0; i--)
        {
            LargeCountdownTime.text = i.ToString();
            LargeCountdownTime.CrossFadeAlpha(1f, 0f, true);
            LargeCountdownTime.CrossFadeAlpha(0f, 1f, true);
            yield return new WaitForSeconds(1f);
        }
        gameObject.GetComponent<Text>().text = "0:00";
        LargeCountdownTime.text = "TIME UP";
        LargeCountdownTime.transform.localScale = new Vector3(0.5f, 0.5f, 1);
        LargeCountdownTime.CrossFadeAlpha(1f, 0f, true);
        yield return new WaitForSeconds(2f);
        LargeCountdownTime.CrossFadeAlpha(0f, 1f, true);
        yield return new WaitForSeconds(1f);

        ingame = false;

        isCoroutineExecuting = false;
    }

}
