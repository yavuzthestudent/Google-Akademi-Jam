using UnityEngine;

[System.Serializable]
public class AbilityCooldown
{
    public float cooldownTime; // Cooldown süresi
    private float elapsedTime; // Geri sayým süresi
    private bool isReady = true; // Yetenek hazýr mý?

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
