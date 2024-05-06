using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ScaleReadingScript : MonoBehaviour
{
    //This script does nothing but read mass data of grabbable objects
    //and sends that data to TextMeshProGUI

    [SerializeField] TextMeshProUGUI massText;

    private void Start()
    {
        massText.text = "0kg";
    }

    private void OnTriggerStay(Collider other)
    {
        List<string> scaleObjects = null;
        //Debug.Log(other.gameObject.name);
        scaleObjects.Add(other.gameObject.name);

        for(int i = 0; i < scaleObjects.Count; i++)
        {
            Debug.Log(scaleObjects[i]);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        massText.text = "0kg";
    }
}
