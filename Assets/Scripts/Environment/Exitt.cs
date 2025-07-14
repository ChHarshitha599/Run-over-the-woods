
    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Exitt: MonoBehaviour
{
    
    public void LoadLoadingScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadDessertScene()
    {
        SceneManager.LoadScene("DesertPushpa");
    }

}