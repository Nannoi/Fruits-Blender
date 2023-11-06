using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Addliquid : MonoBehaviour
{
    // Start is called before the first frame update
    public Material Smoothie;
    public GameObject FruitSmoothie;
    public float fill = -0.25f;
    private bool isFilling = true;
    private float targetFill = 0.2f;
    private float fillSpeed = 0.01f;
    private float epsilon = 0.001f;

    void OnEnable()
    {
        Smoothie.SetFloat("_Fill", fill);
        isFilling = true;
        StartCoroutine(FillSmoothie());
    }

    private IEnumerator FillSmoothie()
    {
        yield return new WaitForSeconds(3f);

        while (fill < targetFill)
        {
            fill += fillSpeed;
            Smoothie.SetFloat("_Fill", fill);
            yield return null;
        }

        isFilling = false;
        StartCoroutine(ReduceFill());
    }

    private IEnumerator ReduceFill()
    {
        yield return new WaitForSeconds(2f);

        while (fill > -0.25f)
        {
            fill -= fillSpeed;
            Smoothie.SetFloat("_Fill", fill);
            yield return null;
        }

        FruitSmoothie.SetActive(false);
    }
}
