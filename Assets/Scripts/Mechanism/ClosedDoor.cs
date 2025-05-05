using DG.Tweening;
using UnityEngine;

public class ClosedDoor : MonoBehaviour, IActivator
{
    public float targetY = -5;
    float deafultY;

    private void Start()
    {
        deafultY = transform.localPosition.y;
    }

    public void Enable()
    {
        SoundManager.PlaySound(SoundType.DoorOpen);
        transform.DOLocalMoveY(targetY, 1);
    }

    public void Disable()
    {
        SoundManager.PlaySound(SoundType.DoorOpen);
        transform.DOLocalMoveY(deafultY, 1);
    }
}
