using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class FR_Pool : MonoBehaviour
{
    // Flying Rockets _Pool
    public static FR_Pool instance;

    public List<GameObject> pooledObjects = new List<GameObject>();
    //private int amountToPool = 3;

    [SerializeField] private GameObject rocketPrefab;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        /*for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(rocketPrefab);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }*/

    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        return null;
    }
}
