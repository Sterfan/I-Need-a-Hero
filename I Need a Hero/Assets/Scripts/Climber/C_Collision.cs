using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class C_Collision : MonoBehaviour
{
    public GameObject ragdoll;
    public GameObject[] bodyParts;


    Climber climbScript;

    private void Start()
    {
        climbScript = GetComponent<Climber>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            //SceneManager.LoadScene("Sidescroller");
            foreach (GameObject bp in bodyParts)
            {
                bp.SetActive(false);
            }
            //ragdoll.SetActive(true);
            climbScript.alive = false;
        }
    }
}
