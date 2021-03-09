using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climber : MonoBehaviour
{
    public float climbSpeed = 10f;
    public float strafeSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveUpwards();
        SideMovement();
    }

    void SideMovement()
    {
        if (Input.GetButton("Horizontal"))
        {
            transform.position += new Vector3(strafeSpeed * Input.GetAxisRaw("Horizontal"), 0, 0) * Time.deltaTime;
        }
    }

    void MoveUpwards()
    {
        transform.position += new Vector3(0, climbSpeed, 0) * Time.deltaTime;
    }
}
