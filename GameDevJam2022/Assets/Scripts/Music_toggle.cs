using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music_toggle : MonoBehaviour
{
    private bool isMuted = false;

    void Start()
    {
        isMuted = false;
    }

    public void Mute()
    {
        isMuted = !isMuted;
        AudioListener.pause = isMuted;
    }
}
