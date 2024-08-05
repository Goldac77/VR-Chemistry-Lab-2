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

    //Burette reading
    [SerializeField] TextMeshProUGUI volume;

    //burette solution materials
    [SerializeField] Material acidMaterial;
    [SerializeField] Material baseMaterial;

    public bool funnelSnapped;
    public bool isFilled;
    // Start is called before the first frame update
    void Start()
    {
        funnelSnapped = false;
        isFilled = false;
        startingMaterial = buretteSolution.GetComponent<Renderer>().material; //this is the same material in pipetteSolution
        acidMaterial.SetFloat("_Fill", 0.63f);
        baseMaterial.SetFloat("_Fill", 0.63f);
    }

    // Update is called once per frame
    void Update()
    {
        checkObjectInSocket();
        //TODO: get currentLiquidMaterial only once, when isFilled changes
        Material currentLiquidMaterial = buretteSolution.GetComponent<Renderer>().material;
        if(currentLiquidMaterial != startingMaterial)
        {
            displayVolume(currentLiquidMaterial);
        } else
        {
            volume.text = "0ml";
        }
    }

    void displayVolume(Material x)
    {
        float fillAmount = x.GetFloat("_Fill");
        fillAmount = convertVolume(fillAmount);
        volume.text = fillAmount.ToString() + "ml";
    }

    private void checkObjectInSocket()
    {
        IXRSelectInteractable objectInSocket = socketInteractor.GetOldestInteractableSelected();

        if(objectInSocket != null && objectInSocket.transform.tag == "funnel")
        {
            funnelSnapped = true;
        } else
        {
            funnelSnapped = false;
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
