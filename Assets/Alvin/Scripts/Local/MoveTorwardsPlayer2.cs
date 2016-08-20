using UnityEngine;
using System.Collections;

public class MoveTorwardsPlayer2 : MonoBehaviour
{

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
            Vector2 myPostion = this.gameObject.GetComponent<Rigidbody2D>().position;

            if (Mathf.Abs(touchPos.y - myPostion.y) <= 0.8f)
            {
                myPostion.x = Mathf.Lerp(myPostion.x, touchPos.x, 10);
                //myPostion.x = Mathf.Clamp(myPostion.x, -stageDimensions.x, stageDimensions.x);
                gameObject.transform.position = myPostion;
            }
        }
    }
}
