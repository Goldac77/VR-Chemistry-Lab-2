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
                buretteLiquidScript.level = 1.0f;
                buretteScript.isFilled = true;
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
                    conicalFlaskLiquidScript.level = 0.36f;
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
}
