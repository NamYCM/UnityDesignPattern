using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 5f;

    void Start() {
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnEnable () {
        StartCoroutine(DestroyAfter());
    }

    IEnumerator DestroyAfter() {
        yield return new WaitForSeconds(3f);
        Pooling.Instance.RemoveObject(this.gameObject);
    }
}
