using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gun : MonoBehaviour
{
    public Bullet Bullet;
    private Pooling pooling;

    // Start is called before the first frame update
    void Start()
    {
        pooling = Pooling.Instance;

        if (!Bullet)
        {
            Debug.Log("miss bullet");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //rotate
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;
        mousePos.x -= Screen.width / 2;
        mousePos.y -= Screen.height / 2;
        transform.up = mousePos;

        if (!Bullet) return;
        //fire
        if (Input.GetMouseButtonDown(0)) 
        {
            GameObject bullet = pooling.GetObject();
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            // Bullet bullet = Instantiate<Bullet>(Bullet, transform.position, transform.rotation);
        }
    }
}
