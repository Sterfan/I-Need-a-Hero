using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBehaviour : MonoBehaviour
{
    public float fallSpeed = 10f;
    int speed;

    private void Awake()
    {
        speed = RandomizeSpeed();
    }
    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, speed, 0) * Time.deltaTime;
    }

    int RandomizeSpeed()
    {
        int plusOrMinus = Mathf.RoundToInt(fallSpeed * 0.3f);
        int speed = Mathf.RoundToInt(Random.Range(fallSpeed - plusOrMinus, fallSpeed + plusOrMinus + 1));
        return speed;
    }
}
