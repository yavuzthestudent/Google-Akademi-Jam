using System;
using System.Collections;
using UnityEngine;

public enum SoundType
{
    Scale,
    Ekko,
    Gravity,
    Vent,
    Jump,
    Die,
    Lever,
    Button,//
    WaterBlink,
    DoorOpen,//
    LevelEnd,
    Pressure
}

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] soundList;
    [SerializeField] public AudioClip[] musics;
    public static SoundManager Instance;
    private AudioSource audioSource;
    private AudioSource musicSource;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        musicSource = gameObject.AddComponent<AudioSource>();
        SoundManager.Instance.ChangeMusic(SoundManager.Instance.musics[0]);
        //SoundManager.Instance.ChangeMusic(SoundManager.Instance.musics[0]);
        //musicSource.loop = true;
        musicSource.volume = 0.5f;
        //int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //if (currentSceneIndex == 0)
        //{
        //    SoundManager.Instance.ChangeMusic(SoundManager.Instance.musics[2]);
        //}
        //else if (currentSceneIndex == 1)
        //{
        //    SoundManager.Instance.ChangeMusic(SoundManager.Instance.musics[0]);
        //}
    }
    public static void PlaySound(SoundType sound, float volume = 1)
    {
        Instance.audioSource.PlayOneShot(Instance.soundList[(int)sound], volume);
    }
    //public void StopMusic()
    //{
    //    musicSource.Stop();
    //}
    public void ChangeMusic(AudioClip newMusic)
    {
        musicSource.Stop();
        musicSource.clip = newMusic;
        musicSource.loop = true;
        musicSource.Play();
    }
    public  static int MuteSoundsEffect()
    {
        return 0;
    }

    public void IsPlaying(Action action)
    {
        StartCoroutine(IsPlayingCoroutine(action));
    }

    private IEnumerator IsPlayingCoroutine(Action action)
    {
        float elapsed = 0;
        while (audioSource.isPlaying && elapsed < 0.05f)
        {
            elapsed += Time.deltaTime;
            yield return null;
        }
        action();
    }
}