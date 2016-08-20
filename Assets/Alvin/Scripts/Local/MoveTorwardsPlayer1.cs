using UnityEngine;
using System.Collections;

public class MoveTorwardsPlayer1 : MonoBehaviour
{
    public Vector3 stageDimensions;
    public GameObject mainCamera;

    void Start()
    {
        stageDimensions = mainCamera.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
    }
    // Update is called once per frame
    void Update()
    {
        
        foreach (Touch touch in Input.touches)
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            Vector2 myPostion = this.gameObject.GetComponent<Rigidbody2D>().position;

            if (Mathf.Abs(touchPos.y - myPostion.y) <= 0.8f && touchPos.x <= stageDimensions.x - 1 && touchPos.x >= (stageDimensions.x * -1) + 1)
            {
                myPostion.x = Mathf.Lerp(myPostion.x, touchPos.x, 10);
                //myPostion.x = Mathf.Clamp(myPostion.x, -stageDimensions.x, stageDimensions.x);
                gameObject.transform.position = myPostion;
            }
        }
    }
}
