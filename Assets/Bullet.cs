using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 5;

    void Start() {
        StartCoroutine(DestroyAfter());
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
    }

    IEnumerator DestroyAfter() {
        yield return new WaitForSeconds(3f);
        Debug.Log("123");
        Destroy(this.gameObject);
    }
}
