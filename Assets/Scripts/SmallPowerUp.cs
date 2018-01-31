using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallPowerUp : MonoBehaviour
{
    public PlayerBehaviour player;
	
	void Start ()
	{
	    player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();
	}
	
	
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Debug.Log("Power UP");
            StartCoroutine(SmallPlayer());
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }


    public IEnumerator SmallPlayer()
    {
        if (player != null)
        {
            player.transform.localScale = new Vector2(0.10625f, 0.5f);
            player.jumpPower = 500;
            yield return new WaitForSeconds(5);
            player.transform.localScale = new Vector2(0.2124999f, 1f);
            player.jumpPower = 300;
            Destroy(this);
        }
    }
}
