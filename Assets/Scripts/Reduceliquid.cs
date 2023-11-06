using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reduceliquid : MonoBehaviour
{
    // Start is called before the first frame update
    public Material Liquid;
    public GameObject FruitLiquid;
    public float fill = 0.02f;
    private bool isFilling = true;
    private float targetFill = 0.2f;
    private float fillSpeed = 0.005f;
    private float epsilon = 0.001f;

    void OnEnable()
    {
        Liquid.SetFloat("_Fill", fill);
        isFilling = true;
        StartCoroutine(ReduceSmoothie());
    }

    private IEnumerator ReduceSmoothie()
    {
        yield return new WaitForSeconds(3f);

        while (fill > -0.25f)
        {
            fill -= fillSpeed;
            Liquid.SetFloat("_Fill", fill);
            yield return null;
        }

        isFilling = false;
        fill = 0.02f;
        Liquid.SetFloat("_Fill", fill);
        this.enabled = false; // Disable this script
        FruitLiquid.SetActive(false);
    }
}
