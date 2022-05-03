using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music_toggle : MonoBehaviour
{
    private bool isMuted = false;
    [SerializeField] private Sprite[] speakerSprites;
    private Image speakerImage;
    private int speakerState; //0=muted, 1=unmuted

    void Start()
    {
        isMuted = false;
        speakerImage = GetComponent<Button>().image;
        ToggleSpeakerImage();
    }

    public void Mute()
    {
        isMuted = !isMuted;
        AudioListener.pause = isMuted;
        ToggleSpeakerImage();

    }

    public void ToggleSpeakerImage()
    {
        speakerState = isMuted ? 1 : 0;
        speakerImage.sprite = speakerSprites[speakerState];
    }
}
