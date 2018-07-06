using HalfBattery.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarMovement : MonoBehaviour
{
    public FloatEvent OnSpeedChange;
    public Vector3Event OnPositionChange;

    public Vector3 MovePosition { get; set; }

    [SerializeField]
    private float speed = 1f;

    public float Speed
    {
        get { return speed; }

        set
        {
            if (speed != value)
            {
                speed = value;
                OnSpeedChange.Invoke(speed);
            }
        }
    }

    private void Awake()
    {
        MovePosition = transform.position;
    }

    private void Update()
    {
        transform.position += (MovePosition - transform.position).normalized * speed * Time.deltaTime;
        OnPositionChange.Invoke(transform.position);
    }
}
