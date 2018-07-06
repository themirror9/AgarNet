using DarkRift;
using DarkRift.Client;
using DarkRift.Client.Unity;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public UnityClient client;

    Dictionary<ushort, Agar> networkPlayers = new Dictionary<ushort, Agar>();

    public void Add(ushort id, Agar player)
    {
        networkPlayers.Add(id, player);
    }

    public void Awake()
    {
        client.MessageReceived += MessageReceived;
    }

    void MessageReceived(object sender, MessageReceivedEventArgs e)
    {
        using (Message message = e.GetMessage() as Message)
        {
            if (message.Tag == Tags.MovePlayer)
            {
                using (DarkRiftReader reader = message.GetReader())
                {
                    ushort id = reader.ReadUInt16();
                    Vector3 newPosition = new Vector3(reader.ReadSingle(), reader.ReadSingle(), 0);

                    networkPlayers[id].movement.MovePosition = newPosition;
                    networkPlayers[id].body.Size = reader.ReadSingle();
                }
            }
        }
    }
}
