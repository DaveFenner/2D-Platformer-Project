using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueColliderCheck : MonoBehaviour {

    public float removeTime = 1f;
    public Material defaultMaterial;
    public Material blueGlowMat;


    IEnumerator OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("BlueCollider"))
        {
            gameObject.GetComponentInParent<SpriteRenderer>().material = blueGlowMat;
            yield return new WaitForSeconds(removeTime);
            gameObject.GetComponentInParent<SpriteRenderer>().material = defaultMaterial;
            gameObject.transform.parent.gameObject.SetActive(false);
            
        }              
        else if (col.CompareTag("PurpleCollider"))
        {
            PlayerBehaviour.pB.PlayerDeath();
        }
    }
}


