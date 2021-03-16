using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineExplosion : MonoBehaviour
{
    public GameObject explosion;
    public AudioSource audioSource;
    bool played = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //StartCoroutine(ExplosionSound());
        if (!played)
        {
            played = true;
            audioSource.Play();
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            GameObject expl = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
            Destroy(gameObject, 2);
            Destroy(expl, 2);
        }
    }

    //private IEnumerator ExplosionSound()
    //{
    //    audioSource.Play();
    //}
    //public void animEndDestroy()
    //{
    //    Destroy(gameObject);
    //}

    // Update is called once per frame
    //void Update()
    //{
        
    //}
}
