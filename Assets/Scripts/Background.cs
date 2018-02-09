using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {


    private Vector3 backPos;
    public float width = 14.22f;
    public float height = 0f;
    private float X;
    private float Y;

    void Start()
    {
        Debug.Log(gameObject.GetComponent<SpriteRenderer>().bounds.size.y.ToString());
    }

    void OnBecameInvisible()
    {
        //calculate current position
        backPos = gameObject.transform.position;
        //calculate new position
        print(backPos);       
        X = backPos.x + width * 3;
        Y = backPos.y + height * 3;
        //move to new position when invisible
        gameObject.transform.position = new Vector3(X, Y, 0f);
    }

}

