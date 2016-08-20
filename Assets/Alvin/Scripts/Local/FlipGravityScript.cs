using UnityEngine;
using System.Collections;

public class FlipGravityScript : MonoBehaviour {

    public Vector3 stageDimensions;
    public GameObject mainCamera;
    public bool location;

    void Start()
    {
        stageDimensions = mainCamera.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        if (transform.position.y > (1 / 2) * stageDimensions.y)
        {
            location = true;
        }
        else
        {
            location = false;
        }
    }

    // Update is called once per frame
    void Update ()
    {
	    if(transform.position.y>(1/2)*stageDimensions.y)
        {
            if(!location)
            GetComponent<Rigidbody2D>().gravityScale = GetComponent<Rigidbody2D>().gravityScale * -1;
        }
        else
        {
            if(location)
            GetComponent<Rigidbody2D>().gravityScale = GetComponent<Rigidbody2D>().gravityScale * -1;
        }
	}
}
