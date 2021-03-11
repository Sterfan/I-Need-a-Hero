using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject[] fallingObjects;
    public Camera cam;
    public float fallSpeed = 10f;
    public float destructionTime = 3.0f;
    public Transform leftSpawn, rightSpawn;
    [Tooltip("Probability in % to spawn a falling object every second")]
    public float probabilityToSpawn = 70;

    GameObject objectToSpawn;
    [Tooltip("Initial value of Timer, determines how long before it tries to spawn the first falling object (interval - timer)")]
    public float timer = 3f;
    [Tooltip("Interval between each spawn check")]
    public float interval = 3f;
    [Tooltip("Probability in % of spawning 2 objects at once")]
    public float probabilityOfDoubleObject = 20f;

    float intervalTimer = 0f;


    // Update is called once per frame
    void Update()
    {
        SpeedupInterval();
        timer += Time.deltaTime;
        if (timer > interval)
        {
            int probability = Random.Range(0, 10);
            Debug.Log(probability);
            if (probability < (probabilityToSpawn * 0.1f))
            {
                SpawnObject();
                if (Random.Range(0, 10) < probabilityOfDoubleObject * 0.1f)
                {
                    SpawnObject();
                }
            }
            timer = 0;
        }
    }

    private void SpawnObject()
    {
        objectToSpawn = fallingObjects[Random.Range(0, fallingObjects.Length)];
        GameObject clone = Instantiate(objectToSpawn, RandomizePosition(), Quaternion.Euler(new Vector3(-180, 0, 0)));
        Destroy(clone, destructionTime);
    }

    Vector3 RandomizePosition()
    {
        float xPos = Random.Range(leftSpawn.position.x, rightSpawn.position.x);
        Vector3 spawnPosition = new Vector3(xPos, leftSpawn.position.y, 0f);
        return spawnPosition;
    }

    void SpeedupInterval()
    {
        intervalTimer += Time.deltaTime;
        if (intervalTimer > 5.0f)
        {
            interval *= 0.9f;
            intervalTimer = 0f;
        }
    }
}
