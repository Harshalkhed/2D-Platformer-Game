using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D enemyRigidbody;
    private Animator enemyyAnimation;
    private Transform currentPoint;
    public float speed = 2;
    // Start is called before the first frame update


    private void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
        enemyyAnimation = GetComponent<Animator>();
        currentPoint = pointB.transform;
        enemyyAnimation.SetBool("isRunning", true);
    }

    private void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if(currentPoint==pointB.transform)
        {
            enemyRigidbody.velocity = new Vector2(speed, 0);
        }
        else
        {
            enemyRigidbody.velocity = new Vector2(-speed, 0);
        }

        if(Vector2.Distance(transform.position,currentPoint.position)< 1f && currentPoint==pointB.transform)
        {
            currentPoint = pointA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 1f && currentPoint == pointA.transform)
        {
            currentPoint = pointB.transform;
        }
        EnemyRunAnimation(enemyRigidbody.velocity.x);
    }
    private void EnemyRunAnimation(float animationSpeed)
    {
        enemyyAnimation.SetFloat("Speed", Mathf.Abs(animationSpeed));

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



    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        if (playerController)
        {
           
            playerController.PlayerDead();
            

        }
    }
}
