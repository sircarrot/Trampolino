using UnityEngine;
using System.Collections;

public class TrampolineBrickLocal : MonoBehaviour
{
    public float bounceForce = 10;
    
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //Debug.Log("boing");

        if (col.gameObject.tag == "Player")
        {
            //col.rigidbody.AddForce(bounceForce * transform.up, ForceMode.VelocityChange);
            col.rigidbody.velocity = bounceForce * transform.up;
            
            Destroy(this.gameObject);

        }
    }
}