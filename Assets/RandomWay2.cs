using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWay2 : MonoBehaviour
{
    void Start()
    {
        InvokeRepeating("Random", 0f, 2f);
    }
    void Random()
    {
        Vector3 RanPos = gameObject.transform.position;
        RanPos.x = UnityEngine.Random.Range(-20,20);
        RanPos.z = UnityEngine.Random.Range(0,30);
        gameObject.transform.position = RanPos;
    }
}
