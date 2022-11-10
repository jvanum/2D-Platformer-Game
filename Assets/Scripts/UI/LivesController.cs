using UnityEngine;

public class LivesController : MonoBehaviour
{
    [SerializeField] private GameObject[] hearts;
    private int currentLives;

    private void Start()
    {
        currentLives = hearts.Length;
    }
    public int DestroyLife()
    {
        currentLives--;
        if (currentLives >= 0)
        {
            Destroy(hearts[currentLives].gameObject);
        }
        return currentLives;
    }
   
}
