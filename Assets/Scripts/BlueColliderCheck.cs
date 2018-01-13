using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueColliderCheck : MonoBehaviour {

    public float removeTime = 1f;
    public PlatformSpawner spawner;

    IEnumerator OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "BluePlatform")
        {
            yield return new WaitForSeconds(2);
            col.gameObject.transform.parent.gameObject.SetActive(false);
        }
        else if (col.tag == "LeftSideWall" || col.tag == "RightSideWall")
        {

        }
        else if (col.tag == "SawBlade")
        {
            PlayerBehaviour.pB.PlayerDeath();
        }
        else
        {
            PlayerBehaviour.pB.PlayerDeath();
        }
    }

}


