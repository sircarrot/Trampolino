using UnityEngine;
using System.Collections;

public class MoveTorwards : MonoBehaviour
{
    float playerPosition;
    // Use this for initialization
    void Start ()
    {
	
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if(Camera.main.ScreenToWorldPoint(Input.mousePosition).y < -3.2f)
            {
                playerPosition = transform.position.x;
                float mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
                //Debug.Log(mousePos);
                float newPlayerPosition = Mathf.Lerp(playerPosition, mousePos, Time.deltaTime * 5);
                if (playerPosition != newPlayerPosition)
                {
                    transform.position = new Vector3(newPlayerPosition, transform.position.y, transform.position.z);
                }
            }
        }
    }
}
