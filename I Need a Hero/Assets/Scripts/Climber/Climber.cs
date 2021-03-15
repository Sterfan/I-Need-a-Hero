using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Climber : MonoBehaviour
{
    public float climbSpeed = 10f;
    public float strafeSpeed = 5f;

    public float maxXL = -121f, maxXR = -3f;
    [HideInInspector] public bool alive = true;
    public string sceneName = "Final Scene";
    public GameObject m_ragdoll;
    GameObject ragdoll = null;
    public ClimberFollow cam;

    float gravity = 20f;
    float timer = 1f;

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            MoveUpwards();
            SideMovement();
        }

        if (!alive)
        {
            if (ragdoll == null)
            {
                ragdoll = Instantiate(m_ragdoll, transform);
                cam.player = ragdoll.transform;
            }
            Invoke("ReloadScene", 1f);
        }
    }

    void SideMovement()
    {
        if (Input.GetButton("Horizontal"))
        {
            transform.position += new Vector3(strafeSpeed * Input.GetAxisRaw("Horizontal"), 0, 0) * Time.deltaTime;
            transform.position = new Vector3 (Mathf.Clamp(transform.position.x, maxXL, maxXR),transform.position.y, transform.position.z);
        }
    }

    void MoveUpwards()
    {
        transform.position += new Vector3(0, climbSpeed, 0) * Time.deltaTime;
    }

    void FallDown()
    {
        transform.position -= new Vector3(0, gravity * timer, 0) * Time.deltaTime;
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
