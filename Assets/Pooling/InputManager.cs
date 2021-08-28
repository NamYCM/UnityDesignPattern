using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : SingletonMono<InputManager>
{
    public Vector2 look;

    public void OnLook (InputValue value) 
    {
        look = value.Get<Vector2>();
    }
}
