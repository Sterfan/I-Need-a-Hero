using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class WinGame : MonoBehaviour
{
    public AudioSource audioSource;
    public string sceneName = "Final Scene";
    public GameObject blackOutSquare;
    float fadeSpeed = 1f;
    public Animator animator;
    //AudioSource songTrack;

    private void Start()
    {
        //songTrack = GameObject.FindGameObjectWithTag("Song").GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        animator.enabled = false;
        StartCoroutine(WinGameStartOver());
    }

    // Update is called once per frame
    IEnumerator WinGameStartOver()
    {
        Color objectColor = blackOutSquare.GetComponent<Image>().color;
        float fadeAmount;
        while (blackOutSquare.GetComponent<Image>().color.a < 1)
        {
            fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);
            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            blackOutSquare.GetComponent<Image>().color = objectColor;
            yield return null;
        }
        //yield return new WaitForSeconds(1);
        //songTrack.Stop();
        audioSource.Play();

        yield return new WaitForSeconds(audioSource.clip.length);
        Invoke("ReloadScene", 1.5f);
    }

    void ReloadScene()
    {
        //songTrack.Play();
        SceneManager.LoadScene(sceneName);
    }
}
