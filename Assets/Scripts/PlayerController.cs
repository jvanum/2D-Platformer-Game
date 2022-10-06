using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpforce;
    private bool crouch, jump, isgrounded, playerDead;

    public ScoreController scoreControl;
    public Animator animator;
    public BoxCollider2D boxCollider;
    public Rigidbody2D rigidbdy;

    //gameobject active
    private void Awake()
    {
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        rigidbdy = gameObject.GetComponent<Rigidbody2D>();
    }

    //increases score when key is picked up
    public void PickUpKey()
    {
        scoreControl.IncreaseScore(10);
        Debug.Log("Key picked up");
    }

    //wait time coroutine after player death
    public IEnumerator WaitForPlayerDeath()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //called when player collides with enemy
    public void KillPlayer()
    {
        Debug.Log("Player killed by enemy");
        animator.SetBool("PlayerDead", true);
        StartCoroutine(WaitForPlayerDeath());
    }

    // Update is called once per frame
    private void Update()
    {
       
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        PlayerAnimation(horizontal, vertical, crouch, jump);
        PlayerMovement(horizontal, vertical);
       
    }
 
    //Detect if player is grounded with platform 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            isgrounded= true;
        }
    }

    /*private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {   
            Debug.Log("not grounded ");
            isgrounded = false;
        }
    } */

    //movement for player
    private void PlayerMovement (float horizontal, float vertical)
    {
        //player horizontal movement
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime; 
        transform.position = position;

        //player vertical movement
        if (vertical > 0 && isgrounded)
            {
                rigidbdy.AddForce(new Vector2(0f, jumpforce), ForceMode2D.Force);
                            Debug.Log("Player jumped ");
                isgrounded = false;

            }

    }
    
    //animations for player
    private void PlayerAnimation (float horizontal, float vertical, bool crouch, bool jump)
    {
        //run animation
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        // crouch animation
         if (Input.GetKey(KeyCode.LeftControl))
        {
            crouch = true;
            boxCollider.size = new Vector2(0.9355f, 1.3232f);
            boxCollider.offset = new Vector2(-0.1277f, 0.5732f);
        }
        else
        {
            crouch = false;
            boxCollider.size = new Vector2(0.4212f, 2.0952f);
            boxCollider.offset = new Vector2(-0.0194f , 0.9591f);
        }   
        animator.SetBool("Crouch", crouch);

        //jump animation
        if (vertical > 0)
        {
            jump = true;
        } else
        {
            jump = false;
        }
        animator.SetBool("Jump", jump);
    }

//death animation
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Respawn")
        {
            playerDead= true;
        }
        animator.SetBool("PlayerDead", playerDead);
    }
}