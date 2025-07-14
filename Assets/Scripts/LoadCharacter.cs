using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadCharacter : MonoBehaviour
{
    public GameObject[] characterPerfabs;
    public Transform spawPoint;
    public TMP_Text label;
    // Start is called before the first frame update
    void Start()
    {
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        GameObject prefab = characterPerfabs[selectedCharacter];
        GameObject clone= Instantiate(prefab, spawPoint.position,Quaternion.identity);
        label.text = prefab.name;
    }

    
}
