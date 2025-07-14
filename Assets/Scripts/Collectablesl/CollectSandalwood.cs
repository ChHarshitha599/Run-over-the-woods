using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectSandalwood : MonoBehaviour
{
    public AudioSource coinfx;
    void OnTriggerEnter(Collider other)
    {
        coinfx.Play();
        CollectableControl.SandalwoodCount += 1;
        this.gameObject.SetActive(false);
    }
}
