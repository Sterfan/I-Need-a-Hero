using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ControlsBlink : MonoBehaviour
{
    public Sprite image;

    //void Start()
    //{
    //    GetComponent<SpriteRenderer>().sprite = image;
    //    StartBlinking();
    //}


    //IEnumerator Blink()
    //{
    //    while (true)
    //    {
    //        switch (image.texture)
    //        {
    //            case "0":
    //                image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
    //                yield return new WaitForSeconds(0.5f);
    //                break;
    //            case "1":
    //                image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
    //                yield return new WaitForSeconds(0.5f);
    //                break;
    //        }
    //    }
    //}

    //void StartBlinking()
    //{
    //    StartCoroutine("Blink");
    //}

    //void StopBlinking()
    //{
    //    StopAllCoroutines();
    //}

}
