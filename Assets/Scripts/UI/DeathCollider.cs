using UnityEngine;

public class DeathCollider : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        Debug.Log("Player fell from platform, respawning");
        playerController.KillPlayer();
    }
}
