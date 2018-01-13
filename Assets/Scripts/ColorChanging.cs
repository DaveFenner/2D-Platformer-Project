using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanging : MonoBehaviour
{
    private SpriteRenderer platform;
    private Transform platformTriggerObject;
    public Sprite purpleSprite;
    public Sprite blueSprite;
	
	void Start ()
	{
	    platform = gameObject.GetComponent<SpriteRenderer>();
	    platformTriggerObject = transform.GetChild(0);
        StartCoroutine(ChangeToBlue());
    }
	
	
	void Update () {
       
	    
    }

    IEnumerator ChangeToBlue()
    {
        yield return new WaitForSeconds(Random.Range(1,1.5f));
        platformTriggerObject.tag = "BluePlatform";
        platform.GetComponent<SpriteRenderer>().sprite = blueSprite;
        yield return new WaitForSeconds(Random.Range(1, 1.5f));
        platformTriggerObject.gameObject.tag = "PurplePlatform";
        platform.GetComponent<SpriteRenderer>().sprite = purpleSprite;
        

        StartCoroutine(ChangeToBlue());
    }
}
