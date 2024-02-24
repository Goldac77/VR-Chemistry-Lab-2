using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BeakerSolutionScript_Back : MonoBehaviour
{
    public bool isFilled;
    Material startingMaterial;

    //colour changes for reaction
    [SerializeField] Color indicatorColorAcid;
    [SerializeField] Color indicatorColorBase;
    [SerializeField] Color endPointColorAcid;
    [SerializeField] Color endPointColorBase;

    //Colour changes for dissolution
    [SerializeField] Color lowSolubleColor;
    [SerializeField] Color highSolubleColor;

    Material currentMaterial;
    [SerializeField] XRSocketInteractor socketInteractor;

    //State Managers
    public bool isReacting;
    public bool indicatorAdded;
    bool lowSoluble;
    bool highSoluble;

    float count = 0;
    int solubleCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        isFilled = false;
        isReacting = false;
        indicatorAdded = false;
        startingMaterial = GetComponent<Renderer>().material;
        socketInteractor.socketActive = false;
        lowSoluble = false;
        highSoluble = false;
    }

    // Update is called once per frame
    void Update()
    {
        currentMaterial = GetComponent<Renderer>().material;

        if (currentMaterial != startingMaterial)
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

            if (currentMaterial.name == "HCL (Instance) (Instance) (Instance)") //if acid fills beaker
            {
                if (count >= 8)
                {
                    currentMaterial.color = endPointColorAcid;
                }
                else if (count > 4 && count < 5) //this logic sucks lol...
                {
                    //temporary color change
                    currentMaterial.color = endPointColorAcid;
                    Invoke("ReturnColorAcid", 2f);
                }
            } else if(currentMaterial.name == "NaOH (Instance) (Instance) (Instance)")
            {
                if (count >= 8)
                {
                    currentMaterial.color = endPointColorBase;
                }
                else if (count > 4 && count < 5) //this logic sucks lol...
                {
                    //temporary color change
                    currentMaterial.color = endPointColorBase;
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
                if(currentMaterial.name == "HCL (Instance) (Instance) (Instance)")
                {
                    currentMaterial.color = indicatorColorAcid;
                    indicatorAdded = true;
                } else if (currentMaterial.name == "NaOH (Instance) (Instance) (Instance)")
                {
                    currentMaterial.color = indicatorColorBase;
                    indicatorAdded = true;
                } 
            }
        }

        if(other.gameObject.tag == "soluble")
        {
            socketInteractor.socketActive = true;
            if(isFilled)
            {
                GameObject solubleSample = other.gameObject;
                solubleCount++;
                Destroy(solubleSample);
            } else
            {
                Debug.Log("Fill the beaker first dude...");
            }

            if(lowSoluble)
            {
                currentMaterial.color = lowSolubleColor;
            }

            if(highSoluble)
            {
                currentMaterial.color = highSolubleColor;
            }
        } else
        {
            socketInteractor.socketActive = false;
        }
    }

    //return to indicator color in acid
    private void ReturnColorAcid()
    {
        currentMaterial.color = indicatorColorAcid;
    }

    //return to indicator color in bas
    private void ReturnColorBase()
    {
        currentMaterial.color = indicatorColorBase;
    }
}
