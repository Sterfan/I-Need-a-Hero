using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineExplosion : MonoBehaviour
{
    public GameObject explosion;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject expl = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
        Destroy(gameObject);
        Destroy(expl, 2);
    }

    //public void animEndDestroy()
    //{
    //    Destroy(gameObject);
    //}

    // Update is called once per frame
    //void Update()
    //{
        
    //}
}
