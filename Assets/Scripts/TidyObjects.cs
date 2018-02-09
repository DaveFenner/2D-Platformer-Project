using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TidyObjects : MonoBehaviour
{

    private float removeTime = 15f;

    private GameObject player;

    private new GameObject camera;
    private float playerHeightY;

    void Start()
    {
        player = GameObject.FindWithTag("Player").gameObject;
    }

    void Update()
    {
        if (player != null)
        {
            playerHeightY = player.transform.position.y;
        }      
    }

    public void OnBecameInvisible()
    {
        if (gameObject.transform.position.y > playerHeightY)
        {
            return;
        }

        if (gameObject.CompareTag("LeftSideWall"))
        {
            Destroy(gameObject,removeTime);
        }
        else if (gameObject.CompareTag("RightSideWall"))
        {
            Destroy(gameObject, removeTime);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}


