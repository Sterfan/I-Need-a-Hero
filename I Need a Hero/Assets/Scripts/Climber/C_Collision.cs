using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class C_Collision : MonoBehaviour
{
    public GameObject ragdoll;
    public GameObject[] bodyParts;
    public RunnerCharacterController cc;
    public string sceneName = "Final Scene";



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            //SceneManager.LoadScene("Sidescroller");
            foreach (GameObject bp in bodyParts)
            {
                bp.SetActive(false);
            }
            //ragdoll.SetActive(true);
            Invoke("ReloadScene", 1.5f);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
