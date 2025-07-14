using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public string parentName;

    void Start()
    {
        parentName = transform.name;
        StartCoroutine(DestroyClone());
    }
    IEnumerator DestroyClone()
    {
        yield return new WaitForSeconds(250);
        if (parentName == "Section(Clone)") {
            Destroy(gameObject);
        }
    }
}




/*using System.Collections;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public float destructionDuration = 10f; // Total time to destroy the section
    public float shrinkSpeed = 0.05f;       // Speed at which the section shrinks

    private float startTime;
    private Vector3 initialScale;

    void Start()
    {
        startTime = Time.time;
        initialScale = transform.localScale;
        StartCoroutine(DestroySectionOverTime());
    }

    IEnumerator DestroySectionOverTime()
    {
        while (Time.time < startTime + destructionDuration)
        {
            float shrinkAmount = shrinkSpeed * Time.deltaTime;

            // Shrink the section gradually
            transform.localScale -= new Vector3(shrinkAmount, shrinkAmount, shrinkAmount);

            yield return null; // Wait for the next frame
        }

        Destroy(gameObject);
    }
}*/

