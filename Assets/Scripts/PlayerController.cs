using System.Collections;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpforce = 1500f;
    private bool isgrounded;
    private float horizontal;
    private string platform = "Platform";

    public ScoreController scoreControl;
    [HideInInspector]
    private Animator playerAnimator;
    [HideInInspector]
    private BoxCollider2D boxCollider;
    [HideInInspector]
    private Rigidbody2D rigidbdy;
    [SerializeField] private LivesController livesController;
    [SerializeField] private GameOverPanelController gameOverController;

   
    private void Awake()
    {
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        rigidbdy = gameObject.GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }


    private void Update()
    {
        PlayerMovement();  
    }

    //increases score when key is picked up
    public void PickKey()
    {
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
        }
    }

    //wait time coroutine for player death
    private IEnumerator WaitForSomeTime()
    {
        yield return new WaitForSeconds(0.5f);
        SoundManager.Instance.Play(SoundTypes.PLAYERDEATH);
        gameOverController.PlayerDied();
    }

    
    //called when player dies
    public void KillPlayer()
    {
        PlayerDeathAnim();
        StartCoroutine(WaitForSomeTime());
        this.enabled = false;
    }
 
    //movement for player
    private void PlayerMovement ()
    {
        //player horizontal movement
        horizontal = Input.GetAxisRaw("Horizontal");

        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime; 
        transform.position = position;
        PlayerRunAnimation();

        //crouch
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            playerAnimator.SetTrigger("Crouch");
            boxCollider.size = new Vector2(0.9355f, 1.3232f);
            boxCollider.offset = new Vector2(-0.1277f, 0.5732f);
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            playerAnimator.SetTrigger("Release");
            boxCollider.size = new Vector2(0.4212f, 2.0952f);
            boxCollider.offset = new Vector2(-0.0194f, 0.9591f);
        }

        //jump
        if (Input.GetKeyDown(KeyCode.Space) && isgrounded)
        {
            rigidbdy.AddForce(Vector2.up * jumpforce, ForceMode2D.Force);
            SoundManager.Instance.Play(SoundTypes.PLAYERJUMP);
            playerAnimator.SetTrigger("Jump");
        }
        
    }

    //animations for player - run, crouch
    private void PlayerRunAnimation ()
    {
        //run animation

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

        if (horizontal != 0 && isgrounded)
        {
            SoundManager.Instance.PlayContinuous(SoundTypes.PLAYERMOVE);
        }

        playerAnimator.SetFloat("Speed", Mathf.Abs(horizontal));
    }

    //player death animation
    public void PlayerDeathAnim()
    {
        SoundManager.Instance.Play(SoundTypes.PLAYERFELL);
        playerAnimator.SetTrigger("PlayerIsDead");
    }

    //player hurt animation
    public void PlayerHurtAnim()
    {
        SoundManager.Instance.Play(SoundTypes.PLAYERHURT);
        playerAnimator.SetTrigger("PlayerIsHurt");
    }


    //Detect if player is grounded with platform 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(platform))
        {
            isgrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(platform))
        {
            isgrounded = false;
        }
    }
}