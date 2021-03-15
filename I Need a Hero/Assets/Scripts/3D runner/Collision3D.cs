using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision3D : MonoBehaviour
{
    public GameObject[] playerParts;
    public GameObject ragdoll;
    public string sceneName = "Final Scene";

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        Debug.Log("hi");
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            foreach (var part in playerParts)
            {
                part.SetActive(false);
            }
            ragdoll.SetActive(true);
            Invoke("ReloadScene", 1.5f);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
