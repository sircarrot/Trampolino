using UnityEngine;
using System.Collections;

public class Puck : MonoBehaviour
{
    public int rand;
    // Use this for initialization
    void Start()
    {
        rand = Random.Range(1, 2);
        if (rand == 0)
        {
            this.gameObject.GetComponent<Rigidbody2D>().velocity = 5 * transform.up;
        }
        else
        {
            this.gameObject.GetComponent<Rigidbody2D>().velocity = -5 * transform.up;
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //col.gameObject.SetActive(false);
        }
    }
}
