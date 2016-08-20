using UnityEngine;
using System.Collections;

public class charaUpdateScript : MonoBehaviour {

    public Sprite IdleSprite;
    public Sprite JumpSprite;

    public Pause pauseScript;
    private bool jumping = false;
    private float lasty;
    private float cury;

	// Use this for initialization
	void Start () {
        lasty = 0;
        cury = 0;
	}
	
	// Update is called once per frame
	void Update () {
        cury = gameObject.transform.position.y;
        if(lasty>cury)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = IdleSprite;
            jumping = false;
        }
        else if(lasty<cury)
        {
            if (!jumping) { /*Play Bounce sound */}
            jumping = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = JumpSprite;
        }
        lasty = cury;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // WILL RUN EVEN IF DEAD, BUG NEED TO BE FIXED
            if (pauseScript.paused == false)
            { pauseScript.pause(); }
            else
            { pauseScript.unPause(); }
        }
    }
}
