using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{


    public GameObject player;
    public bool passed = false;



    public float speed = 2.0f;


    void Start()
    {
        Vector3 posStart = transform.position;
        posStart.y = transform.position.y - -4f;
        transform.position = posStart;
    }



    void Update()
    {
        if (player != null)
        {
            if (player.transform.position.y > 4f)
            {
                {
                    float interpolation = speed * Time.deltaTime;

                    Vector3 position = transform.position;
                    position.y = Mathf.Lerp(transform.position.y, player.transform.position.y, interpolation);
                    
                    transform.position = position;
                    passed = true;
                }

            }
        }
    }
}

    

