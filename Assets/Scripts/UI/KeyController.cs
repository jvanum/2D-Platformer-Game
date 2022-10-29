using UnityEngine;

public class KeyController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerController playerController))
        {
            SoundManager.Instance.Play(SoundTypes.COLLECTKEY);
            playerController.PickKey();
            Destroy(gameObject);
        }
    }
}
