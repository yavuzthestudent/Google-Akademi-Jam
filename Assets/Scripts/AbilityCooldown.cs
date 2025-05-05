using UnityEngine;

[System.Serializable]
public class AbilityCooldown
{
    public float cooldownTime; // Cooldown s�resi
    private float elapsedTime; // Geri say�m s�resi
    private bool isReady = true; // Yetenek haz�r m�?

    public bool IsReady => isReady;

    public void StartCooldown()
    {
        if (!isReady) return;
        isReady = false;
        elapsedTime = cooldownTime;
    }

    public void UpdateCooldown()
    {
        if (isReady) return;

        elapsedTime -= Time.deltaTime;
        if (elapsedTime <= 0)
        {
            isReady = true;
        }
    }
}
