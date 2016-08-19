using UnityEngine;
using System.Collections;

public class cameraTrack : MonoBehaviour {
    public Transform player;
    float playerHeight;

    // Update is called once per frame
    void Update()
    {
        playerHeight = player.position.y;
        float currentCameraHeight = transform.position.y;
        float newHeightOfCamera = Mathf.Lerp(currentCameraHeight, playerHeight, Time.deltaTime * 100);
        if (playerHeight > currentCameraHeight)
        {
            transform.position = new Vector3(transform.position.x, newHeightOfCamera, transform.position.z);
        }
    }
}
