using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] characters;
    public int selectedCharacter = 0;


    public void NextCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % characters.Length;
        characters[selectedCharacter].SetActive(true);

    }

    public void PreviousCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter < 0)
        {
            selectedCharacter += characters.Length;
            characters[selectedCharacter].SetActive(true);
        }
    }
    // Start is called before the first frame update
    public void Startgame()
    {
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter); 
        SceneManager.LoadScene(1, LoadSceneMode.Single);

    }


}
