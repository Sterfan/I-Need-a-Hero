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
    public string sceneName = "Final Scene";
    bool spawned = false;
    bool played = false;

    public AudioSource audioSource;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            if (!played)
            {
                played = true;
                audioSource.Play();
            }
            Debug.Log("Eat my healthy butt!");
            //SceneManager.LoadScene("Sidescroller");
            foreach(GameObject bp in bodyParts)
            {
                bp.SetActive(false);
            }
            //ragdoll.SetActive(true);
            cam.alive = false;
            if (!spawned)
            {
                Instantiate(ragdoll, transform.position, Quaternion.identity);
                spawned = true;
            }
            Invoke("ReloadScene", 1.5f);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
