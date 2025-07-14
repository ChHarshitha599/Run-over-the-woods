//using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Image SoundOn;
    [SerializeField] Image SoundOff;
    public bool muted = false;

    void Start()
    {
        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
            Load();
        }
        UpdateButtonIcon();
        AudioListener.pause = muted;
    }

    public void OnButtonPress()
    {
        if (muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            muted = false;
            AudioListener.pause = false;
        }
        Save();
        UpdateButtonIcon();
    }
    private void UpdateButtonIcon()
    {
        if(muted == false)
        {
            SoundOn.gameObject.SetActive(true);
            SoundOff.gameObject.SetActive(false);
        }
        else
        {
            SoundOn.gameObject.SetActive(false);
            SoundOn.gameObject.SetActive(true);
        }

    }
    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }
    private void Save()
    {
        PlayerPrefs.SetInt("muted",muted ? 1 : 00);
    }
}
