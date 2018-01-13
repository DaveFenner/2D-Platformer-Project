using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

public class PlatformSpawner : MonoBehaviour
{
    private Transform player;
    public Transform leftWallPlatform;
    public Transform rightWallPlatform;

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

    private float playerHeightY;
    public new Transform camera;


    void Start ()
    {
        yPos = 1.5f;

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
        playerHeightY = player.position.y;
	    if (playerHeightY > platformCheck)
	    {
	        PlatformManager();
            SpawnNextWall();
	    }
	}

    public void PlatformManager()
    {
        platformCheck = player.position.y + 10;
        SpawnPlatforms();
    }

    public void SpawnPlatforms()
    {
        
        for (int i = 0; i < numOfPlatforms; i++)
        {
           
            xPos = Random.Range(-4.5f, 4.5f);
            Vector2 posXY = new Vector2(xPos, yPos);

            GameObject newPlatform = theObjectPool.GetPooledObject();
            newPlatform.transform.position = posXY;
            newPlatform.SetActive(true);

            yPos += Random.Range(1.3f, 1.5f);

        }
    }


    /*public void SpawnPlatforms(float floatValue)
    {       
            
            while (yPos <= floatValue)
            {
                xPos = Random.Range(-4.5f, 4.5f);
                Vector2 posXY = new Vector2(xPos, yPos);

                GameObject regularPlatforms = Instantiate(platforms[Random.Range(0, 2)], posXY, Quaternion.identity);
                

                regularPlatforms.transform.parent = GameObject.Find("Platforms").transform;
                regularPlatforms.transform.localScale = new Vector3(Random.Range(.3f, 1f), 1, 1);               
                yPos += Random.Range(1.2f, 1.75f);
                for (int i = 0; i < numOfPlatforms ; i++)
                    {
                    xPos = Random.Range(-4.5f, 4.5f);
                    Vector2 posXY = new Vector2(xPos, yPos);
                    GameObject platformInstatiated = Instantiate(platforms[Random.Range(0, 2)], posXY, Quaternion.identity);

                    platformInstatiated.transform.parent = GameObject.Find("Platforms").transform;
                    platformInstatiated.transform.localScale = new Vector3(Random.Range(.3f, 1f), 1, 1);
                    yPos += Random.Range(1.2f, 1.75f);
                    loopedGameObject.Add(platformInstatiated);                  
                    }                          
            }

        spawnPlatformsTo = floatValue;
    }*/

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

    public void CheckColllider()
    {
        
    }
}

