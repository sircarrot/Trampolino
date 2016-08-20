using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class charaDeath : MonoBehaviour {

    public GameObject MainCamera;
    public bool dead = false;
    public GameObject GameOverCanvas;
    public Text Score;
    public Text HighScore;

    // Use this for initialization
    void Start ()
    {
	
	}

    // Update is called once per frame
    void Update() {
        if (MainCamera.transform.position.y - gameObject.transform.position.y > 4.5f)
        {
            dead = true;
            StartCoroutine(WaitDeath());
        }
    }
    IEnumerator WaitDeath()
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            //Play death sound
            yield return new WaitForSeconds(1f);
            GameOverCanvas.SetActive(true);
            Score.text = MainCamera.transform.position.y.ToString("0");
            if(MainCamera.transform.position.y < PlayerPrefs.GetInt("Score"))
            {
                HighScore.text = PlayerPrefs.GetString("Score").ToString();
            }
            else
            {
                PlayerPrefs.GetInt("Score", Mathf.CeilToInt(MainCamera.transform.position.y));
                HighScore.text = MainCamera.transform.position.y.ToString("0");
            }
            
        }
}

