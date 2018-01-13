using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{

    public GameObject[] pooledObject;
    public int pooledAmount;
    private List<GameObject> pooledObjects;
	
	void Start () {
		pooledObjects = new List<GameObject>();

	    for (int i = 0; i < pooledAmount; i++)
	    {
	        GameObject obj = (GameObject) Instantiate(pooledObject[Random.Range(0,2)]);
	        obj.transform.localScale = new Vector3(Random.Range(.3f, 1.3f), 1, 1);
            obj.transform.parent = GameObject.Find("Platforms").transform;
            obj.SetActive(false);
            pooledObjects.Add(obj);
	    }
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

        GameObject obj = (GameObject)Instantiate(pooledObject[Random.Range(0,2)]);
        obj.transform.localScale = new Vector3(Random.Range(.3f, 1.3f), 1, 1);
        obj.transform.parent = GameObject.Find("Platforms").transform;
        obj.SetActive(false);
        pooledObjects.Add(obj);
        return obj;
    }


}
