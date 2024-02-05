using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BuretteScript : MonoBehaviour
{
    //Burette Objects
    [SerializeField] XRSocketInteractor socketInteractor;
    [SerializeField] GameObject buretteSolution;
    Material startingMaterial;

    [SerializeField] PipetteScript pipetteScript;

    //Burette reading
    [SerializeField] TextMeshProUGUI volume;

    //burette solution materials
    [SerializeField] Material acidMaterial;
    [SerializeField] Material baseMaterial;

    bool funnelSnapped;
    public bool isFilled;
    // Start is called before the first frame update
    void Start()
    {
        funnelSnapped = false;
        isFilled = false;
        startingMaterial = buretteSolution.GetComponent<Renderer>().material; //this is the same material in pipetteSolution
    }

    // Update is called once per frame
    void Update()
    {
        checkObjectInSocket();
        Material currentLiquidMaterial = buretteSolution.GetComponent<Renderer>().material;
        if(currentLiquidMaterial != startingMaterial)
        {
            displayVolume(currentLiquidMaterial);
        } else
        {
            volume.text = "0";
        }
    }

    void displayVolume(Material x)
    {
        float fillAmount = x.GetFloat("_Fill");
        fillAmount = convertVolume(fillAmount);
        volume.text = fillAmount.ToString();
    }

    private void checkObjectInSocket()
    {
        IXRSelectInteractable objectInSocket = socketInteractor.GetOldestInteractableSelected();

        if(objectInSocket != null && objectInSocket.transform.tag == "funnel")
        {
            funnelSnapped = true;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(funnelSnapped)
        {
            //allow filling burette
            if(other.gameObject.tag == "pipette" && pipetteScript.solutionPicked && !isFilled)
            {
                acidMaterial.SetFloat("_Fill", 0.63f);
                baseMaterial.SetFloat("_Fill", 0.63f);
                switch(pipetteScript.pipetteSolution.GetComponent<Renderer>().material.name)
                {
                    case "HCL (Instance) (Instance)":
                        buretteSolution.GetComponent<Renderer>().material = acidMaterial;
                        pipetteScript.pipetteSolution.GetComponent<Renderer>().material = startingMaterial;
                        pipetteScript.solutionPicked = false;
                        break;
                    case "NaOH (Instance) (Instance)":
                        buretteSolution.GetComponent<Renderer>().material = baseMaterial;
                        pipetteScript.pipetteSolution.GetComponent<Renderer>().material = startingMaterial;
                        pipetteScript.solutionPicked = false;
                        break;
                }
                isFilled = true;
            }
        }
    }

    float convertVolume(float volume)
    {
        float minVolume = 0.42f;
        float maxVolume = 0.63f;
        float scaleFactor = 50f / (maxVolume - minVolume);

        return Mathf.Floor(scaleFactor * (volume - minVolume));
    }
}
