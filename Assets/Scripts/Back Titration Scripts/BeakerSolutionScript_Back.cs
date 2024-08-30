using LiquidVolumeFX;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BeakerSolutionScript_Back : MonoBehaviour
{
    public bool isFilled;

    //colour changes for reaction
    [SerializeField] Color indicatorColorAcid;
    [SerializeField] Color indicatorColorBase;
    [SerializeField] Color endPointColorAcid;
    [SerializeField] Color endPointColorBase;

    //Colour changes for dissolution
    [SerializeField] Color lowSolubleColor;
    [SerializeField] Color highSolubleColor;

    Material currentMaterial;

    [SerializeField] LiquidVolume conicalFlaskLiquidScript_Back;

    //State Managers
    public bool isReacting;
    public bool indicatorAdded;
    bool lowSoluble;
    bool highSoluble;

    float count = 0;
    int solubleCount = 0;

    [HideInInspector] public bool isAcidFilled;
    [HideInInspector] public bool isBaseFilled;

    // Start is called before the first frame update
    void Start()
    {
        isFilled = false;
        isReacting = false;
        indicatorAdded = false;
        lowSoluble = false;
        highSoluble = false;
        conicalFlaskLiquidScript_Back.level = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (conicalFlaskLiquidScript_Back.level != 0)
        {
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
                   conicalFlaskLiquidScript_Back.liquidColor1 = endPointColorAcid;
                }
                else if (count > 4 && count < 5) //this logic sucks lol...
                {
                    //temporary color change
                    conicalFlaskLiquidScript_Back.liquidColor1 = endPointColorAcid;
                    Invoke("ReturnColorAcid", 2f);
                }
            } else if(isBaseFilled)
            {
                if (count >= 8)
                {
                    conicalFlaskLiquidScript_Back.liquidColor1 = endPointColorBase;
                }
                else if (count > 4 && count < 5) //this logic sucks lol...
                {
                    //temporary color change
                    conicalFlaskLiquidScript_Back.liquidColor1 = endPointColorBase;
                    Invoke("ReturnColorBase", 2f);
                }
            }
        }

        //change color to show concentration
        switch(solubleCount)
        {
            case 2:
                lowSoluble = true;
                break;

            case > 4:
                highSoluble = true;
                break;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "indicator")
        {
            if(isFilled)
            {
                if (isAcidFilled)
                {
                    conicalFlaskLiquidScript_Back.liquidColor1 = indicatorColorAcid;
                    indicatorAdded = true;
                } else if (isBaseFilled)
                {
                    conicalFlaskLiquidScript_Back.liquidColor1 = indicatorColorBase;
                    indicatorAdded = true;
                } 
            }
        }

        if(other.gameObject.tag == "soluble")
        {
            if(isFilled)
            {
                GameObject solubleSample = other.gameObject;
                solubleCount++;
                Destroy(solubleSample);
            } else
            {
                Debug.Log("Fill the conical flask first dude...");
            }

            if(lowSoluble)
            {
                conicalFlaskLiquidScript_Back.liquidColor1 = lowSolubleColor;
            }

            if(highSoluble)
            {
                conicalFlaskLiquidScript_Back.liquidColor1 = highSolubleColor;
            }
        }
    }

    //return to indicator color in acid
    private void ReturnColorAcid()
    {
        conicalFlaskLiquidScript_Back.liquidColor1 = indicatorColorAcid;
    }

    //return to indicator color in bas
    private void ReturnColorBase()
    {
        conicalFlaskLiquidScript_Back.liquidColor1 = indicatorColorBase;
    }
}
