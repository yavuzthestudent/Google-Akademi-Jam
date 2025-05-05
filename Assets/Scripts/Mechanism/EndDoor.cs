using UnityEngine;

public class EndDoor : MonoBehaviour
{
    private int playerCount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerCount++;
            if (playerCount == 3)
            {
                SceneMan.LoadNextScene();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerCount++;
        }
    }
}
