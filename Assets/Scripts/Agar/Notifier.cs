using DarkRift;
using DarkRift.Client.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notifier : MonoBehaviour
{
    public UnityClient Client;

    public float threshold = 0.05f;

    private Vector2 lastPosition;

    private void Start()
    {
        lastPosition = transform.position;

        var movement = GetComponent<AgarMovement>();
        movement.OnPositionChange.AddListener(SendPosition);
    }

    private void SendPosition(Vector3 position)
    {
        if (Vector3.Distance(lastPosition, position) > threshold)
        {
            using (DarkRiftWriter writer = DarkRiftWriter.Create())
            {
                writer.Write(position.x);
                writer.Write(position.y);

                using (Message message = Message.Create(Tags.MovePlayer, writer))
                    Client.SendMessage(message, SendMode.Unreliable);
            }

            lastPosition = position;
        }
    }
}
