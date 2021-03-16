using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


public class WinGame : MonoBehaviour
{
    public AudioSource audioSource;
    public string sceneName = "Final Scene";

    void OnTriggerEnter(Collider other)
    {
        StartCoroutine(WinGameStartOver());
    }

    // Update is called once per frame
    IEnumerator WinGameStartOver()
    {
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        Invoke("ReloadScene", 1.5f);
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
