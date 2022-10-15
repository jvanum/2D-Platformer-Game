using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// common enemy behaviour controller
public class EnemyController : MonoBehaviour
{
    private float speed = 2f; // speed of enemy patrolling
    private float xScale = 0f;// to retain enemy object scale

    private Rigidbody2D enemyRbd;
    private BoxCollider2D enemyBcd;
    private Animator enemyAnim;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {   
        enemyRbd = GetComponent<Rigidbody2D>();
        enemyBcd = GetComponent<BoxCollider2D>();
        enemyAnim = GetComponent<Animator>();
        xScale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {   
        //enemy movement on platform
        if (isfacingright())
        {
            enemyRbd.velocity = new Vector2(-speed, 0f);
        }
        else
        {
            enemyRbd.velocity = new Vector2(speed, 0f);
        }
        enemyAnim.SetBool("CanPatrol", true);
    }
    
    bool isfacingright()
    {
        return transform.localScale.x > 0.01f;
    }

    // enemy flip movement on platform
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Platform")
        {
            float x = enemyRbd.velocity.x > 0f ? xScale : -xScale;

            transform.localScale = new Vector2(x, transform.localScale.y);
        }
    }
    // manages player-enemy collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        playerController = collision.gameObject.GetComponent<PlayerController>();
        if (playerController != null)
        {
            Debug.Log("Player collided with Enemy");
            playerController.TakeDamage();
        }
    }

    //enemy animations

}
