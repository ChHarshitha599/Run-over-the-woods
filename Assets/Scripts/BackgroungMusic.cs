using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroungMusic : MonoBehaviour
{
    private static BackgroungMusic backgroundMusic;
     void Awake()
    {
        if(backgroundMusic == null)
        {
            backgroundMusic = this;
            DontDestroyOnLoad(backgroundMusic);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
