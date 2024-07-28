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
    [SerializeField] XRRayInteractor RightrayInteractor; //this is currently for the right controller (for now)
    // Start is called before the first frame update

    Vector3 bottleRotation;
    void Start()
    {
        capAttached = false;
    }

    // Update is called once per frame
    void Update()
    {

        debugger.DisplayMessage($"ray rotation values: \n x = {RightrayInteractor.transform.localEulerAngles.x} \n y = {RightrayInteractor.transform.localEulerAngles.y} \n z = {RightrayInteractor.transform.localEulerAngles.z}");
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
