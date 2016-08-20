using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class checkpointScript : MonoBehaviour {

    public GameObject mainCamera;
    public int score;

    // Use this for initialization
    void Awake()
    {
        gameObject.transform.localScale = new Vector3 (0,0,0);
        gameObject.GetComponent<Text>().CrossFadeAlpha(0.5f, 0f, true);
    }
    void Start () {
        score = 0;
    }

    // Update is called once per frame
    void Update () {
        if(Mathf.FloorToInt(mainCamera.transform.position.y / 100f) > score)
        {
            Debug.Log(Mathf.FloorToInt(mainCamera.transform.position.y / 100f));
            score = Mathf.FloorToInt(mainCamera.transform.position.y / 100f);
            StartCoroutine(DisplayDistance(score));
        }
    }

    IEnumerator DisplayDistance(int score)
    {
        gameObject.GetComponent<Text>().text = (score * 100).ToString();
        for(int i = 0; i < 45; i++)
        {
            gameObject.transform.localScale += new Vector3(1.5f/45, 1.5f/45, 0); 
            yield return new WaitForEndOfFrame();
        }
        gameObject.GetComponent<Text>().CrossFadeAlpha(0, 0.5f, true);
        yield return new WaitForSeconds(0.5f);
    }
}
