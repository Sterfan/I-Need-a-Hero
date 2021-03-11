using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject[] fallingObjects;
    public Camera cam;
    public float fallSpeed = 10f;

    GameObject objectToSpawn;

    float timer = 3f, interval = 5f;


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > interval)
        {
            objectToSpawn = fallingObjects[Random.Range(0, fallingObjects.Length)];
            GameObject clone = Instantiate(objectToSpawn, RandomizePosition(), Quaternion.identity);
            clone.transform.position -= new Vector3(0f, fallSpeed, 0f) * Time.deltaTime;
            Destroy(clone, 6.0f);
            timer = 0;
        }
    }

    Vector3 RandomizePosition()
    {
        float vertExtent = cam.orthographicSize * Screen.height / Screen.width;
        float horizontalExtent = cam.orthographicSize * Screen.width / Screen.height;
        float randomX = Random.Range(cam.transform.position.x - horizontalExtent, cam.transform.position.x + horizontalExtent + 1);
        Vector3 spawnPosition = new Vector3(randomX, cam.transform.position.y + vertExtent + 3, 0f);
        return spawnPosition;
    }
}
