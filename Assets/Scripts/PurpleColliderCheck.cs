using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleColliderCheck : MonoBehaviour {

    public float removeTime = 1f;
    public Material defaultMaterial;
    public Material purpleGlowMat;
    public Material redGlowMat;


    IEnumerator OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("PurpleCollider"))
        {
            gameObject.GetComponentInParent<SpriteRenderer>().material = purpleGlowMat;
            yield return new WaitForSeconds(removeTime);
            gameObject.GetComponentInParent<SpriteRenderer>().material = defaultMaterial;
            gameObject.transform.parent.gameObject.SetActive(false);

        }
        else if (col.CompareTag("BlueCollider"))
        {
            gameObject.GetComponentInParent<SpriteRenderer>().material = redGlowMat;
            PlayerBehaviour.pB.PlayerDeath();
        }
    }
}
