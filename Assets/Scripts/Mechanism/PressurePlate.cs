using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public List<GameObject> activators;
    private bool isActivated;
    public GameObject plate;
    public GameObject player;
    private bool isTriggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player") && !isActivated && player.transform.localScale.y > 1.5f &&!isTriggered)
        {
           SoundManager.PlaySound(SoundType.Pressure);
            isActivated = true;
            isTriggered = true;
            plate.transform.position = new Vector3(plate.transform.position.x, plate.transform.position.y -0.2f, transform.position.z);
            foreach (var activator in activators)
            {
                activator.GetComponent<IActivator>().Enable();
            }
        }


    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isActivated && player.transform.localScale == new Vector3(1.5f, 1.5f, 1.5f) && !isTriggered)
        {
            SoundManager.PlaySound(SoundType.Pressure);
            isActivated = true;
            isTriggered= true;
            plate.transform.position = new Vector3(plate.transform.position.x, plate.transform.position.y - 0.2f, transform.position.z);
            foreach (var activator in activators)
            {
                activator.GetComponent<IActivator>().Enable();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isActivated)
        {
            
            isActivated = false;
            isTriggered = false;
            plate.transform.position = new Vector3(plate.transform.position.x, plate.transform.position.y + 0.2f, transform.position.z);
        }

        foreach (var activator in activators)
        {
            activator.GetComponent<IActivator>().Disable();
        }
    }
}
