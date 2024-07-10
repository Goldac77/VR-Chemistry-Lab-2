using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ReagentBottlePourScript : MonoBehaviour
{
    [SerializeField] ParticleSystem liquidPouring;
    [SerializeField] XRSocketInteractor capSocket;
    [SerializeField] bool capAttached;
    [SerializeField] Debugger debugger;
    // Start is called before the first frame update
    void Start()
    {
        capAttached = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!capAttached)
        {
            debugger.DisplayMessage($"bottle rotation: {gameObject.transform.rotation.eulerAngles.z}");
            if (gameObject.transform.localEulerAngles.z > 86.0f && gameObject.transform.localEulerAngles.z <= 170.0f)
            {
                liquidPouring.Play();
            }
            else
            {
                liquidPouring.Stop();
            }
        }
    }

    public void OnGrabbed()
    {
        CheckObjectInSocket();
    }

    private void CheckObjectInSocket()
    {
        IXRSelectInteractable objectInSocket = capSocket.GetOldestInteractableSelected();

        if (objectInSocket != null && objectInSocket.transform.tag == "cap")
        {
            capAttached = true;
        } else
        {
            capAttached = false;
        }

    }
}
