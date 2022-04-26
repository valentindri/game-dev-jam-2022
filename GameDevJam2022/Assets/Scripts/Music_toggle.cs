using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music_toggle : MonoBehaviour
{
    private bool isMute = false;
    public Button yourButton;

    public void MuteAllSound()
    {
        AudioListener.volume = 0;
    }

    public void UnMuteAllSound()
    {
        AudioListener.volume = 1;
    }

    public void Mute()
    {
        isMute = !isMute;
        Debug.Log("Is muted?" + isMute);
        if (isMute)
        {
            Debug.Log("stopping music");
            MuteAllSound();
        }
        else
        {
            Debug.Log("playing music");
            UnMuteAllSound();
        }
    }

    void Start()
    {
        Button btn = gameObject.GetComponent<Button>();
        Debug.Log("gameobject"+gameObject);
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
    }
}
