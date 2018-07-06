using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    private AgarMovement agarMovement;

    void Awake()
    {
        agarMovement = GetComponent<AgarMovement>();
    }

    void Update()
    {
        if (!Application.isFocused) return;

        var mousePosition = Input.mousePosition;
        mousePosition.z = 10;
        agarMovement.MovePosition = Camera.main.ScreenToWorldPoint(mousePosition);
    }
}
