using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision3D : MonoBehaviour
{
    public GameObject[] playerParts;
    public GameObject ragdoll;
    public string sceneName = "Final Scene";
    public Transform[] collisionChecks;
    public LayerMask obstaclesMask;
    bool dead = false;
    RunnerCharacterController runnerCC;

    public AudioSource audioSource;

    private void Start()
    {
        runnerCC = GetComponent<RunnerCharacterController>();
    }




    private void Update()
    {
        if (Physics.CheckCapsule(collisionChecks[0].position, collisionChecks[1].position, 0.6f, obstaclesMask, QueryTriggerInteraction.Ignore))
        {
            runnerCC.alive = false;
            foreach (var part in playerParts)
            {
                part.SetActive(false);
            }
            if (!dead)
            {
                Instantiate(ragdoll, transform);
                audioSource.Play();
                Invoke("ReloadScene", 1f);
                dead = true;
            }

        }
    }

    //private void OnCollisionEnter(UnityEngine.Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Obstacle"))
    //    {
    //        foreach (var part in playerParts)
    //        {
    //            part.SetActive(false);
    //        }
    //        ragdoll.SetActive(true);
    //        Invoke("ReloadScene", 1.5f);
    //    }
    //}

    void ReloadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
