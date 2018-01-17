using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Assertions.Comparers;
using Random = UnityEngine.Random;

public class PlatformSpawner : MonoBehaviour
{
    private Transform player;
    public Transform leftWallPlatform;
    public Transform rightWallPlatform;

    public PlayerBehaviour pB;

    public ObjectPooler theObjectPool;

    private Vector3 leftStartPoint = new Vector3(-22f, 4.17f, 0);
    private Vector3 rightStartPoint = new Vector3(22f, 4.17f, 0);
    public int initSideSpawnNum = 3;
    private Vector3 nextLeftWallLocation;
    private Vector3 nextRightWallLocation;
    private Quaternion nextWallRotation;

    public float numOfPlatforms = 17;
    private float xPos;
    private float yPos;

    public float platformCheck;
    public float wallCheck;

    private float playerHeightY;
    public new Transform camera;


    void Start ()
    {
        yPos = Random.Range(1f, 1.3f);

        player = GameObject.FindWithTag("Player").transform;

        nextLeftWallLocation = leftStartPoint;
        nextRightWallLocation = rightStartPoint;
        nextWallRotation = Quaternion.Euler(0,0,90);
        for (int i = 0; i < initSideSpawnNum; ++i)
        {
            SpawnNextWall();
        }
    }
	
	
	void Update ()
	{
	    if (player != null)
	    {
	        playerHeightY = player.position.y;
        }
	    

	    if (playerHeightY > wallCheck)
	    {
	        PlatformManager();

        }
	   
	    if (playerHeightY > platformCheck)
	    {
	        PlatformManager();            
	    }
	}

    public void PlatformManager()
    {
        platformCheck = player.position.y + 20;
        wallCheck = player.position.y + 10;
        SpawnPlatforms();
        SpawnNextWall();
    }

    public void SpawnPlatforms()
    {
        for (int i = 0; i < numOfPlatforms; i++)
        {

            xPos = Random.Range(-4.7f, 4.7f);
            Vector2 posXY = new Vector2(xPos, yPos);

            GameObject newPlatform = theObjectPool.GetPooledGameObject();
            if (newPlatform != null)
            {              
                newPlatform.transform.position = posXY;
                ReScale(newPlatform);
                newPlatform.SetActive(true);
            }
            
            
                   
        yPos += Random.Range(1f, 1.3f);
        }
    }

    public void SpawnNextWall()
    {
        Transform newLeftWall = Instantiate(leftWallPlatform, nextLeftWallLocation,nextWallRotation);
        Transform newRightWall = Instantiate(rightWallPlatform, nextRightWallLocation,nextWallRotation);

        newLeftWall.transform.parent = GameObject.Find("Platforms").transform;
        newRightWall.transform.parent = GameObject.Find("Platforms").transform;

        Transform nextLeftWall = newLeftWall.Find("NextPlatformSpawnPoint");
        nextLeftWallLocation = nextLeftWall.transform.position;
        nextWallRotation = nextLeftWall.transform.rotation;

        Transform nextRightWall = newRightWall.Find("NextPlatformSpawnPoint");
        nextRightWallLocation = nextRightWall.position;
        nextWallRotation = nextRightWall.rotation;
    }

    public void ReScale(GameObject obj)
    {
        if (obj.transform.localScale.x < 1)
        {
            obj.transform.localScale  = new Vector2(1, 1);
            obj.transform.localScale = new Vector2(Random.Range(.3f, 1.3f), 1);
        }
        else
        {
            obj.transform.localScale = new Vector2(Random.Range(.3f, 1.3f), 1);
        }
    }
}

