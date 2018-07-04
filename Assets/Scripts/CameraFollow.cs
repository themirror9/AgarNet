using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float speed = 5f;
    public Transform target;
    private float z;

    private void Awake()
    {
        z = transform.position.z;
    }

    void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.Lerp(transform.position,
                                              target.position.SetZ(z),
                                              speed * Time.deltaTime);
        }
    }
}
