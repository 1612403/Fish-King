using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class settings : MonoBehaviour
{
    public static int audioState; // 0 - mute, 1 - unmute

    public GameObject settingsCanvas;

    private void Start()
    {
        AudioListener.volume = 1f;
        audioState = 1;
    }

    public void Audio()
    {
        if (audioState == 1)
        {
            AudioListener.volume = 0f;
            audioState = 0;
        }
        else
        {
            AudioListener.volume = 1f;
            audioState = 1;
        }
    }

    public void toMainScr()
    {
        SceneManager.LoadScene(0);
    }
}
