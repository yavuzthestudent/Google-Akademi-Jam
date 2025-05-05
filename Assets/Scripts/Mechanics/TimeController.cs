using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour, IActivator
{
    private Rigidbody2D rb;
    private List<Vector2> lastPositions;
    public int maxPositionCount = 50;
    public float recordTime = 1f;
    private float currentRecordTime;
    public float rewindDuration = 5f;
    private bool isRewinding = false;
    public AbilityCooldown timeCd;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastPositions = new List<Vector2>();
        currentRecordTime = recordTime;
    }

    void Update()
    {
        if (isRewinding) return;

        if (Input.GetKeyDown(KeyCode.F))
        {
            SoundManager.PlaySound(SoundType.Ekko);
            StartCoroutine(RewindCoroutine());
            isRewinding = !isRewinding;
        }

        Record();
    }

    private void Record()
    {
        currentRecordTime -= Time.deltaTime;
        if (currentRecordTime <= 0)
        {
            if (lastPositions.Count > maxPositionCount)
            {
                lastPositions.RemoveAt(lastPositions.Count - 1);
            }

            lastPositions.Insert(0, transform.position);
            currentRecordTime = recordTime;
        }
    }

    IEnumerator RewindCoroutine()
    {
        float gravityScale = rb.gravityScale;
        rb.gravityScale = 0f;
        while (lastPositions.Count > 0)
        {
            Vector2 startPosition = transform.position;
            Vector2 targetPosition = lastPositions[0];
            float elapsed = 0;

            while (elapsed < rewindDuration)
            {
                transform.position = Vector2.Lerp(startPosition, targetPosition, elapsed / rewindDuration);
                elapsed += Time.deltaTime;
                yield return null;
            }

            transform.position = targetPosition;
            lastPositions.RemoveAt(0);
            yield return null;
        }

        isRewinding = false;
        rb.gravityScale = gravityScale;
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
