using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlenderController : MonoBehaviour
{
    private Animator ThisController = null;
    private int PourParam = Animator.StringToHash("Pour");
    private int BlendParam = Animator.StringToHash("Blend");
    private int DetailParam = Animator.StringToHash("Detail");

    public GameObject Stw;
    public GameObject Blb;
    public GameObject Kiwi;
    public GameObject StwParticle;
    public GameObject BlbParticle;
    public GameObject KiwiParticle;
    public GameObject StwLiquid;
    public GameObject BlbLiquid;
    public GameObject KiwiLiquid;
    public GameObject StwSmoothie;
    public GameObject BlbSmoothie;
    public GameObject KiwiSmoothie;
    public GameObject Start;
    public GameObject Stop;
    public GameObject DetailPanel;

    private void Awake()
    {
        ThisController = GetComponent<Animator>();
    }

    public void TogglePour()
    {
        ThisController.SetTrigger(PourParam);
        if (StwLiquid.activeSelf == true)
        {
            Reduceliquid reduceLiquidComponent = StwLiquid.GetComponent<Reduceliquid>();
            reduceLiquidComponent.enabled = true;
            StwSmoothie.SetActive(true);
        }

        if (BlbLiquid.activeSelf == true)
        {
            Reduceliquid reduceLiquidComponent = BlbLiquid.GetComponent<Reduceliquid>();
            reduceLiquidComponent.enabled = true;
            BlbSmoothie.SetActive(true);
        }

        if (KiwiLiquid.activeSelf == true)
        {
            Reduceliquid reduceLiquidComponent = KiwiLiquid.GetComponent<Reduceliquid>();
            reduceLiquidComponent.enabled = true;
            KiwiSmoothie.SetActive(true);
        }
    }


    public void ToggleBlend()
    {
        ThisController.SetBool(BlendParam,!ThisController.GetBool(BlendParam));
        if (ThisController.GetBool(BlendParam) == true)
        {
            Start.SetActive(false);
            Stop.SetActive(true);
            if (Stw.activeSelf == true)
            {
                Stw.SetActive(false);
                StwParticle.SetActive(true);
            
            }

            if (Blb.activeSelf == true)
            {
                Blb.SetActive(false);
                BlbParticle.SetActive(true);
              
            }
            if (Kiwi.activeSelf == true)
            {
                Kiwi.SetActive(false);
                KiwiParticle.SetActive(true);
             
            }
        }
        else 
        {
            Start.SetActive(true);
            Stop.SetActive(false);
            if (StwParticle.activeSelf == true)
            {
                StwParticle.SetActive(false);
                StwLiquid.SetActive(true);
            }

            if (BlbParticle.activeSelf == true)
            {
                BlbParticle.SetActive(false);
                BlbLiquid.SetActive(true);
  
            }
            if (KiwiParticle.activeSelf == true)
            {
                KiwiParticle.SetActive(false);
                KiwiLiquid.SetActive(true);
            }
        }


    }

    public void ToggleDetail()
    {

        ThisController.SetBool(DetailParam, !ThisController.GetBool(DetailParam));
        StartCoroutine(DetailActive());
    }
    private IEnumerator DetailActive()
    {
        yield return new WaitForSeconds(2f);
        DetailPanel.SetActive(!DetailPanel.activeSelf);
    }

}
