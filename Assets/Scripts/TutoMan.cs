using UnityEngine;
using UnityEngine.UI;

public class TutoMan : MonoBehaviour
{
    public Sprite[] tutoImages; // Tutorial resimleri
    public Image displayImage; // Paneldeki Image bileþeni
    public GameObject tutoPanel; // Tutorial paneli

    private int currentIndex = 0;

    private void Start()
    {

        if (tutoImages.Length > 0)
        {
            displayImage.sprite = tutoImages[currentIndex];
        }
        else
        {
            Debug.LogError("Tutorial resimleri atanmadý!");
        }
    }

    public void NextImage()
    {
        if (currentIndex < tutoImages.Length - 1)
        {
            currentIndex++;
            displayImage.sprite = tutoImages[currentIndex];
        }
        else
        {
            ExitTuto();
        }
    }

    public void ExitTuto()
    {
        tutoPanel.SetActive(false);
    }

    public void OpenTuto()
    {
        currentIndex = 0;
        displayImage.sprite = tutoImages[currentIndex];
        tutoPanel.SetActive(true);
    }

}