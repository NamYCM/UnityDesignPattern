using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : Subject<InputSystem>
{
    public float force = 15f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump")) {
            SendMessage(MovementEvent.Jump, force);
        }
    }
}

public enum MovementEvent {
    Jump
}
