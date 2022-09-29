using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public bool crouch;
    public bool jump;
    public Animator animator;
    public BoxCollider2D boxCollider;

    //gameobject active
    private void Awake()
    {
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
       
        float horizontal = Input.GetAxisRaw("Horizontal");

        PlayerAnimation(horizontal, crouch, jump);
        PlayerMovement(horizontal);
       
    }

    //movement for player
    private void PlayerMovement (float horizontal)
    {
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime; 
        transform.position = position;
    }

    //animation for player
    private void PlayerAnimation (float horizontal, bool crouch, bool jump)
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
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            jump = true;
        } else
        {
            jump = false;
        }
        animator.SetBool("Jump", jump);
    }

}