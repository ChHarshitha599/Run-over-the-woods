using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;


public class LevelDistance : MonoBehaviour
{
    public GameObject didDisplay;
   public GameObject didEndDisplay;

    public int disRun;
    public bool addingDis = false;
    public float disDelay = 0.35f;
    public runningmovements playerMovements;

    void Update()
    {
        if(playerMovements.isOut) { return; }
        if (addingDis == false)
        {
            addingDis = true;
            StartCoroutine(AddingDis());
        }
    }
    IEnumerator AddingDis()
    {
        disRun += 1;
        didDisplay.GetComponent<Text>().text = "" + disRun;
        didEndDisplay.GetComponent<Text>().text = "" + disRun;
        yield return new WaitForSeconds(disDelay);
        addingDis = false;
    }
}