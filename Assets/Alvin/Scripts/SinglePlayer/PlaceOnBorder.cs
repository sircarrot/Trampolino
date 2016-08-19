using UnityEngine;
using System.Collections;

public class PlaceOnBorder : MonoBehaviour {
    public Vector3 stageDimensions;
    public GameObject mainCamera;
    public float xPos;
    public enum type
    {
        left,right
    }
    public type posType = new type();
    // Use this for initialization
    void Start ()
    {
        stageDimensions = mainCamera.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        //Debug.Log(stageDimensions.x);
        if(posType == type.right)
        {
            xPos = (float)(stageDimensions.x + 0.1);
            transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
        }
        else if (posType == type.left)
        {
            xPos = (float)(stageDimensions.x *-1 - 0.1);
            transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
