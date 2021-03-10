using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimberFollow : MonoBehaviour
{
    public Transform player;
    Vector3 camOffset;
    // Start is called before the first frame update
    void Start()
    {
        camOffset = player.position - transform.position;
    }

    void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, player.position.y - camOffset.y, transform.position.z);
    }
}
