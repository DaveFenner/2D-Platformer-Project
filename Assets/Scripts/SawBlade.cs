using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawBlade : MonoBehaviour
{
    float moveSpeed = 4;

    void Start ()
	{
	    
    }
	
	
	void Update ()
	{
	    transform.parent.Translate(Vector2.down * moveSpeed * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {                         
                PlayerBehaviour.pB.PlayerDeath();           
        }
    }

}
