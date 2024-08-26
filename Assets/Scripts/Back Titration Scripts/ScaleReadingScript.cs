using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ScaleReadingScript : MonoBehaviour
{
    //This script does nothing but read mass data of grabbable objects
    //and sends that data to TextMeshProGUI

    [SerializeField] TextMeshProUGUI massText;
    List<float> scaleObjects = new List<float>();

    private void Start()
    {
        massText.text = "0kg";
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        if(other.gameObject.tag == "soluble")
        {
            scaleObjects.Add(other.gameObject.GetComponent<Rigidbody>().mass);
        }

        massText.text = scaleObjects.Sum().ToString();
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "soluble")
        {
            scaleObjects.Remove(other.gameObject.GetComponent<Rigidbody>().mass);
            massText.text = scaleObjects.Sum().ToString();
        }

        if(scaleObjects.Count <= 0)
        {
            massText.text = "0kg";
        }
    }
}
