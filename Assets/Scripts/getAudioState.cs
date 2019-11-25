using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getAudioState : MonoBehaviour
{
    public Sprite mute, unmute;
    void Update()
    {
        if (settings.audioState == 1)
            GetComponent<Button>().GetComponent<Image>().sprite = mute;
        else
            GetComponent<Button>().GetComponent<Image>().sprite = unmute;
    }
}
