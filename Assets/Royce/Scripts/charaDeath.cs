using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class charaDeath : MonoBehaviour {

    public GameObject MainCamera;
    //public bool dead = false;
    public GameObject GameOverCanvas;
    public Text Score;
    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update() {
        if (MainCamera.transform.position.y - gameObject.transform.position.y > 4.5f)
        {
            StartCoroutine(WaitDeath());
        }
    }
    IEnumerator WaitDeath()
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            //Play death sound
            yield return new WaitForSeconds(1f);
            GameOverCanvas.SetActive(true);
            Score.text = MainCamera.transform.position.y.ToString(".00");
        }
}

