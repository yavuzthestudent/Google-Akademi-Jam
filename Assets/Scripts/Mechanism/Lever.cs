using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Lever : MonoBehaviour
{
    private bool isLeverActive = false;
    private bool isAnimationWorking = false;

    public List<GameObject> activators;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && !isAnimationWorking)
        {
            SoundManager.PlaySound(SoundType.Lever,0.05f);
            isAnimationWorking = true;
            transform.DORotate(new Vector3(0, 0, !isLeverActive ? -60 : 0), 0.5f, RotateMode.Fast).OnComplete(()=>{
                isAnimationWorking =false;
            });

            foreach (var activator in activators)
            {
                if (!isLeverActive)
                {
                    activator.GetComponent<IActivator>().Enable();

                }
                else
                {
                    activator.GetComponent<IActivator>().Disable();
                }
            }
            isLeverActive = !isLeverActive;
        }
    }
}