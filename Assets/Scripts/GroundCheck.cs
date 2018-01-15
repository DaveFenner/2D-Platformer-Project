using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{

    private PlayerBehaviour player;
	
	void Start ()
	{
	    player = gameObject.GetComponent<PlayerBehaviour>();
	}


    void OnTriggerEnter2D(Collider2D col)
    {
        player.grounded = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
       
        player.grounded = false;
    }
}
