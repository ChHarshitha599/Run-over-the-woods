
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStarter : MonoBehaviour
{
    public GameObject countDown3;
    public GameObject countDown2;
    public GameObject countDown1;
    public GameObject countDownGo;
    public GameObject FadeIn;
    public AudioSource readyFx;
    public AudioSource goFx;


    void Start()
    {
        StartCoroutine(CountSequence());
    }
    IEnumerator CountSequence()
    {
        yield return new WaitForSeconds(1.5f);
        countDown3.SetActive(true);
        readyFx.Play();
        yield return new WaitForSeconds(1.5f);
        countDown2.SetActive(true);
        readyFx.Play();
        yield return new WaitForSeconds(1.5f);
        countDown1.SetActive(true);
       readyFx.Play();
        yield return new WaitForSeconds(1.5f);
        countDownGo.SetActive(true);
        goFx.Play();
        PlayerMove.canMove = true;

    }


}