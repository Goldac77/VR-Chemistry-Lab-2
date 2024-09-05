using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabbableModifierScript : MonoBehaviour
{
    [Tooltip("The object with the grab interactable")]
    GameObject grabbableObject;

    Color defaultColor;
    [SerializeField] Color hoverColor;
    // Start is called before the first frame update
    void Start()
    {
        grabbableObject = gameObject;
        defaultColor = grabbableObject.GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHoverEnter()
    {
        grabbableObject.GetComponent<Renderer>().material.color = hoverColor;
    }

    public void OnHoverExit()
    {
        grabbableObject.GetComponent<Renderer>().material.color = defaultColor;
    }

    public void OnGrabbed()
    {
        grabbableObject.GetComponent<Renderer>().material.color = hoverColor;
    }

    public void OnGrabExited()
    {
        grabbableObject.GetComponent<Renderer>().material.color = defaultColor;
    }
}
