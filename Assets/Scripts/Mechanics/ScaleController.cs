using DG.Tweening;
using UnityEngine;

public class ScaleController : MonoBehaviour, IActivator
{
    public bool isCharBig = false;

    [Header("B�y�me-K���lme Ayarlar�")]
    public float growScale = 1.5f;
    public float shrinkScale = 1f; // K���lme miktar�
    public float duration = 0.5f;

    [Header("Shake Efekti Ayarlar�")]
    public float shakeDuration = 0.3f;  // Sars�lma s�resi
    public float shakeStrength = 0.2f;  // Sars�lma �iddeti
    public int shakeVibrato = 8;        // Sars�lma titre�im miktar�
    public float shakeRandomness = 90f;

    [Header("Punch Efekti Ayarlar�")]
    public float punchScaleAmount = 0.1f; // K���lme sonras� titre�im �iddeti 
    public float punchDuration = 0.2f;
    public float punchVibrate = 5f;
    public float punchElasticity = 1f;

    public AbilityCooldown scaleCd;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SoundManager.PlaySound(SoundType.Scale,0.2f);
            StartScaling();
        }
    }

    void StartScaling()
    {
        if (!isCharBig)
        {
            transform.DOScale(growScale, duration).SetEase(Ease.InOutElastic).OnComplete(() =>
            {
                transform.DOShakeScale(shakeDuration, shakeStrength, shakeVibrato, shakeRandomness, true);
                isCharBig = true;
            });
        }
        else
        {
            transform.DOScale(shrinkScale, duration).SetEase(Ease.InBounce).OnComplete(() =>
            {
                transform.DOPunchScale(Vector3.one * punchScaleAmount, punchDuration, shakeVibrato, punchElasticity);
                isCharBig = false;
            });
        }
    }

    public void Enable()
    {
        enabled = true;
    }

    public void Disable()
    {
        enabled = false;
    }
}
