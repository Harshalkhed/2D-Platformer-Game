using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private BoxCollider2D boxCol;
    private Vector2 boxColInitSize;
    private Vector2 boxColInitOffset;
    [SerializeField] float playerSpeed = 8;
    private Rigidbody2D rb2d;
    [SerializeField] float jumpForce=2;
    private bool isGrounded = false;
    private float delaysec = 1f;

    public void PlayerDead()
    {
        Debug.Log("Enemy hit ");
        
        playerAnimator.SetTrigger("Death");
        Invoke("LoadNewScene", delaysec);


        

    }

    private void LoadNewScene()
    {
        SceneManager.LoadScene(0);

    }

    public ScoreController scoreController;


    public void pickUpKey()
    {
        Debug.Log("Player has picked up the key");
        scoreController.IncreaseScore(10);
    }

    

    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
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

        if(vertical>0)
        {
            rb2d.AddForce(new Vector2 (0f,jumpForce),ForceMode2D.Force);
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
        if (jumpvalue > 0)
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

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.transform.tag == "platform")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.tag == "platform")
        {
            isGrounded = false;
        }
    }




}
