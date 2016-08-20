using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{
    public enum type
    {
        Spike, Mover, Shooter, MoverShooter
    }
    public type EnemyTyoe = new type();
    private GameObject player;
    public DrawLine _gameMaster;
    // Use this for initialization
    void Start()
    {
        _gameMaster = GameObject.Find("_gameMaster").GetComponent<DrawLine>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if(_gameMaster.shielded == true)
            {
                col.rigidbody.velocity = 5 * transform.up;
                _gameMaster.shielded = false;
            }
            else
            {
                Destroy(col.gameObject); // Player death
            }
        }
    }
}
