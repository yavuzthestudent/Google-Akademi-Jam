using UnityEngine;

public class Toxic : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneMan.LoadCurrentScene();
        }
    }
}
