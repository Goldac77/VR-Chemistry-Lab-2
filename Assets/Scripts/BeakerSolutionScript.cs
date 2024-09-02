using LiquidVolumeFX;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeakerSolutionScript : MonoBehaviour
{
    public bool isFilled;

    //colour changes
    [SerializeField] Color indicatorColorAcid;
    [SerializeField] Color indicatorColorBase;
    [SerializeField] Color endPointColorAcid;
    [SerializeField] Color endPointColorBase;

    public bool isReacting;
    public bool indicatorAdded;

    [SerializeField] LiquidVolume conicalFlaskLiquidScript;

    float count = 0;

    [HideInInspector] public bool isAcidFilled;
    [HideInInspector] public bool isBaseFilled;
    // Start is called before the first frame update
    void Start()
    {
        isFilled = false;
        isReacting = false;
        indicatorAdded = false;
        conicalFlaskLiquidScript.level = 0;
        gameObject.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (conicalFlaskLiquidScript.level != 0)
        {
            gameObject.GetComponent<Renderer>().enabled = true;
            isFilled = true;
        }
        else
        {
            isFilled = false;
        }

        if(isReacting)
        {
            //NOTE: it takes 10.5 seconds for the burette to be empty
            count += Time.deltaTime;

            if (isAcidFilled) //if acid fills beaker
            {
                if (count >= 8)
                {
                    conicalFlaskLiquidScript.liquidColor1 = endPointColorAcid;
                }
                else if (count > 4 && count < 5) //this logic sucks lol...
                {
                    //temporary color change
                    conicalFlaskLiquidScript.liquidColor1 = endPointColorAcid;
                    Invoke("ReturnColorAcid", 2f);
                }
            } else if(isBaseFilled)
            {
                if (count >= 8)
                {
                    conicalFlaskLiquidScript.liquidColor1 = endPointColorBase;
                }
                else if (count > 4 && count < 5) //this logic sucks lol...
                {
                    //temporary color change
                    conicalFlaskLiquidScript.liquidColor1 = endPointColorBase;
                    Invoke("ReturnColorBase", 2f);
                }
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "indicator")
        {
            if(isFilled)
            {
                if(isAcidFilled)
                {
                    conicalFlaskLiquidScript.liquidColor1 = indicatorColorAcid;
                    indicatorAdded = true;
                } else if (isBaseFilled)
                {
                    conicalFlaskLiquidScript.liquidColor1 = indicatorColorBase;
                    indicatorAdded = true;
                } 
            }
        }
    }

    //return to indicator color in acid
    private void ReturnColorAcid()
    {
        conicalFlaskLiquidScript.liquidColor1 = indicatorColorAcid;
    }

    //return to indicator color in bas
    private void ReturnColorBase()
    {
        conicalFlaskLiquidScript.liquidColor1 = indicatorColorBase;
    }
}
