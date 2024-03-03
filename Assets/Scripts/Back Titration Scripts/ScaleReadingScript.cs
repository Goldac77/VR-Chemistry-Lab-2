using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.PackageManager.UI;
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

    public void OnSampleEntered()
    {
        IXRSelectInteractable objectInSocket = socketInteractor.GetOldestInteractableSelected();
        Rigidbody sampleRigidbody = objectInSocket.transform.GetComponent<Rigidbody>();
        massText.text = sampleRigidbody.mass.ToString() + "kg";
    }

    public void onSampleExited()
    {
        massText.text = "0kg";
    }
}
