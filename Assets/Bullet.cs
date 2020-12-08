using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Bullet_speed = 1.0f;

    void Start()
    {
        Destroy(gameObject, 5f);

    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * Bullet_speed);
    }
}
