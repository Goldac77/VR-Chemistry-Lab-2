using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketCheckScript : MonoBehaviour
{
    [SerializeField] GameObject allowedObject;
    
    XRSocketInteractor socketInteractor;

    Material validHover, invalidHover;

    [SerializeField] ReagentBottlePourScript reagentBottlePourScript;
    // Start is called before the first frame update
    void Start()
    {
        socketInteractor = GetComponent<XRSocketInteractor>();
        validHover = socketInteractor.interactableHoverMeshMaterial;
        invalidHover = socketInteractor.interactableCantHoverMeshMaterial;
    }

    // Update is called once per frame
    void Update()
    {
      if(reagentBottlePourScript != null)
        {
            if(reagentBottlePourScript.grabbed)
            {
                socketInteractor.allowSelect = false;
            } else
            {
                socketInteractor.allowSelect = true;
            }
        }
    }

    public void HoveringEnterSocket()
    {
        IXRHoverInteractable objectInSocket = socketInteractor.GetOldestInteractableHovered();
        if (objectInSocket.transform.name != allowedObject.transform.name)
        {
            socketInteractor.interactableHoverMeshMaterial = invalidHover;
            socketInteractor.allowSelect = false;
        } else
        {
            socketInteractor.allowSelect = true;
        }
    }

    public void HoveringExitSocket()
    {
        socketInteractor.interactableHoverMeshMaterial = validHover;
        socketInteractor.allowSelect = true;
    }
}
