using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMan : MonoBehaviour
{
    public static GameObject mainMenu;

    public GameObject teaser;

    public void Teaser()
    {
        teaser.SetActive(true);
    }

    public static void LoadNextScene()
    {
        
        if (SceneManager.GetActiveScene().buildIndex != 0)
            SoundManager.PlaySound(SoundType.LevelEnd);
        SoundManager.Instance.IsPlaying(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        });
        SoundManager.Instance.ChangeMusic(SoundManager.Instance.musics[0]);

    }

    public static void LoadCurrentScene()
    {
        SoundManager.PlaySound(SoundType.Die);

        SoundManager.Instance.IsPlaying(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        });
        
        SoundManager.Instance.ChangeMusic(SoundManager.Instance.musics[0]);
    }

    public static void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        //SoundManager.Instance.ChangeMusic(SoundManager.Instance.musics[2]);
    }

    public static void LoadTutorial()
    {
        SceneManager.LoadScene("TutorialScene");
    }

    public static void QuitGame()
    {
        Application.Quit();
    }

}
