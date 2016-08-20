using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class brickScoreScript : MonoBehaviour {

    public int score;


    public void update()
    {
        gameObject.GetComponent<Text>().text = score.ToString();
    }
}
