using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// common enemy behaviour controller
public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed = 2f; // speed of enemy patrolling
    private float xScale;// to retain enemy object scale
    private string platform = "Platform";

    private Rigidbody2D enemyRbd;
    private BoxCollider2D enemyBcd;
    private Animator enemyAnim;

    // Start is called before the first frame update
    void Start()
    {   
        enemyRbd = GetComponent<Rigidbody2D>();
        enemyBcd = GetComponent<BoxCollider2D>();
        enemyAnim = GetComponent<Animator>();
        xScale = transform.localScale.x;
    }

    // Update is called once per frame
    private void Update()
    {
        EnemyPatrolMovement();
    }
    
    private void EnemyPatrolMovement()
    {
        //enemy movement on platform
        if (transform.localScale.x > 0.01f)
        {
            enemyRbd.velocity = new Vector2(-speed, 0f);
        }
        else
        {
            enemyRbd.velocity = new Vector2(speed, 0f);
        }
        EnemyWalkAnim();
    }

    // enemy flip movement on platform
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(platform))
        {
            float x = enemyRbd.velocity.x > 0f ? xScale : -xScale;

            transform.localScale = new Vector2(x, transform.localScale.y);
        }
    }

    // manages player-enemy collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerController playerController))
        {
            playerController.TakeDamage();
        }
    }

      //enemy walk animation
    private void EnemyWalkAnim()
    {
        enemyAnim.SetTrigger("CanWalk");
    }

    private void EnemyDeathAnim()
    {
        enemyAnim.SetTrigger("Dead");
    }
}