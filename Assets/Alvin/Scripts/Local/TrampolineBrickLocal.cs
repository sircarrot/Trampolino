using UnityEngine;
using System.Collections;

public class TrampolineBrickLocal : MonoBehaviour
{
    public float bounceForce = 10;
    public enum type
    {
        P1, P2
    }
    public type TrampolineType = new type();
    public bool permanent;
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //Debug.Log("boing");

        if (col.gameObject.tag == "Player")
        {
            if(TrampolineType == type.P1)
            col.rigidbody.velocity = bounceForce * transform.up;
            else
            col.rigidbody.velocity = bounceForce * -1 * transform.up;
            if (permanent == false)
            {
                Destroy(this.gameObject);
            }

        }
    }
}