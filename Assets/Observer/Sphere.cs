using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour, IObserver
{
    private Rigidbody rigidbody = null;

    // Start is called before the first frame update
    void Start()
    {
        if (!TryGetComponent<Rigidbody>(out rigidbody)) {
            Debug.Log("Lost rigibody");
        }

        InputSystem.Instance.RegisterObserver(MovementEvent.Jump, this);
    }

    public void OnNotify (object key, object data) {
        if ((MovementEvent)key == MovementEvent.Jump && rigidbody != null) {
            Debug.Log("Sphere jump");
            rigidbody.AddForce(Vector3.up * (float)data);
        }
    }
}
