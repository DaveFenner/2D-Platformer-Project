using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawBladeSpawner : MonoBehaviour
{
    public GameObject sawBlade;
    private Vector2 sawSpawn;
    private bool sawspawned;

	void Start ()
	{
	    sawspawned = false;
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" && !sawspawned)
        {
            Debug.Log("test");
            sawSpawn = gameObject.transform.GetChild(1).position;           
            GameObject sawBlades = Instantiate(sawBlade, sawSpawn, Quaternion.identity);
            sawBlades.transform.parent = GameObject.Find("Obstacles").transform;
            sawspawned = true;
        }
    }
}
