using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {


    public GameObject player;
    public Color32 lerpedColor = new Color32(72,67,73,255);


    public float speed = 2.0f;

    void Update()
    {
        
        if (player != null)
        {
            float interpolation = speed * Time.deltaTime;

            Vector3 position = transform.position;
            position.y = Mathf.Lerp(transform.position.y, player.transform.position.y, interpolation);
            position.x = Mathf.Lerp(transform.position.x, player.transform.position.x, interpolation);

            transform.position = position;
        }
        Camera.main.backgroundColor = lerpedColor;
    }
}
