using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music_toggle : MonoBehaviour
{
    private bool isMuted = false;

    public void Mute()
    {
    }

    void Start()
    {
        isMuted = false;
    }

    public void ClickMute()
    {
        isMuted = !isMuted;
        AudioListener.pause = isMuted;
    }
}
