using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabbableModifierScript : MonoBehaviour
{
    [Tooltip("The object with the grab interactable")]
    GameObject grabbableObject;

    Color defaultColor;
    [SerializeField] Color hoverColor;

    XRGrabInteractable grabInteractable;

    Renderer grabbableRenderer;

    bool socketGrabbed;
    // Start is called before the first frame update
    void Start()
    {
        grabbableObject = gameObject;
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabbableRenderer = GetComponent<Renderer>();
        defaultColor = grabbableRenderer.material.color;
        socketGrabbed = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHoverEnter()
    {
        if(gameObject.transform.name == "Cap")
        {
            if(socketGrabbed && grabInteractable.interactorsHovering.Any(interactor => interactor.transform.name != "capAttach"))
            {
                grabbableRenderer.material.color = hoverColor;
            } else if(!socketGrabbed && grabInteractable.interactorsHovering.Any(interactor => interactor.transform.name != "capAttach"))
            {
                grabbableRenderer.material.color = hoverColor;
            }
        } else
        {
            grabbableRenderer.material.color = hoverColor;
        }
    }

    public void OnHoverExit()
    {
        if(gameObject.transform.name == "Cap" && socketGrabbed)
        {
            grabbableRenderer.material.color = defaultColor;
        } else
        {
            grabbableRenderer.material.color = defaultColor;
        }
    }

    public void CapHoverExit()
    {
        if(gameObject.transform.name == "Cap")
        {
            grabbableRenderer.material.color = defaultColor;
        }
    }

    public void OnGrabbed()
    {
        IXRSelectInteractor interactor = grabInteractable.firstInteractorSelecting;
        if (interactor.transform.name != "capAttach")
        {
            grabbableRenderer.material.color = hoverColor;
        } else
        {
            socketGrabbed = true;
        }
    }

    public void OnGrabExited()
    {
        grabbableRenderer.material.color = defaultColor;
        socketGrabbed = false;
    }
}
