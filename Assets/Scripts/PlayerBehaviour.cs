using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerBehaviour : MonoBehaviour
{
    public static PlayerBehaviour pB;
    public SmallPowerUp powerUp;
    public CameraController camController;

    public AudioSource audioSource;
    public AudioClip jumpSound;
    public AudioClip deathSound;
    public AudioClip rotateSound;
    public float volume;

    public Rigidbody2D rb;
    private Animator animator;
    private Transform player;

    public float speed = 5f;
    public float jumpPower = 300f;

    public bool grounded = true;
    bool canDoubleJump;

    bool canRotate = true;
    private float move;
    private float move2;

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
        currentCameraHeight = camera.transform.position.y;
        playerHeightY = player.position.y;

        move = CrossPlatformInputManager.GetAxis("Horizontal");
         move2 = Input.GetAxis("Horizontal");
        

        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            Jump();
        }

        if (playerHeightY < (currentCameraHeight - 4.5f))
        {
            PlayerDeath();
        }

        if (playerHeightY > ScoreKeeper.score)
        {
            ScoreKeeper.score = (int)playerHeightY;
        }
    }


    void FixedUpdate()
    {       
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
        rb.velocity = new Vector2(move2 * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            Jump();

        }

        
    }

    void Jump()
    {      
            if (grounded)
            {
                rb.AddForce(Vector2.up * jumpPower);
                canDoubleJump = true;

                audioSource.PlayOneShot(rotateSound);
                Rotate();
            }
            else
            {
                if (canDoubleJump)
                {
                    audioSource.PlayOneShot(rotateSound);
                    canDoubleJump = false;
                    rb.velocity = new Vector2(rb.velocity.x, 0);
                    rb.AddForce(Vector2.up * jumpPower);
                    Rotate();
                }
                else if (!canDoubleJump)
                {
                    audioSource.PlayOneShot(rotateSound);
                    Rotate();
                }
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
        audioSource.PlayOneShot(deathSound, 16f);     
    }

}
