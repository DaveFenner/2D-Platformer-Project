using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    public static PlayerBehaviour pB;

    public Rigidbody2D rb;
    private Animator animator;
    private Transform player;

    public float speed = 5f;
    public float jumpPower = 300f;

    public bool grounded = true;
    bool canDoubleJump;

    bool canRotate = true;

    public float playerHeightY;

    public new Transform camera;
    private float currentCameraHeight;


    void Start ()
    {
        pB = this;
        player = GameObject.FindWithTag("Player").transform;
        rb.freezeRotation = true;
	    animator = transform.GetComponent<Animator>();
	}


    void Update()
    {

        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
        currentCameraHeight = camera.transform.position.y;
        playerHeightY = player.position.y;
        if (Input.GetButtonDown("Jump"))
        {
            if (grounded)
            {
                rb.AddForce(Vector2.up * jumpPower);
                canDoubleJump = true;
                Rotate();
            }
            else
            {
                if (canDoubleJump)
                {
                    canDoubleJump = false;
                    rb.velocity = new Vector2(rb.velocity.x, 0);
                    rb.AddForce(Vector2.up * jumpPower);
                    Rotate();
                }else if (!canDoubleJump)
                {                  
                    Rotate();
                }
            }

        }

        if (playerHeightY < (currentCameraHeight - 4f))
        {
            PlayerDeath();
        }

        if (playerHeightY > ScoreKeeper.score)
        {
            ScoreKeeper.score = (int) playerHeightY;
        }
    }

 

    void Rotate()
    {
        if (canRotate)
        {
            animator.SetBool("RotatePlayer", true);           
            canRotate = false;
        } else if (!canRotate)
        {
            animator.SetBool("RotatePlayer", false);
            canRotate = true;
        }
    }

    public void PlayerDeath()
    {
        gameObject.GetComponent<Explodable>().explode();
        ScoreKeeper.sK.CheckHighScore();
        ScoreKeeper.sK.EndGame();

       
    }
}
