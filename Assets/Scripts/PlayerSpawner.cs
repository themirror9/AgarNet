using System;
using DarkRift;
using DarkRift.Client;
using DarkRift.Client.Unity;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public UnityClient client;
    public PlayerManager manager;

    public GameObject controllablePrefab;
    public GameObject networkPrefab;

    void Awake()
    {
        client.MessageReceived += SpawnPlayer;
    }

    private void SpawnPlayer(object sender, MessageReceivedEventArgs e)
    {
        using (Message message = e.GetMessage())
        using (DarkRiftReader reader = message.GetReader())
        {
            if (message.Tag == Tags.SpawnPlayer)
            {
                if (reader.Length % 17 != 0)
                {
                    Debug.LogWarning("Received malformed spawn packet.");
                    return;
                }

                while (reader.Position < reader.Length)
                {
                    ushort id = reader.ReadUInt16();
                    Vector3 position = new Vector3(reader.ReadSingle(), reader.ReadSingle());
                    float size = reader.ReadSingle();
                    Color32 color = new Color32(
                        reader.ReadByte(),
                        reader.ReadByte(),
                        reader.ReadByte(),
                        255
                    );

                    var obj = default(GameObject);

                    if (id == client.ID)
                    {
                        obj = Instantiate(controllablePrefab, position, Quaternion.identity) as GameObject;
                        obj.GetComponent<Notifier>().Client = client;
                    }
                    else
                    {
                        obj = Instantiate(networkPrefab, position, Quaternion.identity) as GameObject;
                    }

                    var agarObj = obj.GetComponent<Agar>();

                    agarObj.body.Size = size;
                    agarObj.body.Color = color;

                    manager.Add(id, agarObj);
                }
            }
        }

    }
}