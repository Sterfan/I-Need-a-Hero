using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    public GameObject ragdoll;
    public GameObject[] bodyParts;
    public RunnerCharacterController cc;
    public CameraFollow_SS cam;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            Debug.Log("Eat my healthy butt!");
            //SceneManager.LoadScene("Sidescroller");
            foreach(GameObject bp in bodyParts)
            {
                bp.SetActive(false);
            }
            ragdoll.SetActive(true);
            cam.alive = false;
        }
    }
}
