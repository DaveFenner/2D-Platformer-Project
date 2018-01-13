using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TidyObjects : MonoBehaviour
{

    public float removeTime = 10f;

    private GameObject player;

    private new GameObject camera;
    private float playerHeightY;

    void Start()
    {
        player = GameObject.FindWithTag("Player").gameObject;
    }

    void Update()
    {
        playerHeightY = player.transform.position.y;
    }

    public void OnBecameInvisible()
    {
        if (gameObject.transform.position.y > playerHeightY)
        {

        }
        else if (gameObject.tag == "LeftSideWall" || gameObject.tag == "RightSideWall")
        {
            Destroy(gameObject,removeTime);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}


