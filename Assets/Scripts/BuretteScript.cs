using LiquidVolumeFX;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BuretteScript : MonoBehaviour
{
    //Burette Objects
    [SerializeField] XRSocketInteractor socketInteractor;

    //Burette reading
    [SerializeField] TextMeshProUGUI volume;

    //burette solution
    [SerializeField] LiquidVolume buretteLiquidScript;

    public bool funnelSnapped;
    public bool isFilled;
    // Start is called before the first frame update
    void Start()
    {
        funnelSnapped = false;
        isFilled = false;
        buretteLiquidScript.level = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        checkObjectInSocket();
        if (buretteLiquidScript.level != 0.0f)
        {
            displayVolume();
        } else
        {
            volume.text = "0ml";
        }

        if(buretteLiquidScript.level > 0)
        {
            isFilled = true;
        } else
        {
            isFilled = false;
        }
    }

    void displayVolume()
    {
        float fillAmount = buretteLiquidScript.level;
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
        float minVolume = 0.0f;
        float maxVolume = 1.0f;
        float scaleFactor = 50f / (maxVolume - minVolume);

        return Mathf.Floor(scaleFactor * (volume - minVolume));
    }
}
