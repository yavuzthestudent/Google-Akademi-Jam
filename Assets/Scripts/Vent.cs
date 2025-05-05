using UnityEngine;

public class Vent : MonoBehaviour
{
    public Transform[] vents;
    public bool isEntry;
    
    public int ReturnEntryVent()
    {
        isEntry = !isEntry;
        return isEntry ? 1 : 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SoundManager.PlaySound(SoundType.Vent);
            other.transform.position = vents[ReturnEntryVent()].position;
        }
    }
}
