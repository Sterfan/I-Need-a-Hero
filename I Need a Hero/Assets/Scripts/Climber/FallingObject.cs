using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FallingObject
{
    public GameObject[] objectToSpawn;
    [Tooltip("Probability in % to be spawned")]
    public int probability;

}
