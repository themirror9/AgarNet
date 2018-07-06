using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agar : MonoBehaviour {

    public AgarBody body;
    public AgarMovement movement;

    private void Awake()
    {
        body = GetComponent<AgarBody>();
        movement = GetComponent<AgarMovement>();
    }
}
