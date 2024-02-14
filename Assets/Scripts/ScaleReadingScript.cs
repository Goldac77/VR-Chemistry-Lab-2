using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ScaleReadingScript : MonoBehaviour
{
    //This script does nothing but read mass data of grabbable objects
    //and sends that data to TextMeshProGUI

    [SerializeField] TextMeshProUGUI massText;
    XRSocketInteractor socketInteractor;

    private void Start()
    {
        massText.text = "0kg";
        socketInteractor = GetComponent<XRSocketInteractor>();
    }

    void OnTriggerStay(Collider other)
    {
        GameObject sample = other.gameObject;
        AllowSolubles(sample);
        if(sample.tag == "soluble")
        {
            Rigidbody sampleRigidbody = sample.GetComponent<Rigidbody>();
            massText.text = sampleRigidbody.mass.ToString() + "kg";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        massText.text = "0kg";
        socketInteractor.socketActive = true;
    }

    public void AllowSolubles(GameObject soluble)
    {
        if(soluble.tag != "soluble")
        {
            socketInteractor.socketActive = false;
        }
    }
}
