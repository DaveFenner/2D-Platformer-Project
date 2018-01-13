using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {


    public GameObject player;


    public float speed = 2.0f;

    void Update()
    {
        float interpolation = speed * Time.deltaTime;

        Vector3 position = transform.position;
        position.y = Mathf.Lerp(transform.position.y, player.transform.position.y, interpolation);
        position.x = Mathf.Lerp(transform.position.x, player.transform.position.x, interpolation);

        transform.position = position;     
    }
}
