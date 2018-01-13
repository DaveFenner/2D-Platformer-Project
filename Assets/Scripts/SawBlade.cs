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
	    transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
    }

}
