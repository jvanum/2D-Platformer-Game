using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;

    // Update is called once per frame
    public void Update()
    {
        // run trigger
        float runspeed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(runspeed));

        Vector3 scale = transform.localScale;
        if (runspeed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (runspeed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        // jump trigger
        bool jump;
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            jump = true;
        } else
        {
            jump = false;
        }
        animator.SetBool("Jump", jump);

        // crouch trigger
        bool crouch;
        if (Input.GetKey(KeyCode.LeftControl))
        {
            crouch = true;
            GetComponent<BoxCollider2D>().size = new Vector2(0.9355f, 1.3232f);
            GetComponent<BoxCollider2D>().offset = new Vector2(-0.1277f, 0.5732f);

        }
        else
        {
            crouch = false;
            GetComponent<BoxCollider2D>().size = new Vector2(0.4212f, 2.0952f);
            GetComponent<BoxCollider2D>().offset = new Vector2(-0.0194f , 0.9591f);

        }   
        animator.SetBool("Crouch", crouch);


       
    }
}
