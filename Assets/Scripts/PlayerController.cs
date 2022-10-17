using System.Collections;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpforce;
    private bool crouch, jump, isgrounded;
    // player max and current lives

    public ScoreController scoreControl;
    [HideInInspector]
    public Animator playerAnimator;
    [HideInInspector]
    public BoxCollider2D boxCollider;
    [HideInInspector]
    public Rigidbody2D rigidbdy;
    public LivesController livesController;
    public GameOverPanelController gameOverController;

    //gameobject active
    private void Awake()
    {
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        rigidbdy = gameObject.GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    
    private void Update()
    {
       
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        PlayerAnimation(horizontal, vertical, crouch, jump);
        PlayerMovement(horizontal, vertical);
        PlayMovementSound(horizontal);
       
    }
    //player movement sound
     private void PlayMovementSound(float horizontal)
    {
        if (horizontal != 0 && isgrounded)
        {
            SoundManager.Instance.PlayContinuous(SoundTypes.PLAYERMOVE);
        }
    }
    //increases score when key is picked up
    public void PickKey()
    {
        Debug.Log("PickKey called successfully");
        scoreControl.IncreaseScore(10);
    }

    //player takes damage on colliding with enemy
    public void TakeDamage()
    {
        int currentLives = livesController.DestroyLife();
        if(currentLives <= 0)
        {
            KillPlayer();
        }
        else
        {
           PlayerHurtAnim();
           transform.position = new Vector3(0f, 0f, 0f);
           Debug.Log("Player hurt");
        }
    }

    //wait time coroutine for player death
    public IEnumerator WaitForSomeTime()
    {
        yield return new WaitForSeconds(1f);
        SoundManager.Instance.Play(SoundTypes.PLAYERDEATH);
        gameOverController.PlayerDied();
    }

    
    //called when player dies
    public void KillPlayer()
    {
        Debug.Log("Player Died");
        PlayerDeathAnim();
        StartCoroutine(WaitForSomeTime());
        this.enabled = false;

    }

    // Update is called once per frame
 
    //Detect if player is grounded with platform 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            isgrounded= true;
        }
    }

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
                SoundManager.Instance.Play(SoundTypes.PLAYERJUMP);
                rigidbdy.AddForce(new Vector2(0f, jumpforce), ForceMode2D.Force);
                Debug.Log("Player jumped ");
                isgrounded = false;
            }

    }
    
    //animations for player - run, crouch, jump
    private void PlayerAnimation (float horizontal, float vertical, bool crouch, bool jump )
    {
        //run animation
        playerAnimator.SetFloat("Speed", Mathf.Abs(horizontal));

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
        playerAnimator.SetBool("Crouch", crouch);

        //jump animation
        if (vertical > 0)
        {
            jump = true;
        } else
        {
            jump = false;
        }
        playerAnimator.SetBool("Jump", jump);
    }

    //player death animation
    public void PlayerDeathAnim()
    {
        SoundManager.Instance.Play(SoundTypes.PLAYERFELL);
        playerAnimator.SetTrigger("PlayerIsDead");
        Debug.Log("Player Death animation played");
    }

    public void PlayerHurtAnim()
    {
        SoundManager.Instance.Play(SoundTypes.PLAYERHURT);
        playerAnimator.SetTrigger("PlayerIsHurt");
        Debug.Log("Player Hurt animation played");
    }
}