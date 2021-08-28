using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooling : SingletonMono<Pooling>
{
    [SerializeField] private GameObject prefab;

    [SerializeField] private int poolSize = 0;

    [SerializeField] private bool expanable = true;

    private List<GameObject> poolObjects;
    // Start is called before the first frame update
    void Awake()
    {
        if (!prefab)
        {
            Debug.Log("Miss prefab");
            return;
        }

        poolObjects = new List<GameObject>();

        for (int i = 0; i < poolSize; i ++) {
            GenerateNewObject();
        }
    }
    
    public GameObject GetObject () 
    {
        foreach (var g in poolObjects)
        {
            if (!g.activeSelf)
            {
                g.SetActive(true);
                return g;
            }
        }

        if (expanable) 
        {
            GameObject g = GenerateNewObject();
            g.SetActive(true);

            return g;
        }
        else return null;
    }

    public void RemoveObject (GameObject gameObject)
    {
        gameObject.SetActive(false);
    }

    private GameObject GenerateNewObject ()
    {
        GameObject gameObject = Instantiate(prefab);
        gameObject.transform.parent = transform;
        gameObject.SetActive(false);
        poolObjects.Add(gameObject);
        
        return gameObject;
    }
}
