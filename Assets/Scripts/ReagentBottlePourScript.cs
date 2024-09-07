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

    [HideInInspector] public bool grabbed;
    // Start is called before the first frame update

    Vector3 bottleRotation;
    void Start()
    {
        capAttached = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!capAttached)
        {
            if (gameObject.transform.localEulerAngles.z > 86.0f && gameObject.transform.localEulerAngles.z < 170.0f)
            {
                debugger.DisplayMessage("Pouring");
                if (!liquidPouring.isPlaying)
                {
                    liquidPouring.Play();
                }
            }
            else
            {
                if (liquidPouring.isPlaying)
                {
                    liquidPouring.Stop();
                }
            }
        }
    }

    public void OnGrabbed()
    {
        CheckObjectInSocket();
        grabbed = true;
    }

    public void OnGrabExited()
    {
        grabbed = false;
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
