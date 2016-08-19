using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour
{
    public enum type
    {
        Add, Speed, Shield
    }
    public type powerType = new type();
    public DrawLine _gameMaster;
    public float buffTime;
    private GameObject player;
    // Use this for initialization
    void Start()
    {
        _gameMaster = GameObject.Find("_gameMaster").GetComponent<DrawLine>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if(powerType == type.Add)
            {
                _gameMaster.allowedmax = 4;
                _gameMaster.AddpoweredUp = true;
                _gameMaster.Addpowertime = buffTime;
                Destroy(this.gameObject);
            }
            if (powerType == type.Shield)
            {
                _gameMaster.shielded = true;
                Destroy(this.gameObject);
            }
            if (powerType == type.Speed)
            {
                col.rigidbody.velocity = 50 * col.transform.up;
                player = col.gameObject;
                StartCoroutine(speedPower());
                this.GetComponent<Collider2D>().enabled = false;
                this.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }
 
    IEnumerator speedPower()
    {
        player.gameObject.GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(4);
        player.gameObject.GetComponent<Collider2D>().enabled = true;
        Destroy(this.gameObject);
    }
}
