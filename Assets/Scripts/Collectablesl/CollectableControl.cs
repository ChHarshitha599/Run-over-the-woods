using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableControl : MonoBehaviour
{
    public static int SandalwoodCount;
    public GameObject SandalwoodCountDisplay;
    public GameObject SandalwoodEndDisplay;


    // Update is called once per frame
    void Update()
    {
        SandalwoodCountDisplay.GetComponent<Text>().text = "" + SandalwoodCount;
        SandalwoodEndDisplay.GetComponent<Text>().text = "" + SandalwoodCount;

    }
}