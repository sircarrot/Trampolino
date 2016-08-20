using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class countdowntimerScript : MonoBehaviour {

    public GameObject EndGameCanvas;
    public GameObject PauseCanvas;
    public brickPlayerScore PlayerScore;
    public GameObject RetryButton;

    public Text P1;
    public Text P2;

    public Text LargeCountdownTime;
    public float timer;
    public bool ingame = false;


    private bool isCoroutineExecuting = false;

    void Awake()
    {
        //Time.timeScale = 0;
        //StartCoroutine(StartCountdown());
    }
    IEnumerator StartCountdown()
    {
        //2 seconds before start
        float pausedtime = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup - pausedtime <= 2)
        { yield return null; }

        //Countdown starts
        for (int i = 3; i > 0; i--)
        {
            LargeCountdownTime.text = i.ToString();
            LargeCountdownTime.CrossFadeAlpha(1, 0f, true);
            LargeCountdownTime.CrossFadeAlpha(0, 1f, true);
            pausedtime = Time.realtimeSinceStartup;
            while (Time.realtimeSinceStartup - pausedtime <= 1)
            { yield return null; }
        }

        ingame = true;
        Time.timeScale = 1;

        LargeCountdownTime.text = "START";
        LargeCountdownTime.CrossFadeAlpha(1f, 0f, true);
        LargeCountdownTime.CrossFadeAlpha(0f, 1f, true);
        yield return new WaitForSeconds(1f);
    }
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
        ingame = false;
        gameObject.GetComponent<Text>().text = "0:00";
        LargeCountdownTime.text = "TIME UP";
        //LargeCountdownTime.transform.localScale = new Vector3(0.5f, 0.5f, 1);
        Time.timeScale = 0;
        LargeCountdownTime.CrossFadeAlpha(1f, 0f, true);
        float pausedtime = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup - pausedtime <= 2)
        { yield return null; }
        LargeCountdownTime.CrossFadeAlpha(0f, 1f, true);
        pausedtime = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup - pausedtime <= 1)
        { yield return null; }


        EndGameCanvas.SetActive(true);
        if(PlayerScore.player1.score>PlayerScore.player2.score)
        {
            P1.text = "WINNER";
            P2.text = "LOSER";
            RetryButton.transform.localPosition += new Vector3(0,680,0);
        }
        else if (PlayerScore.player1.score < PlayerScore.player2.score)
        {
            P2.text = "WINNER";
            P1.text = "LOSER";
            RetryButton.transform.localPosition += new Vector3(0, -680, 0);
        }
        else
        {
            P1.text = "TIE";
            P2.text = "TIE";
        }



        isCoroutineExecuting = false;
    }
    
    public void pause()
    {
        Time.timeScale = 0;
        ingame = false;
        PauseCanvas.SetActive(true);
    }
    public void unpause()
    {
        PauseCanvas.SetActive(false);

        StartCoroutine(UnpauseCountdown());        
    }
    IEnumerator UnpauseCountdown()
    {
        //Countdown starts
        for (int i = 3; i > 0; i--)
        {
            LargeCountdownTime.text = i.ToString();
            LargeCountdownTime.CrossFadeAlpha(1, 0f, true);
            LargeCountdownTime.CrossFadeAlpha(0, 1f, true);
            float pausedtime = Time.realtimeSinceStartup;
            while (Time.realtimeSinceStartup - pausedtime <= 1)
            { yield return null; }
        }

        ingame = true;
        Time.timeScale = 1;

        LargeCountdownTime.text = "START";
        LargeCountdownTime.CrossFadeAlpha(1f, 0f, true);
        LargeCountdownTime.CrossFadeAlpha(0f, 1f, true);
        yield return new WaitForSeconds(1f);
    }
}
