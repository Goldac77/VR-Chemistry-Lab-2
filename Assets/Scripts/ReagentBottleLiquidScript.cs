using LiquidVolumeFX;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReagentBottleLiquidScript : MonoBehaviour
{
    [SerializeField] BeakerSolutionScript beakerSolutionScript;
    [SerializeField] BuretteScript buretteScript;

    [SerializeField] Color acidColor;
    [SerializeField] Color baseColor;

    [SerializeField] bool isAcid;
    [SerializeField] bool isBase;

    [SerializeField] LiquidVolume buretteLiquidScript;
    [SerializeField] LiquidVolume conicalFlaskLiquidScript;

    [SerializeField] float fillRate;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleTrigger()
    {
        if (buretteScript.funnelSnapped)
        {
            //Possible bug?
            //The logic here has a LOT of issues, and edge cases that need to be fixed
            if (buretteScript.isFilled)
            {
                Debug.Log("burette is filled");
            } 
            else if(!beakerSolutionScript.isFilled)
            {
                //do nothing
            }
            else
            {
                if(isAcid)
                {
                    buretteLiquidScript.liquidColor1 = acidColor;
                } else
                {
                    buretteLiquidScript.liquidColor1 = baseColor;
                }
                StartCoroutine(FillBurette());
            }
        } else
        {
            if(beakerSolutionScript.isFilled)
            {
                Debug.Log("Conical flask filled");
            } else
            {
                if(!buretteScript.funnelSnapped)
                {
                    StartCoroutine(FillConicalFlask());
                    if (isAcid)
                    {
                        conicalFlaskLiquidScript.liquidColor1 = acidColor;
                        beakerSolutionScript.isAcidFilled = true;
                    }
                    else
                    {
                        conicalFlaskLiquidScript.liquidColor1 = baseColor;
                        beakerSolutionScript.isBaseFilled = true;
                    }
                }
            } 
        }
    }

    IEnumerator FillBurette()
    {
        float volume = buretteLiquidScript.level;
        float maxFill = 1.0f;
        while(volume < maxFill)
        {
            volume += fillRate * Time.deltaTime;
            volume = Mathf.Min(volume, maxFill);
            buretteLiquidScript.level = volume;
            yield return null;
        }
    }

    IEnumerator FillConicalFlask()
    {
        float volume = conicalFlaskLiquidScript.level;
        float maxFill = 0.36f;
        while(volume < maxFill)
        {
            volume += fillRate * Time.deltaTime;
            volume = Mathf.Min(volume, maxFill);
            conicalFlaskLiquidScript.level = volume;
            yield return null;
        }
    }
}
