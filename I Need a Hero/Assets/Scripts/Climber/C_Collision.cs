using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class C_Collision : MonoBehaviour
{
    public GameObject ragdoll;
    public GameObject[] bodyParts;

    bool hit = false;
    bool spawned = false;
    Climber climbScript;

    private void Start()
    {
        climbScript = GetComponent<Climber>();
    }

    //private void Update()
    //{
    //    if (hit && !spawned)
    //    {
    //        Instantiate(ragdoll, transform);
    //        hit = false;
    //        spawned = true;
    //    }
    //}

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
            hit = true;
            climbScript.alive = false;
        }
    }
}
