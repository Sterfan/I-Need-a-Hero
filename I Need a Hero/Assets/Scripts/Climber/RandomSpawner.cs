using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public FallingObject[] fallingObjects;
    public Camera cam;
    public float fallSpeed = 10f;
    public float destructionTime = 3.0f;
    public Transform leftSpawn, rightSpawn, maxHeight;
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

    List<GameObject> objectPool = new List<GameObject>();

    private void Start()
    {
        foreach (var objectToFall in fallingObjects)
        {
            for (int i = 0; i < objectToFall.probability; i++)
            {
                objectPool.Add(objectToFall.objectToSpawn);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (leftSpawn.position.y < maxHeight.position.y)
        {
            SpeedupInterval();
            timer += Time.deltaTime;
            if (timer > interval)
            {
                int probability = Random.Range(0, 10);
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
    }

    private void SpawnObject()
    {
        objectToSpawn = objectPool[Random.Range(0, objectPool.Count)];
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
