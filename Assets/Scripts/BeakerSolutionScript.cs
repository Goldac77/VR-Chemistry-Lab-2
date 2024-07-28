using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeakerSolutionScript : MonoBehaviour
{
    public bool isFilled;
    Material startingMaterial;

    //colour changes
    [SerializeField] Color indicatorColorAcid;
    [SerializeField] Color indicatorColorBase;
    [SerializeField] Color endPointColorAcid;
    [SerializeField] Color endPointColorBase;

    Material currentMaterial;

    public bool isReacting;
    public bool indicatorAdded;

    float count = 0;
    // Start is called before the first frame update
    void Start()
    {
        isFilled = false;
        isReacting = false;
        indicatorAdded = false;
        startingMaterial = GetComponent<Renderer>().material;
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

            if (currentMaterial.name == "HCL(pipette) (Instance)") //if acid fills beaker
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
            } else if(currentMaterial.name == "NaOH(pipette) (Instance)")
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

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "indicator")
        {
            if(isFilled)
            {
                if(currentMaterial.name == "HCL(pipette) (Instance)")
                {
                    currentMaterial.color = indicatorColorAcid;
                    indicatorAdded = true;
                } else if (currentMaterial.name == "NaOH(pipette) (Instance)")
                {
                    currentMaterial.color = indicatorColorBase;
                    indicatorAdded = true;
                } 
            }
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
