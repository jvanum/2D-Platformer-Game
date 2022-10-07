using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 
public class EnemyPatrol : MonoBehaviour
{
    float speed = 2f;
    float xScale = 0f;

    Rigidbody2D rb;
    BoxCollider2D bc;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        xScale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (isfacingright())
        {
            rb.velocity = new Vector2(-speed, 0f);
        }
        else
        {
            rb.velocity = new Vector2(speed, 0f);
        }
    }
   
    bool isfacingright()
    {
        return transform.localScale.x > 0.01f;
    }


    void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag == "Platform")
        {
            float x = rb.velocity.x > 0f ? xScale : -xScale;

            transform.localScale = new Vector2(x, transform.localScale.y);
        }
    }

}
