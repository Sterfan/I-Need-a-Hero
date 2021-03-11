using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public bool loadScene2 = false;
    public bool loadScene3 = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (loadScene2)
        {
            SceneManager.LoadScene("Axel 2", LoadSceneMode.Additive);
        }
        if (loadScene3)
        {
            SceneManager.LoadScene("Axel 3", LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync("Axel 1");
        }
    }
}
