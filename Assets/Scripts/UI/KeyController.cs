using UnityEngine;

public class KeyController : MonoBehaviour
{
    public PlayerController playerController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerController = collision.gameObject.GetComponent<PlayerController>();

        if (collision.gameObject.CompareTag("Player"))
        {
            SoundManager.Instance.Play(SoundTypes.COLLECTKEY);
            playerController.PickKey();
            Destroy(gameObject);
            Debug.Log("Key destroyed");
        }
    }
}
