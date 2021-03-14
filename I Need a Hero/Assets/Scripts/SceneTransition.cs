using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    public ToggleObject[] objectsToToggle;

    //public GameObject objectsToToggle1;
    //[Tooltip("true for On, false for Off")]
    //public bool toggle1 = false;
    //public GameObject objectsToToggle2;
    //[Tooltip("true for On, false for Off")]
    //public bool toggle2 = false;

    public Transform spotToReach;
    public Transform player;

    public bool x = false, y = false;



    private void Update()
    {
        if (x)
        {
            if (player.position.x <= spotToReach.position.x)
            {
                //do the stuff
                foreach (var objectToToggle in objectsToToggle)
                {
                    if (objectToToggle.toggleOn)
                    {
                        objectToToggle.toToggle.SetActive(true);
                    }
                    else
                    {
                        objectToToggle.toToggle.SetActive(false);
                    }
                }
            }
        }
        if (y)
        {
            if (player.position.y >= spotToReach.position.y)
            {
                //do the stuff
                foreach (var objectToToggle in objectsToToggle)
                {
                    if (objectToToggle.toggleOn)
                    {
                        objectToToggle.toToggle.SetActive(true);
                    }
                    else
                    {
                        objectToToggle.toToggle.SetActive(false);
                    }
                }
            }
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player")){
    //        if (toggle1)
    //        {
    //            objectsToToggle1.SetActive(true);
    //        }
    //        if (!toggle1)
    //        {
    //            objectsToToggle1.SetActive(false);
    //        }
    //    }
    //}
}
