using UnityEngine;
using System.Collections;

public class MoveTorwardsPlayer2 : MonoBehaviour
{
    public Vector3 stageDimensions;
    public GameObject mainCamera;
    float playerPosition;
    // Use this for initialization
    void Start ()
    {
        stageDimensions = mainCamera.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        Debug.Log((stageDimensions.y * 1)-1.2);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 2)
        {
            return;
        }
        foreach (Touch touch in Input.touches)
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            Vector2 myPostion = gameObject.GetComponent<Rigidbody2D>().position;

            if (Mathf.Abs(touchPos.x - myPostion.x) <= 2)
            {
                myPostion.x = Mathf.Lerp(myPostion.x, touchPos.x, 10);
                myPostion.x = Mathf.Clamp(myPostion.x, -stageDimensions.x, stageDimensions.x);
                gameObject.GetComponent<Rigidbody2D>().position = myPostion;
            }
        }
    }
}
