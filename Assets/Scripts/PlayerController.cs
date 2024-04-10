using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private BoxCollider2D boxCol;
    public GameOverController gameOverController;
    private Vector2 boxColInitSize;
    private Vector2 boxColInitOffset;
    [SerializeField] float playerSpeed = 8;
    private Rigidbody2D playerRigidbody;
    [SerializeField] float jumpForce=2;
    [SerializeField]
    private bool isgrounded = false;
    private float delaysec = 1f;
    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;

    public void PlayerDead()
    {
        
        
        playerAnimator.SetTrigger("Death");

        Invoke("PlayerDied()", delaysec);

        gameOverController.PlayerDied();
    }

   

    public ScoreController scoreController;


    public void pickUpKey()
    {
       
        scoreController.IncreaseScore(10);
    }

    

    private void Awake()
    {
        playerRigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        
        boxColInitSize = boxCol.size;
        boxColInitOffset = boxCol.offset;
    }


    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("Collsion"+ collision.gameObject.name);
    //}


    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical= Input.GetAxisRaw("Vertical");

        Crouch();
        PlayJumpAnimation(vertical);
        PlayerRunAnimation(horizontal);
        MoveCharacter(horizontal, vertical);
        

    }

    private void MoveCharacter(float horizontal,float vertical)
    {
        //move character Horizontally
        Vector3 playerPosition = transform.position;
        playerPosition.x +=  horizontal * playerSpeed * Time.deltaTime;
        transform.position = playerPosition;
        //move character Horizontally

        if(vertical>0 && isGrounded())
        {
            playerRigidbody.AddForce(new Vector2 (0f,jumpForce),ForceMode2D.Force);
            
        }
    }

    private void PlayerRunAnimation(float animationSpeed)
    {
        playerAnimator.SetFloat("Speed", Mathf.Abs(animationSpeed));

        Vector3 scale = transform.localScale;

        if (animationSpeed < 0)
        {

            scale.x = -1f * Mathf.Abs(scale.x);

        }
        else if (animationSpeed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }

        transform.localScale = scale;
    }

    private void PlayJumpAnimation(float jumpvalue)
    {
        if (jumpvalue > 0 && isGrounded())
        {
            playerAnimator.SetBool("Jump", true);

        }
        else

        {

            playerAnimator.SetBool("Jump", false);

        }



    }

    private void Crouch()
    {
        if (Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl))
        {

            playerAnimator.SetBool("Crouch", true);
            float offX = -0.0978f;     //Offset X
            float offY = 0.5947f;      //Offset Y

            float sizeX = 0.6988f;     //Size X
            float sizeY = 1.3398f;     //Size Y

            boxCol.size = new Vector2(sizeX, sizeY);   //Setting the size of collider
            boxCol.offset = new Vector2(offX, offY);   //Setting the offset of collider

        }
        else
        {
            playerAnimator.SetBool("Crouch", false);
            //Reset collider to initial values
            boxCol.size = boxColInitSize;
            boxCol.offset = boxColInitOffset;
        }
    }

    public bool isGrounded()
    {
       
        if (Physics2D.BoxCast(transform.position,boxSize,0,-transform.up,castDistance,groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position-transform.up *castDistance, boxSize);
    }





}
