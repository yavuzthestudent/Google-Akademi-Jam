using UnityEngine;

public class Teaser : MonoBehaviour
{
    public void AnimationEnd()
    {
        SceneMan.LoadNextScene();
    }
}
