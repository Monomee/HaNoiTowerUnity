using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using static Unity.Burst.Intrinsics.X86.Avx;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling Instance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;

    public Transform rod1PosSpawn;
    private Color[] colors = { Color.red, Color.yellow, Color.green, Color.cyan, Color.blue, Color.gray, Color.black, Color.white };

    private void OnEnable()
    {
        Instance = this;
    }
    private void OnDisable() 
    {
        Instance = null;
    }

    public void Init()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.transform.localScale = new Vector3(tmp.transform.localScale.x + i * 0.4f, tmp.transform.localScale.y);
            tmp.GetComponent<SpriteRenderer>().color = colors[i];
            tmp.transform.position = rod1PosSpawn.transform.position;
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }

    public GameObject GetPooledObject(int numOfObject)
    {
        for (int i = numOfObject - 1; i >= 0; i--) //amountToPool-1-(amountToPool-numOfObject)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
    public GameObject GetLastPooledObjectThatActive()
    {
        for (int i = amountToPool-1; i >= 0; i--) 
        {
            if (pooledObjects[i].activeInHierarchy)
            {
                pooledObjects[i].transform.position = rod1PosSpawn.transform.position;
                return pooledObjects[i];
            }
        }
        return null;
    }
}
