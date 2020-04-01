using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFirePooler : MonoBehaviour
{
    public static PlayerFirePooler current = null;
    public GameObject pooledObject = null;
    public int pooledAmount = 20;
    public bool willGrow = true;

    public List<GameObject> pooledObjects = null;

    public void Awake()
    {
        current = this;
    }

    void Start()
    {
        pooledObjects = new List<GameObject>();

        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObejcr()
    {
        for (int i = 0; i < pooledAmount; i++)
        {
            if (pooledObjects[i].activeInHierarchy == false)
            {
                return pooledObjects[i];
            }
        }

        if (willGrow == true)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            pooledObjects.Add(obj);
            return obj;
        }

        return null;
    }
}
