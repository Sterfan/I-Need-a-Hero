using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow_SS : MonoBehaviour
{
    public Transform player;
    public float cameraEndX = -16.5f;

    float camOffset;


    void Start()
    {
        camOffset = transform.position.x - player.position.x;
    }

    private void LateUpdate()
    {
        //Debug.Log(transform.localPosition.x);
        if (transform.localPosition.x > cameraEndX)
        {
            transform.position = new Vector3(player.position.x + camOffset, transform.position.y, transform.position.z);
        }
    }

}
