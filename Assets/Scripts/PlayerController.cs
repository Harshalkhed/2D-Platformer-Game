using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator playerAnimator;
    private void Awake()
    {
        
    }


    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("Collsion"+ collision.gameObject.name);
    //}


    private void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        float jump= Input.GetAxisRaw("Vertical"); 
        
        //playerAnimator.SetBool("Jump", true);

        playerAnimator.SetFloat("Speed",Mathf.Abs( speed));
        
        Vector3 scale = transform.localScale;
        Vector3 position = transform.localPosition;
        if (speed<0)
        {
            
            scale.x = -1f * Mathf.Abs(scale.x);

        }
        else if(speed> 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }

        transform.localScale = scale;


         if (jump > 0)
        {
            //position.y =  Mathf.Abs(position.y);
            playerAnimator.SetBool("Jump", true);


        }
        else
        {
            
            playerAnimator.SetBool("Jump", false);
        }

        transform.localPosition = position;


        if(Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl))
         {
             
             playerAnimator.SetBool("Crouch",true);

         }
        else
        {
            playerAnimator.SetBool("Crouch", false);
        }
        

    }








}
