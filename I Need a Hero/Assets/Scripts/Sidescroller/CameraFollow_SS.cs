using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow_SS : MonoBehaviour
{
    public Transform player;

    float camOffset;


    void Start()
    {
        camOffset = transform.position.x - player.position.x;
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(player.position.x + camOffset, transform.position.y, transform.position.z);
    }

}
